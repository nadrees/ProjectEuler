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

        public static IEnumerable<long> PrimeFactorize(this long value)
        {
            return PrimeFactorize(value, generator);
        }

        public static IEnumerable<long> PrimeFactorize(long value, IPrimeNumberGenerator generator)
        {
            var primeFactors = new List<long>();

            if (value >= 2)
            {
                foreach (var prime in generator.GetPrimesBelowLongMaxValue())
                {
                    if (value % prime == 0)
                    {
                        var remainder = value / prime;

                        if (remainder >= 2)
                            primeFactors = PrimeFactorize(remainder).ToList();

                        primeFactors.Add(prime);
                        break;
                    }
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
