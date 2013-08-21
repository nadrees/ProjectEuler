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

        public static IEnumerable<long> PrimeFactorize(this long value, bool memoize = false)
        {
            return PrimeFactorize(value, generator, memoize);
        }

        private static Dictionary<long, List<long>> memoizedFactors = new Dictionary<long, List<long>>();
        public static IEnumerable<long> PrimeFactorize(long value, IPrimeNumberGenerator generator, bool memoize = false)
        {
            var primeFactors = new List<long>();

            if (memoize && memoizedFactors.ContainsKey(value))
                primeFactors = memoizedFactors[value];
            else
            {
                if (value >= 2)
                {
                    foreach (var prime in generator.GetPrimesBelowLongMaxValue())
                    {
                        if (value % prime == 0)
                        {
                            var remainder = value / prime;

                            if (remainder >= 2)
                                primeFactors = PrimeFactorize(remainder, generator, memoize).ToList();

                            primeFactors.Add(prime);
                            break;
                        }
                    }
                }

                if (memoize)
                    memoizedFactors.Add(value, primeFactors);
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
