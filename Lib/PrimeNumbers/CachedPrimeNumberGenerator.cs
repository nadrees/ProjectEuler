using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.PrimeNumbers
{
    public class CachedPrimeNumberGenerator : IPrimeNumberGenerator
    {
        private IPrimeNumberGenerator generator;
        private List<long> primes = new List<long>();

        public CachedPrimeNumberGenerator(IPrimeNumberGenerator generator)
        {
            this.generator = generator;
        }

        public IEnumerable<int> GetPrimesBelowIntMaxValue()
        {
            foreach (var prime in GetPrimesBelowLongMaxValue())
            {
                if (prime < int.MaxValue)
                    yield return (int)prime;
                else
                    break;
            }
        }

        public IEnumerable<long> GetPrimesBelowLongMaxValue()
        {
            foreach (var prime in primes)
                yield return prime;

            foreach (var prime in generator.GetPrimesBelowLongMaxValue().Skip(primes.Count))
            {
                primes.Add(prime);
                yield return prime;
            }
        }
    }
}
