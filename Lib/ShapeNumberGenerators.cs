using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class TriangleNumberGenerator
    {
        public static IEnumerable<long> Generate()
        {
            long lastValue = 0;

            for (long i = 1; i < long.MaxValue; i++)
            {
                lastValue += i;
                yield return lastValue;
            }
        }
    }
}
