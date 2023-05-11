using BusinessObject.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Auth
{
    public class SignUpDTO
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
        public CustomerCreateUpdateDTO? Customer { get; set; }
    }
}
