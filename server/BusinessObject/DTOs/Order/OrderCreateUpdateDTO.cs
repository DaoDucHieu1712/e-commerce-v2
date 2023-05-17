using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Order
{
    public class OrderCreateUpdateDTO
    {
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? ShipAddress { get; set; }
        public int? Status { get; set; } = 1;
    }
}
