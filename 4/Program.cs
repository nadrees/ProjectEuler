using Lib;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
    /// 
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var answer = ProductGenerator.GenerateProducts(999)
                .Where(p => p.ToString().IsPalindrome())
                .Max();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
