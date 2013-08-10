﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _023
{
    /// <summary>
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    /// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// 
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// 
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
    /// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
    /// However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as 
    /// the sum of two abundant numbers is less than this limit.
    /// 
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var sum = Enumerable.Range(1, 28123)
                .Where(i => !IsSumOfTwoAbundantNumbers(i))
                .Sum();

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static bool IsSumOfTwoAbundantNumbers(int num)
        {
            for (int i = num - 1; i > (num - 1) / 2; i--)
            {
                var other = num - i;
                if (i.GetAbundancy() == NumberAbundancy.Abundant &&
                    other.GetAbundancy() == NumberAbundancy.Abundant)
                    return true;
            }
            return false;
        }
    }
}
