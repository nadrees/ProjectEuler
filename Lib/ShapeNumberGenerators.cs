using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class TriangleNumberGenerator
    {
        public static IEnumerable<BigInteger> Generate()
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                yield return NthNumber(i);
            }
        }

        public static BigInteger NthNumber(int nth)
        {
            var n = new BigInteger(nth);
            return ((n + 1) * n) / 2;
        }
    }

    public class PentagonalNumberGenerator
    {
        public static BigInteger NthNumber(int nth)
        {
            var n = new BigInteger(nth);
            return ((3 * n - 1) * n) / 2;
        }

        public static IEnumerable<BigInteger> Generate()
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                yield return NthNumber(i);
            }
        }
    }

    public class HexagonalNumberGenerator
    {
        public static BigInteger NthNumber(int nth)
        {
            var n = new BigInteger(nth);
            return n * (2 * n - 1);
        }

        public static IEnumerable<BigInteger> Generate()
        {
            for (int i = 1; i < int.MaxValue; i++)
                yield return NthNumber(i);
        }
    }
}
