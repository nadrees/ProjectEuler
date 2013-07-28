using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ProductGenerator
    {
        public static IEnumerable<int> GenerateProducts(int max, int start1 = 1)
        {
            for (int i = start1; i <= max; i++)
                for (int j = i; j <= max; j++)
                    yield return i * j;
        }
    }

    public class FibonacciGenerator
    {
        public static IEnumerable<BigInteger> Generate(bool repeatingOnes = false)
        {
            BigInteger i1 = new BigInteger(1);
            BigInteger i2 = (repeatingOnes ? new BigInteger(1) : new BigInteger(2));

            yield return i1;
            yield return i2;

            while (true)
            {
                var next = i1 + i2;
                yield return next;

                i1 = i2;
                i2 = next;
            }
        }
    }

    public class LongGenerator
    {
        public static IEnumerable<long> Range(long start)
        {
            while (true)
                yield return start++;
        }
    }
}
