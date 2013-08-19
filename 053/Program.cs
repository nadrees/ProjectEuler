using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _053
{
    /// <summary>
    /// There are exactly ten ways of selecting three from five, 12345:
    /// 
    /// 123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
    /// 
    /// In combinatorics, we use the notation, 5C3 = 10.
    /// 
    /// In general,
    /// 
    /// nCr = n! / r!(n−r)!,
    /// where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
    /// 
    /// It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.
    /// 
    /// How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int n = 23; n <= 100; n++)
            {
                for (int r = (n == 23 ? 10 : 1); r < n; r++)
                {
                    var result = n.Choose(r);
                    if (result > 1000000)
                        count++;
                    else if (r > n / 2)
                        break; // value less than 1 million, and will continue to get smaller as r increases
                }
            }

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
