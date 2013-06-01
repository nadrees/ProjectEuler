using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this String s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return false;

            return new String(s.ToLower().Reverse().ToArray()) == s.ToLower();
        }
    }
}
