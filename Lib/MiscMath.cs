﻿using Lib.Extensions;
using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class MiscMath
    {
        public static bool IsLynchrelNumber(int n)
        {
            var num = new BigInteger(n);

            for (int i = 0; i < 50; i++)
            {
                var reversed = BigInteger.Parse(new String(num.ToString().Reverse().ToArray()));
                num += reversed;

                if (num.ToString().IsPalindrome())
                    return false;
            }

            return true;
        }

        public static IEnumerable<long[]> GeneratePythagoreanTriples()
        {
            for (int n = 2; n < int.MaxValue; n++)
            {
                for (int m = 1; m < n; m++)
                {
                    yield return GetPythagoreanTriple(n, m);
                }
            }
        }

        public static long[] GetPythagoreanTriple(int n, int m)
        {
            return new long[] 
            { 
                (n * n) - (m * m), // a
                2 * n * m,  // b
                (n * n) + (m * m) // c
            };
        }

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

        public static int[] CircularPrimesBelow(int l)
        {
            HashSet<int> circularPrimes = new HashSet<int>();

            var primes = new SievePrimeNumberGenerator()
                .GetPrimesBelowIntMaxValue()
                .TakeWhile(p => p < l)
                .ToList();

            foreach (var prime in primes)
            {
                if (!circularPrimes.Contains(prime))
                {
                    var rotations = prime.GetAllRotations();

                    if (AllRotationsArePrime(primes, rotations))
                    {
                        foreach (var rotation in rotations)
                            circularPrimes.Add(rotation);
                    }
                }
            }

            return circularPrimes.ToArray();
        }

        private static bool AllRotationsArePrime(List<int> primes, int[] rotations)
        {
            foreach (var rotation in rotations)
            {
                if (!primes.Contains(rotation))
                    return false;
            }

            return true;
        }
    }
}
