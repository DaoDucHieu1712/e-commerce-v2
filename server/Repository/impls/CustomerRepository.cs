using AutoMapper;
using BusinessObject.DTOs.Customer;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper _mapper;
        public CustomerRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<CustomerDTO> GetCustomer(int id)
        {
            return _mapper.Map<CustomerDTO>(await CustomerDAO.GetCustomer(id));
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
           return _mapper.Map<List<CustomerDTO>>(await CustomerDAO.GetCustomers());
        }
    }
}
