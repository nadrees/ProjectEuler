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
            return ((long)value).PrimeFactorize().Select(i => (int)i);
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
