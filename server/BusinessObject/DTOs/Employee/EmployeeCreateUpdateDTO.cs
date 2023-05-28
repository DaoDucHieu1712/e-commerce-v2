using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Employee
{
    public class EmployeeCreateUpdateDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? FullName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; } = true;
    }
}
