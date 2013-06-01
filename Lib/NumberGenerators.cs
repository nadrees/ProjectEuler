using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class FibonacciGenerator
    {
        public static IEnumerable<uint> Generate()
        {
            uint i1 = 1;
            uint i2 = 2;

            yield return i1;
            yield return i2;

            while (true)
            {
                uint next = i1 + i2;
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
