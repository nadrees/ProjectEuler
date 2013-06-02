using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// 
    /// Find the sum of all the primes below two million.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var primes = SievePrimeNumberGenerator.GetPrimesBelowLongMaxValue()
                .TakeWhile(p => p < 2000000)
                .ToList();

            var sum = primes.Sum();

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
