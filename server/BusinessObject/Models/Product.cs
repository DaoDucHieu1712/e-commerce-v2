using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public partial class Product
    {
        public Product() { 
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set;}
        public bool? IsDelete { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
