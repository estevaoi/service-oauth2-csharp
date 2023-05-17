using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOAuth2.business.Data.Request
{
    public class AuthorizationCodeForAccessTokenRequest
    {
        public string code { get; set; }
        public string redirect_uri { get; set; }
    }
}
