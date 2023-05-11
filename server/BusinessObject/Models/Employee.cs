using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get;set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
