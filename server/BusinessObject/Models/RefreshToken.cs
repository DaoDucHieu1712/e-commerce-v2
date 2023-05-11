using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class RefreshToken
    {
        public string TokenId { get; set; }
        public int AccountId { get; set; }
        public string JwtId { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }

       
    }
}
