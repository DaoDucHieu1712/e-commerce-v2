using BusinessObject.DTOs.Auth;
using BusinessObject.Migrations;
using BusinessObject.Models;
using DataAccess;
using ECommerceAPI.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository repository;
        private readonly IConfiguration configuration;
        public static AccountInfoDTO user = new();
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            repository = repo;
            configuration = config;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInDTO request)
        {
            try
            {
                if (request == null) return BadRequest();
                var account = await repository.SignIn(request);
                if (account is null) return NotFound("Username or password is wrong !");
                user.Account = account;
                user.AccountId = account.Id;
                user.Role = account.Role;
                if (account.Role == 2)
                {
                    user.Name = account.Customer.FullName;
                }
                else
                {
                    user.Name = account.Employee.FullName;
                }
                user.AccessToken = JWTConfig.CreateToken(user, configuration);
                var refreshTokenConfig = JWTConfig.GenerateRefreshToken();
                user.RefreshToken = refreshTokenConfig.Token;
                user.TokenCreated = refreshTokenConfig.Created;
                user.TokenExpires = refreshTokenConfig.Expires;
                var jwtid = JWTConfig.getJTI(configuration, user);

                var newRefreshToken = new RefreshToken()
                {
                    TokenId = Guid.NewGuid().ToString(),
                    AccountId = account.Id,
                    Token = refreshTokenConfig.Token,
                    Created = refreshTokenConfig.Created,
                    Expires = refreshTokenConfig.Expires,
                    IsUsed = false,
                    IsRevoked = false,
                    JwtId = jwtid,
                };

                await repository.SaveRefreshToken(newRefreshToken);

                return account is null ? NotFound() : Ok(user);
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDTO request)
        {
            try
            {
                if (request is null) return BadRequest();
                var _account = await AuthDAO.GetAccountByEmail(request.Email);
                if (_account != null) return Ok("Email is already !!!");
                var isSave = await repository.SignUpWithCustomer(request);
                if (isSave) return Ok(isSave);
                return Conflict();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SignUpWithEmployee")]
        public async Task<IActionResult> SignUpWithEmployee(RegisterEmployee request)
        {
            try
            {
                if (request is null) return BadRequest();
                var _account = await AuthDAO.GetAccountByEmail(request.Email);
                if (_account != null) return Ok("Email is already !!!");
                var isSave = await repository.SignUpWithEmployee(request);
                if (isSave) return Ok(isSave);
                return Conflict();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(TokenDTO request)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var tokenValidateParam = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                };

                //Check 1 : AccessToken valid format
                var verifyToken = jwtTokenHandler.ValidateToken(request.AccessToken, tokenValidateParam, out var validatedToken);

                //Check 2 : Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return Unauthorized("Token Invalid !!!");
                    }
                }

                //Check 3 : Check accessToken expire?
                var utcExpireDate = long.Parse(verifyToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = JWTConfig.ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Unauthorized("Access token has not yet expired");
                }

                //Check 4 : Check refreshtoken exist in DB
                var storedToken = await repository.GetRefreshToken(request.RefreshToken);
                if (storedToken == null)
                {
                    return Unauthorized("Refresh token does not exist");
                }

                //Check 5 : check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                {
                    return Unauthorized("Refresh token has been used");
                }
                if (storedToken.IsRevoked)
                {
                    return Unauthorized("Refresh token has been revoked");
                }

                //Check 6 : token match
                var jti = verifyToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return Unauthorized("Token doesn't match");
                }

                // refresh token after use
                await repository.UsedRefreshToken(storedToken);


                //Response Token
                string NewAccessToken = JWTConfig.CreateToken(user, configuration);
                var refreshTokenConfig = JWTConfig.GenerateRefreshToken();
                user.RefreshToken = refreshTokenConfig.Token;
                user.TokenCreated = refreshTokenConfig.Created;
                user.TokenExpires = refreshTokenConfig.Expires;
                var jwtid = JWTConfig.getJTI(configuration, user);
                var Token = new TokenDTO()
                {
                    AccessToken = NewAccessToken,
                    RefreshToken = user.RefreshToken
                };

                //Save db
                var saveRefreshToken = new RefreshToken()
                {
                    TokenId = Guid.NewGuid().ToString(),
                    JwtId = jwtid,
                    AccountId = storedToken.AccountId,
                    Token = user.RefreshToken,
                    Created = user.TokenCreated,
                    Expires = user.TokenExpires,
                    IsUsed = false,
                    IsRevoked = false
                };

                await repository.SaveRefreshToken(saveRefreshToken);
                return StatusCode(200, Token);
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

