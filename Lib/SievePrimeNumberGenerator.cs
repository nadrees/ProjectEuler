using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class SievePrimeNumberGenerator
    {
        private static readonly int maxIntPrime = (int)Math.Floor(Math.Sqrt(int.MaxValue));
        private static readonly long maxLongPrime = (long)Math.Floor(Math.Sqrt(long.MaxValue));

        public IEnumerable<int> GetPrimesBelowIntMaxValue()
        {
            bool[] potentialPrimes = new bool[maxIntPrime + 1];
            for (int i = 0; i < potentialPrimes.Length; i++)
                potentialPrimes[i] = true;

            int pointer = 2;

            do
            {
                if (potentialPrimes[pointer])
                {
                    yield return pointer;

                    for (int i = pointer; i <= maxIntPrime; i += pointer)
                        potentialPrimes[i] = false;
                }
            }
            while (++pointer < potentialPrimes.Length);
        }
    }
}
