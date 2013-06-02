using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class SievePrimeNumberGenerator
    {
        private static readonly int maxIntPrime = (int)Math.Floor(Math.Sqrt(int.MaxValue));

        public static IEnumerable<int> GetPrimesBelowIntMaxValue()
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

                    for (int i = pointer + pointer; i <= maxIntPrime; i += pointer)
                        potentialPrimes[i] = false;
                }
            }
            while (++pointer < potentialPrimes.Length);
        }

        private static readonly long maxLongPrime = (long)Math.Floor(Math.Sqrt(long.MaxValue));
        private static readonly int rowSize = 2000000;
        private static readonly int numRowsNeeded = (int)Math.Ceiling(maxLongPrime / (double)rowSize);
        public static IEnumerable<long> GetPrimesBelowLongMaxValue()
        {
            List<long> primesFound = new List<long>();
            for (int rowIndex = 0; rowIndex < numRowsNeeded; rowIndex++)
            {
                bool[] potentialPrimes = InitializeArray(primesFound, rowIndex);

                for (int i = (rowIndex == 0 ? 2 : 0); i < potentialPrimes.Length; i++)
                {
                    if (potentialPrimes[i])
                    {
                        var prime = GetLongValue(i, rowIndex);
                        yield return prime;

                        primesFound.Add(prime);
                        MarkMultiplesNotPrime(potentialPrimes, prime, rowIndex);
                    }
                }
            }
        }

        private static void MarkMultiplesNotPrime(bool[] potentialPrimes, long prime, int rowIndex)
        {
            var minPotentialPrimeValue = GetMinPotentialPrimeValue(rowIndex);
            var valueToMultiply = (long)Math.Floor((double)minPotentialPrimeValue / prime);

            var maxPotentialPrimeValue = GetMaxPotentialPrimeValue(rowIndex);
            for (long current = prime * valueToMultiply, index = GetIndexPosition(current, rowIndex); index < potentialPrimes.Length; 
                current += prime, index = GetIndexPosition(current, rowIndex))
            {
                if (current < minPotentialPrimeValue)
                    continue;

                potentialPrimes[index] = false;
            }
        }

        private static int GetIndexPosition(long num, int rowIndex)
        {
            return (int)(num - GetMinPotentialPrimeValue(rowIndex));
        }

        private static long GetLongValue(int i, int rowIndex)
        {
            return ((long)rowIndex * rowSize) + i;
        }

        private static long GetMinPotentialPrimeValue(int rowIndex)
        {
            return (long)rowSize * rowIndex;
        }

        private static long GetMaxPotentialPrimeValue(int rowIndex)
        {
            return GetMinPotentialPrimeValue(rowIndex) + rowSize - 1;
        }

        private static bool[] InitializeArray(List<long> primesFound, int rowIndex)
        {
            bool[] potentialPrimes = new bool[rowSize];
            for (int i = 0; i < potentialPrimes.Length; i++)
                potentialPrimes[i] = true;

            var minPotentialPrimeValue = GetMinPotentialPrimeValue(rowIndex);
            var maxPotentialPrimevalue = GetMaxPotentialPrimeValue(rowIndex);

            foreach (var prime in primesFound)
                MarkMultiplesNotPrime(potentialPrimes, prime, rowIndex);

            return potentialPrimes;
        }
    }
}
