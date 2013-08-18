using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037
{
    /// <summary>
    /// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, 
    /// and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
    /// 
    /// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
    /// 
    /// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var primeGenerator = new CachedPrimeNumberGenerator(new SievePrimeNumberGenerator());

            var primes = primeGenerator.GetPrimesBelowLongMaxValue();

            long[] results = new long[11];
            int index = 0;

            foreach (var prime in primes.SkipWhile(p => p <= 7))
            {
                if (IsTruncatableLeft(prime, primeGenerator) &&
                    IsTruncatableRight(prime, primeGenerator))
                {
                    results[index++] = prime;
                    Console.WriteLine("Found {0} ({1}/11)", prime, index);
                    if (index == 11)
                        break;
                }
            }

            Console.WriteLine(results.Sum());
            Console.ReadKey();
        }

        private static bool IsTruncatableLeft(long prime, IPrimeNumberGenerator primeGenerator)
        {
            var primes = primeGenerator
                .GetPrimesBelowLongMaxValue()
                .TakeWhile(p => p <= prime)
                .ToList();

            var str = prime.ToString();
            while (str.Length > 1)
            {
                str = str.Substring(1);
                long num = long.Parse(str);
                if (!primes.Contains(num))
                    return false;
            }
            return true;
        }

        private static bool IsTruncatableRight(long prime, IPrimeNumberGenerator primeGenerator)
        {
            var primes = primeGenerator
                .GetPrimesBelowLongMaxValue()
                .TakeWhile(p => p <= prime)
                .ToList();

            var str = prime.ToString();
            while (str.Length > 1)
            {
                str = str.Substring(0, str.Length - 1);
                long num = long.Parse(str);
                if (!primes.Contains(num))
                    return false;
            }
            return true;
        }
    }
}
