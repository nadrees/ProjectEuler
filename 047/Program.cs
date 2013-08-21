using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using System.Diagnostics;

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
            var stopwatch = Stopwatch.StartNew();

            int startingNum = 0;
            int count = 0;

            for (int i = 10; i <= int.MaxValue; i++)
            {
                var factors = i.PrimeFactorize(memoize: true).Distinct().ToArray();

                if (factors.Length == 4)
                {
                    count++;
                    if (count == 1)
                        startingNum = i;
                    else if (count == 4)
                        break;
                }
                else
                {
                    count = 0;
                    startingNum = 0;

                    if (i % 1000 == 0)
                    {
                        Console.WriteLine("{0} - {1}", stopwatch.Elapsed, i);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine(startingNum);
            Console.ReadKey();
        }
    }
}
