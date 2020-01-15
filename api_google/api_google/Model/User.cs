using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_google.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public DateTime Expiration { get; set; }
        public int Seconds { get; set; }
    }
}
