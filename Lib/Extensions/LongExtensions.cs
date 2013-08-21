using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class LongExtensions
    {
        private static IPrimeNumberGenerator generator = new CachedPrimeNumberGenerator(new SievePrimeNumberGenerator());
        private static Object lockObj = new Object();

        public static IEnumerable<long> PrimeFactorize(this long value)
        {
            long[] primes;

            lock (lockObj)
            {
                primes = generator.GetPrimesBelowLongMaxValue().TakeWhile(p => p <= value).ToArray();
            }

            return PrimeFactorize(value, primes);
        }

        public static IEnumerable<long> PrimeFactorize(long value, long[] primes)
        {
            if (primes.Contains(value))
                return new[] { value };

            var primeFactors = new List<long>();

            if (value >= 2)
            {
                foreach (var prime in primes)
                {
                    while (value % prime == 0)
                    {
                        primeFactors.Add(prime);
                        value /= prime;
                    }

                    if (value < 2)
                        break;
                }
            }

            return primeFactors;
        }

        public static IEnumerable<long> Factorize(this long value)
        {
            if (value >= 1)
            {
                var limit = Math.Sqrt(value);

                for (int i = 1; i <= limit; i++)
                {
                    if (value % i == 0)
                    {
                        yield return i;

                        if (i * i != value)
                            yield return value / i;
                    }
                }
            }
        }
    }
}
