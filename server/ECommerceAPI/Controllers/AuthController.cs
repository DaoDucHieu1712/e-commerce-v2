﻿using BusinessObject.DTOs.Auth;
using BusinessObject.Models;
using DataAccess;
using ECommerceAPI.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;

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

        //    [HttpPost]
        //    public async Task<IActionResult> SignIn(SignInDTO request)
        //    {
        //        try
        //        {
        //            if (request == null) return BadRequest();
        //            var account = await AuthDAO.SignIn(request);
        //            if (account is null) return NotFound("Username or password is wrong !");
        //            user.Account = account;
        //            user.Role = account.Role;
        //            if (account.Role == 2)
        //            {
        //                user.Name = account.Customer.FullName;
        //            }
        //            else
        //            {
        //                user.Name = account.Employee.FullName;
        //            }
        //            user.AccessToken = JWTConfig.CreateToken(user, configuration);
        //            var refreshTokenConfig = JWTConfig.GenerateRefreshToken();
        //            user.RefreshToken = refreshTokenConfig.Token;
        //            user.TokenCreated = refreshTokenConfig.Created;
        //            user.TokenExpires = refreshTokenConfig.Expires;
        //            var jwtid = JWTConfig.getJTI(configuration, user);

        //            var newRefreshToken = new RefreshToken()
        //            {
        //                TokenId = Guid.NewGuid().ToString(),
        //                AccountId = account.Id,
        //                Token = refreshTokenConfig.Token,
        //                Created = refreshTokenConfig.Created,
        //                Expires = refreshTokenConfig.Expires,
        //                IsUsed = false,
        //                IsRevoked = false,
        //                JwtId = jwtid,
        //            };

        //            await AuthDAO.SaveDb(newRefreshToken);

        //            return StatusCode(200, user);
        //        }
        //        catch (ApplicationException ae)
        //        {
        //            return StatusCode(400, ae.Message);
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, ex.Message);
        //        }
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> SignUp(SignUpDTO request)
        //    {
        //        try
        //        {
        //            if (request is null) return BadRequest();
        //            var _account = await AuthDAO.GetAccountByEmail(request.Email);
        //            if (_account != null) return Ok("Email is already !!!");

        //            var NewAccount = new Account()
        //            {
        //                Email = request.Email,
        //                Password = request.Password,
        //                Role = 2,
        //                Customer = new Customer()
        //                {
        //                    FullName = request.Customer.FullName,
        //                    Gender = request.Customer.Gender,
        //                    DayOfBirth = request.Customer.DayOfBirth,
        //                    Address = request.Customer.Address,
        //                    Phone = request.Customer.Phone,
        //                },
        //                IsActive = true,
        //                IsDelete = false
        //            };
        //            await AuthDAO.SignUpWithCustomer(NewAccount);

        //            return StatusCode(200, user);
        //        }
        //        catch (ApplicationException ae)
        //        {
        //            return StatusCode(400, ae.Message);
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, ex.Message);
        //        }
        //    }
        //}
    }
}