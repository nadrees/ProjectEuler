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

            Parallel.ForEach(Enumerable.Range(1000, 1000000),
                (n, loopState) =>
                {
                    if (n % 1000 == 0)
                        Console.WriteLine("{0} - {1}", stopwatch.Elapsed, n);

                    for (int i = 0; i < 4; i++)
                    {
                        var factors = (n + i).PrimeFactorize().Distinct().ToArray();

                        if (factors.Length != 4)
                            return;
                    }

                    Console.WriteLine(n);

                    loopState.Break();
                }
            );

            stopwatch.Stop();
            Console.ReadKey();
        }
    }
}
