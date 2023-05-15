using BusinessObject.DTOs.Auth;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthRepository
    {
        Task<Account> SignIn(SignInDTO request);
        Task<AccountDTO> GetAccountById(int id);
        Task<AccountDTO> GetAccountByEmail(string email);
        Task DeleteAccount(int id);
        Task<bool> SignUpWithCustomer(SignUpDTO signupDTO);
        Task<RefreshToken> GetRefreshToken(string refreshToken);
        Task<bool> SaveRefreshToken(RefreshToken refreshToken);
        Task<bool> UsedRefreshToken(RefreshToken refreshToken);
        Task<bool> IvokeRefreshToken(RefreshToken refreshToken);
    }
}
