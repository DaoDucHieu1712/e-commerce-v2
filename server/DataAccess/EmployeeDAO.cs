using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeDAO
    {
        public static async Task<List<Employee>> GetEmployee()
        {
            var employees = new List<Employee>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    employees = await db.Employees.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }
    }
}
