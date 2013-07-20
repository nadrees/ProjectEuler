using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _046
{
    /// <summary>
    /// It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
    /// 
    /// 9 = 7 + 2 × 1^2
    /// 15 = 7 + 2 × 2^2
    /// 21 = 3 + 2 × 3^2
    /// 25 = 7 + 2 × 3^2
    /// 27 = 19 + 2 × 2^2
    /// 33 = 31 + 2 × 1^2
    /// 
    /// It turns out that the conjecture was false.
    /// 
    /// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CachedPrimeNumberGenerator generator = new CachedPrimeNumberGenerator(new SievePrimeNumberGenerator());

            int current = 9;
            while (true)
            {
                var primes = generator.GetPrimesBelowLongMaxValue().TakeWhile(p => p <= current).ToList();

                if (!primes.Contains(current))
                {
                    if (!IsGoldbachComposit(primes, current))
                    {
                        Console.WriteLine(current);
                        Console.ReadKey();
                        break;
                    }
                }
                
                current += 2;
            }
        }

        private static bool IsGoldbachComposit(IList<long> primes, int current)
        {
            foreach (var prime in primes)
            {
                foreach (var d in Enumerable.Range(1, current - 1))
                {
                    var composite = prime + (2 * (d * d));
                    if (composite == current)
                        return true;
                    else if (composite > current)
                        break;
                }
            }
            return false;
        }
    }
}
