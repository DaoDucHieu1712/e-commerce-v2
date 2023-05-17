using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? ShipAddress { get; set; }
        public int? Status { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

       
    }
}
