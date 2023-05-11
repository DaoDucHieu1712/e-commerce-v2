using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Auth
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int Role { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
