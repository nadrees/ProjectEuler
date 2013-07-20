using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _16
{
    /// <summary>
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger integer = new BigInteger(2);
            for (int i = 2; i <= 1000; i++)
                integer *= 2;

            String num = integer.ToString();
            long sum = 0;

            for (int i = 0; i < num.Length; i++)
                sum += (num.ParseDigit(i));

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
