﻿using Lib;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    /// <summary>
    /// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// Let us list the factors of the first seven triangle numbers:
    /// 1: 1
    /// 3: 1,3
    /// 6: 1,2,3,6
    /// 10: 1,2,5,10
    /// 15: 1,3,5,15
    /// 21: 1,3,7,21
    /// 28: 1,2,4,7,14,28
    /// 
    /// We can see that 28 is the first triangle number to have over five divisors.
    /// 
    /// What is the value of the first triangle number to have over five hundred divisors?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // for this problem, we don't need to know the actual divisors, only the number of them
            // if you factor a number in to its prime factors, you can calculate the number of divisors
            var triangleNumbers = TriangleNumberGenerator.Generate()
                .Select(l => 
                {
                    var numberOfFactors = long.Parse(l.ToString()).Factorize().Count();
                    Console.WriteLine(String.Format("{0} {1}", l, numberOfFactors));

                    return new
                    {
                        l = l,
                        numFactors = numberOfFactors
                    };
                })
                .Where(l => l.numFactors > 500)
                .FirstOrDefault();

            Console.WriteLine(triangleNumbers);
            Console.ReadKey();
        }
    }
}
