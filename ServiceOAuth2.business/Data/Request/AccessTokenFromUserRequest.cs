using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOAuth2.business.Data.Request
{
    public class AccessTokenFromUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
    }
}
