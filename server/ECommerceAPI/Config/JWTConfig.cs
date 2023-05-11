using BusinessObject.DTOs.Auth;
using BusinessObject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerceAPI.Config
{
    public class JWTConfig
    {

        public static RefreshToken GenerateRefreshToken()
        {
            var RefreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddMinutes(30),
                Created = DateTime.Now
            };
            return RefreshToken;
        }

        public static string CreateToken(AccountInfoDTO user , IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var role = user.Account.Role == 2 ? "Customer" : "Employee";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Id", user.Account.Id.ToString()),
                new Claim("UserName", user.Name.ToString()),
                new Claim("Role", user.Account.Role.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }

        public static string getJTI(IConfiguration _configuration, AccountInfoDTO user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
            };
            var verifyToken = jwtTokenHandler.ValidateToken(user.AccessToken, tokenValidateParam, out var validatedToken);
            var jti = verifyToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            return jti;
        }
    }
}
