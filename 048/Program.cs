using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _048
{
    /// <summary>
    /// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
    /// 
    /// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var num = (from a in Enumerable.Range(1, 1000)
                       select a.ToPower(a))
                      .Aggregate(new BigInteger(0), (sum, next) => sum + next)
                      .ToString();

            Console.WriteLine(num.Substring(num.Length - 10));
            Console.ReadKey();
        }
    }
}
