using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _020
{
    /// <summary>
    /// n! means n × (n − 1) × ... × 3 × 2 × 1
    /// 
    /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    /// 
    /// Find the sum of the digits in the number 100!
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = new BigInteger(100);
            for (int i = 99; i > 0; i--)
                num *= i;

            var str = num.ToString();

            int sum = 0;
            for (int i = 0; i < str.Length; i++)
                sum += str.ParseDigit(i);

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
