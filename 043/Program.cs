using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using System.Numerics;

namespace _043
{
    /// <summary>
    /// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 
    /// 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
    /// 
    /// Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
    /// 
    /// d2d3d4=406 is divisible by 2
    /// d3d4d5=063 is divisible by 3
    /// d4d5d6=635 is divisible by 5
    /// d5d6d7=357 is divisible by 7
    /// d6d7d8=572 is divisible by 11
    /// d7d8d9=728 is divisible by 13
    /// d8d9d10=289 is divisible by 17
    /// 
    /// Find the sum of all 0 to 9 pandigital numbers with this property.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var answer = (from permutation in "0123456789".GeneratePermutations()
                          where IsDivisible(permutation, 1, 2) &&
                                IsDivisible(permutation, 2, 3) &&
                                IsDivisible(permutation, 3, 5) &&
                                IsDivisible(permutation, 4, 7) &&
                                IsDivisible(permutation, 5, 11) &&
                                IsDivisible(permutation, 6, 13) &&
                                IsDivisible(permutation, 7, 17)
                          select long.Parse(permutation))
                         .Aggregate(new BigInteger(0), (sum, next) => sum + next);

            Console.WriteLine(answer);
            Console.ReadKey();
        }

        private static bool IsDivisible(String numStr, int start, int divisor)
        {
            var num = String.Empty;
            for (int offset = 0; offset < 3; offset++)
                num += numStr.ParseDigit(offset + start);

            return int.Parse(num) % divisor == 0;
        }
    }
}
