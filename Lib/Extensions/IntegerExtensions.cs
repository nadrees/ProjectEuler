using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                var primes = SievePrimeNumberGenerator
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

        public static BigInteger SumOfSquares(this int n)
        {
            return Enumerable.Range(1, n)
                .Select(i => new BigInteger(i))
                .Select(bi => bi * bi)
                .Aggregate(new BigInteger(0), (sum, bi) => sum += bi);
        }

        public static BigInteger SquareOfSum(this int n)
        {
            var sum = Enumerable.Range(1, n)
                .Select(i => new BigInteger(i))
                .Aggregate(new BigInteger(0), (s, bi) => s += bi);
            return sum * sum;
        }
    }
}
