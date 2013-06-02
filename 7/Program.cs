using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    /// 
    /// What is the 10001st prime number?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var answer = SievePrimeNumberGenerator.GetPrimesBelowLongMaxValue()
                .Take(10001)
                .ToList();

            Console.WriteLine(answer.Last());
            Console.ReadKey();
        }
    }
}
