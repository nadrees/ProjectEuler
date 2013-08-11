using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027
{
    /// <summary>
    /// Euler discovered the remarkable quadratic formula:
    /// 
    /// n² + n + 41
    /// 
    /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
    /// However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
    /// 
    /// The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. 
    /// The product of the coefficients, −79 and 1601, is −126479.
    /// 
    /// Considering quadratics of the form:
    /// 
    /// n² + an + b, where |a| < 1000 and |b| < 1000
    /// 
    /// where |n| is the modulus/absolute value of n
    /// e.g. |11| = 11 and |−4| = 4
    /// 
    /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var max = Enumerable.Range(-999, 1999)
                .SelectMany(a => Enumerable.Range(-999, 1999).Select(b => CountPrimes(a, b)))
                .OrderByDescending(pc => pc.NumPrimes)
                .Select(pc => pc.A * pc.B)
                .First();

            Console.WriteLine(max);
            Console.ReadKey();
        }

        private static CachedPrimeNumberGenerator generator = new CachedPrimeNumberGenerator(new SievePrimeNumberGenerator());
        private static PrimesCount CountPrimes(int a, int b)
        {
            var retVal = new PrimesCount
            {
                NumPrimes = -1,
                A = a,
                B = b
            };

            IEnumerable<long> primes;
            long result = 0;
            int n = 0;

            do
            {
                retVal.NumPrimes++;
                result = n * n + a * n + b;
                primes = generator.GetPrimesBelowLongMaxValue().TakeWhile(p => p <= result);
                n++;
            }
            while (primes.Contains(result));

            return retVal;
        }
    }

    class PrimesCount
    {
        public int NumPrimes { get; set; }
        public int A { get; set; }
        public int B { get; set; }

        public override string ToString()
        {
            return String.Format("A={0}, B={1}, NumPrimes={2}", A, B, NumPrimes);
        }
    }
}
