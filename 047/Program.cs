using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using System.Diagnostics;
using Lib.PrimeNumbers;

namespace _047
{
    /// <summary>
    /// The first two consecutive numbers to have two distinct prime factors are:
    /// 
    /// 14 = 2 × 7
    /// 15 = 3 × 5
    /// 
    /// The first three consecutive numbers to have three distinct prime factors are:
    /// 
    /// 644 = 2² × 7 × 23
    /// 645 = 3 × 5 × 43
    /// 646 = 2 × 17 × 19.
    /// 
    /// Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = 1000000;
            int[] nums = new int[upperBound];

            var primes = new SievePrimeNumberGenerator().GetPrimesBelowIntMaxValue().TakeWhile(p => p <= upperBound);

            // for each multiple of a prime, increment it's count by 1 (we found another prime divisor of it)
            foreach (var prime in primes)
            {
                var num = prime + prime;
                while (num < nums.Length)
                {
                    nums[num]++;
                    num += prime;
                }
            }

            // find the first set of 4 4s
            int start = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 4)
                {
                    count++;
                    if (count == 1)
                        start = i;
                    else if (count == 4)
                    {
                        Console.WriteLine(start);
                        break;
                    }
                }
                else
                {
                    start = 0;
                    count = 0;
                }
            }


            Console.ReadKey();
        }
    }
}
