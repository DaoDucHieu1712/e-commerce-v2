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
                account = await db.Accounts.FirstOrDefaultAsync(x => x.Email== request.Email && x.Password == request.Password);
            }
            return account;
        }

        public static async Task<Account> GetAccountById(int id)
        {
            Account? account;
            using (var db = new ECommerceContext())
            {
                account = await db.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            }
            return account ;
        }

        public static async Task<Account> GetAccountByEmail(string email)
        {
            Account? account;
            using (var db = new ECommerceContext())
            {
                account = await db.Accounts.FirstOrDefaultAsync(x => x.Email == email);
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

        public static async Task SaveDb(RefreshToken refreshToken)
        {
            using (var db = new ECommerceContext())
            {
              await db.RefreshTokens.AddAsync(refreshToken);
              await db.SaveChangesAsync();
            }
        }

        public static async Task<Account> SignUpWithCustomer(Account account)
        {
            using(var db =new ECommerceContext())
            {
                await db.Accounts.AddAsync(account);
                await db.SaveChangesAsync();
                return db.Accounts.FirstOrDefault(x => x.Id == account.Id);
            }
        }

    }
}
