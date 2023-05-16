using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAO
    {
        public static async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    customers = await db.Customers.ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return customers;
        }

        public static async Task<Customer> GetCustomer(int id)
        {
            Customer customer= new Customer();
            try
            {
                using (var db = new ECommerceContext())
                {
                    customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
      
    }
}
