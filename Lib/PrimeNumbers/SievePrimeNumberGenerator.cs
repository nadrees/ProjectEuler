using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.PrimeNumbers
{
    public class SievePrimeNumberGenerator : IPrimeNumberGenerator
    {
        public IEnumerable<int> GetPrimesBelowIntMaxValue()
        {
            foreach (var prime in GetPrimesBelowLongMaxValue())
            {
                if (prime <= int.MaxValue)
                    yield return (int)prime;
                else
                    break;
            }
        }

        private static readonly int rowSize = 2000000;
        private static readonly long numRowsNeeded = (long)Math.Ceiling(long.MaxValue / (double)rowSize);
        public IEnumerable<long> GetPrimesBelowLongMaxValue()
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

        private void MarkMultiplesNotPrime(bool[] potentialPrimes, long prime, int rowIndex)
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

        private int GetIndexPosition(long num, int rowIndex)
        {
            return (int)(num - GetMinPotentialPrimeValue(rowIndex));
        }

        private long GetLongValue(int i, int rowIndex)
        {
            return ((long)rowIndex * rowSize) + i;
        }

        private long GetMinPotentialPrimeValue(int rowIndex)
        {
            return (long)rowSize * rowIndex;
        }

        private long GetMaxPotentialPrimeValue(int rowIndex)
        {
            return GetMinPotentialPrimeValue(rowIndex) + rowSize - 1;
        }

        private bool[] InitializeArray(List<long> primesFound, int rowIndex)
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
