using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace PasswordGen.Extensions
{
    public static class StringExtensions
    {
        public static SecureString ToSecureString(this string str)
        {
            var s = new SecureString();
            foreach (var c in str)
            {
                s.AppendChar(c);
            }
            return s;
        }
    }
}
