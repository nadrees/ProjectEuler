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

        public IEnumerable<long> GetPrimesBelowLongMaxValue()
        {
            var primes = GetPrimesBelowIntMaxValue().Select(i => (long)i).ToList();
            foreach (var prime in primes)
                yield return prime;

            var num = primes.Last();
            if (num % 2 == 0)
                num += 1;

            while (num <= maxLongPrime)
            {
                if (IsPrime(num, primes))
                {
                    yield return num;
                    primes.Add(num);
                }

                num += 2;
            }
        }

        private bool IsPrime(long num, List<long> primes)
        {
            foreach (var prime in primes)
            {
                if (num % prime == 0)
                    return false;
            }
            return true;
        }
    }
}
