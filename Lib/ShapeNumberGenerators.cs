using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class TriangleNumberGenerator
    {
        public static IEnumerable<ulong> Generate()
        {
            ulong lastValue = 0;

            for (ulong i = 1; i < ulong.MaxValue; i++)
            {
                lastValue += i;
                yield return lastValue;
            }
        }
    }
}
