using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get;set; }
        [Required]
        public string Password { get;set; }
        public int? CustomerId { get;set; }
        public int? EmployeeId { get;set; }
        [Required]
        public int Role { get; set; }
        public bool? IsActive { get;set; }
        public bool? IsDelete { get;set; }
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }

    }
}
