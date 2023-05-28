using BusinessObject.DTOs.Auth;
using BusinessObject.Migrations;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthDAO
    {
        public static async Task<Account> SignIn(SignInDTO request)
        {
            Account? account;
            using (var db = new ECommerceContext())
            {
                account = await db.Accounts.Include(x => x.Customer).Include(x => x.Employee).
                    FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
            }
            return account;
        }

        public static async Task<Account> GetAccountById(int id)
        {
            Account? account;
            using (var db = new ECommerceContext())
            {
                account = await db.Accounts.Include(x => x.Customer).Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
            }
            return account;
        }

        public static async Task<Account> GetAccountByEmail(string email)
        {
            Account? account;
            using (var db = new ECommerceContext())
            {
                account = await db.Accounts.Include(x => x.Customer).Include(x => x.Employee).FirstOrDefaultAsync(x => x.Email == email);
            }
            return account;
        }

        public static async Task DeleteAccount(int id)
        {
            using (var db = new ECommerceContext())
            {
                var account = await GetAccountById(id);
                account.IsDelete = true;
                await db.SaveChangesAsync();
            }
        }

        public static async Task<bool> SaveDb(RefreshToken refreshToken)
        {
            using (var db = new ECommerceContext())
            {
                await db.RefreshTokens.AddAsync(refreshToken);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> SignUpWithCustomer(SignUpDTO req)
        {
            using (var db = new ECommerceContext())
            {
                Account Account = new Account()
                {
                    Email = req.Email,
                    Password = req.Password,
                    IsActive = true,
                    IsDelete = false,
                    Role = 2,
                    Customer = new Customer()
                    {
                        Image = req.Customer!.Image,
                        FullName = req.Customer!.FullName,
                        Gender = req.Customer!.Gender,
                        DayOfBirth = req.Customer!.DayOfBirth,
                        Address = req.Customer!.Address,
                        Phone = req.Customer!.Phone,
                        IsActive = true
                    }
                };
                await db.Accounts.AddAsync(Account);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<bool> SignUpWithEmployee(RegisterEmployee req)
        {
            using (var db = new ECommerceContext())
            {
                Account Account = new Account()
                {
                    Email = req.Email,
                    Password = req.Password,
                    IsActive = true,
                    IsDelete = false,
                    Role = 1,
                    Employee = new Employee()
                    {
                        Image = req.Employee!.Image,
                        FullName = req.Employee!.FullName,
                        Gender = req.Employee!.Gender,
                        DayOfBirth = req.Employee!.DayOfBirth,
                        Address = req.Employee!.Address,
                        Phone = req.Employee!.Phone,
                        IsActive = true
                    }
                };
                await db.Accounts.AddAsync(Account);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public static async Task<RefreshToken> GetRefreshToken(string refreshToken)
        {
            using (var db = new ECommerceContext())
            {
                return await db.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            }
        }

        public static async Task<bool> UsedRefreshToken(RefreshToken refreshToken)
        {
            using (var db = new ECommerceContext())
            {
                refreshToken.IsUsed = true;
                db.Update(refreshToken);
                return await db.SaveChangesAsync() > 0;
            };
        }

        public static async Task<bool> IvokedRefreshToken(RefreshToken refreshToken)
        {
            using (var db = new ECommerceContext())
            {
                refreshToken.IsRevoked = true;
                db.Update(refreshToken);
                return await db.SaveChangesAsync() > 0;
            };
        }
    }
}

