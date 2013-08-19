using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _041
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
    /// 
    /// What is the largest n-digit pandigital prime that exists?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = Stopwatch.StartNew();
            var primes = new SievePrimeNumberGenerator().GetPrimesBelowLongMaxValue().TakeWhile(p => p <= 98765432).Reverse();

            foreach (var prime in primes)
            {
                var primeStr = prime.ToString();

                if (primeStr.IsPandigital(primeStr.Length))
                {
                    Console.WriteLine(prime);
                    break;
                }
            }

            s.Stop();

            Console.WriteLine(s.Elapsed);
            Console.ReadKey();
        }
    }
}
