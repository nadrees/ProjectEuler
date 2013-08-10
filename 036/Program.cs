using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _036
{
    /// <summary>
    /// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
    /// 
    /// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
    /// 
    /// (Please note that the palindromic number, in either base, may not include leading zeros.)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var sum = Enumerable.Range(1, 1000000)
                .Where(i => i.ToString().IsPalindrome() && Convert.ToString(i, 2).IsPalindrome())
                .Select(i => (long)i)
                .Sum();

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
