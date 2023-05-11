using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.Auth
{
    public class AccountInfoDTO
    {
        [JsonIgnore]
        public Account? Account { get; set; }
        public int AccountId { get; set; }
        public string? Name { get; set; }
        public int Role { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime TokenCreated { get; set; }
        [JsonIgnore]
        public DateTime TokenExpires { get; set; }
    }
}
