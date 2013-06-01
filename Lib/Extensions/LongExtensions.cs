using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class LongExtensions
    {
        public static IEnumerable<long> PrimeFactorize(this long value)
        {
            if (value >= 1)
            {
                var primes = new SievePrimeNumberGenerator()
                    .GetPrimesBelowIntMaxValue()
                    .ToList();

                return PrimeFactorize(value, primes);
            }

            return new List<long>();
        }

        private static IEnumerable<long> PrimeFactorize(long value, IEnumerable<int> primes)
        {
            var primeFactors = new List<long>();

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
