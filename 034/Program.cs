using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using System.Numerics;

namespace _034
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    /// 
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    /// 
    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var sum = Enumerable.Range(3, 100000)
                .Where(i =>
                {
                    var str = i.ToString();
                    var digitSum = Enumerable.Range(0, str.Length)
                        .Select(index => str.ParseDigit(index).Factorial())
                        .Aggregate(new BigInteger(0), (agg, next) => agg + next);

                    return digitSum.ToString() == str;
                })
                .Sum();

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
