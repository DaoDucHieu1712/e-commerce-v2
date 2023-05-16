using BusinessObject.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomer(int id);
    }
}
