using BusinessObject.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthRepository
    {
        Task<AccountDTO> SignIn(SignInDTO request);
        Task<AccountDTO> GetAccountById(int id);
        Task<AccountDTO> GetAccountByEmail(string email);
        Task DeleteAccount(int id);
        Task<AccountDTO> SignUpWithCustomer(SignUpDTO signupDTO);
    }
}
