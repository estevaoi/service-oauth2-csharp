using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOAuth2.business.Data.Response
{
    public class AuthorizationCodeResponse
    {
        public string State { get; set; }
        public string Code { get; set; }
    }
}
