using AutoMapper;
using BusinessObject.DTOs.Auth;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class AuthRepository : IAuthRepository
    {

        private readonly IMapper _mapper;
        public AuthRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task DeleteAccount(int id)
        {
             await AuthDAO.DeleteAccount(id);
        }

        public async Task<AccountDTO> GetAccountByEmail(string email)
        {
            return _mapper.Map<AccountDTO>(await AuthDAO.GetAccountByEmail(email));
        }

        public async Task<AccountDTO> GetAccountById(int id)
        {
            return _mapper.Map<AccountDTO>(await AuthDAO.GetAccountById(id));
        }

        public Task<AccountDTO> SignIn(SignInDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> SignUpWithCustomer(SignUpDTO signupDTO)
        {
            throw new NotImplementedException();
        }
    }
}
