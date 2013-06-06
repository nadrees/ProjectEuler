using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Collatz
    {
        private Dictionary<long, int> chainLengths = new Dictionary<long, int> { { 1, 1 } };

        public int CollatzChainLengthOf(long num)
        {
            if (!chainLengths.ContainsKey(num))
            {
                long nextNum = (num % 2 == 0 ? num / 2 : (3 * num) + 1);
                var chainLength = CollatzChainLengthOf(nextNum);
                chainLengths.Add(num, chainLength + 1);
            }

            return chainLengths[num];
        }
    }
}
