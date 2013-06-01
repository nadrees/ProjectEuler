using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class IntegerExtensions
    {
        public static IEnumerable<int> PrimeFactorize(this int value)
        {
            if (value >= 1)
            {
                var primes = new SievePrimeNumberGenerator()
                    .GetPrimesBelowIntMaxValue()
                    .ToList();

                return PrimeFactorize(value, primes);
            }

            return new List<int>();
        }

        private static IEnumerable<int> PrimeFactorize(int value, IEnumerable<int> primes)
        {
            var primeFactors = new List<int>();

            foreach (var prime in primes)
            {
                if (value % prime == 0)
                {
                    var remainder = value / prime;

                    if (remainder >= 2)
                        primeFactors = PrimeFactorize(remainder, primes.Where(p => p <= remainder)).ToList();

                    primeFactors.Add(prime);
                    break;
                }
            }

            return primeFactors;
        }
    }
}
