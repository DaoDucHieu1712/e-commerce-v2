using BusinessObject.DTOs.Customer;
using BusinessObject.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Auth
{
    public class RegisterEmployee
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public EmployeeCreateUpdateDTO? Employee { get; set; }
    }
}
