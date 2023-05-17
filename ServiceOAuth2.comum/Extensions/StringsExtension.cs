using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOAuth2.comum.Extensions
{
    public static class StringsExtension
    {
        public static string ParseNameClass(this string getType, bool toLower = true)
        {
            var className = getType.Replace("Repository", "").Replace("Service", "");
            return toLower ? className.ToLower() : className;
        }
    }
}
