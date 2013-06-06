using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class MiscMath
    {
        public static long NumberOfFactors(long l)
        {
            // if n = a^x * b^y * c^z where a, b, c are prime divisors and x, y, z are the number of times those divisors are needed, then
            // num of divisors = (x + 1)(y + 1)(z + 1)

            // get list of prime factors
            var primeFactors = l.PrimeFactorize();
            // count how often(a.k.a. x) each factor(a.k.a. a) appears in the list (a^x)
            var primesCount = from p in primeFactors
                              group p by p into g
                              select g.Count() + 1;
            var numFactors = primesCount.Aggregate(1, (sum, next) => sum *= next);

            return numFactors;
        }
    }
}
