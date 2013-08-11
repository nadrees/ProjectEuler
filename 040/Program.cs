using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _040
{
    /// <summary>
    /// An irrational decimal fraction is created by concatenating the positive integers:
    /// 
    /// 0.123456789101112131415161718192021...
    /// 
    /// It can be seen that the 12th digit of the fractional part is 1.
    /// 
    /// If dn represents the nth digit of the fractional part, find the value of the following expression.
    /// 
    /// d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            int num = 1;
            while (builder.Length < 1000000)
                builder.Append(num++);

            var str = builder.ToString();
            var product = str.ParseDigit(0) * str.ParseDigit(9) * str.ParseDigit(99) * str.ParseDigit(999) * str.ParseDigit(9999) * str.ParseDigit(99999) * str.ParseDigit(999999);

            Console.WriteLine(product);
            Console.ReadKey();
        }
    }
}
