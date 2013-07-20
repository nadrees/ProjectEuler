using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _032
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    /// 
    /// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    /// 
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    /// 
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (var i in Enumerable.Range(2, 100))
            {
                var start = 1234;
                if (i > 9)
                    start = 123;
                foreach (var j in Enumerable.Range(start, 10000 / i + 1))
                {
                    var num = String.Format("{0}{1}{2}", i, j, i * j);
                    if (num.IsPandigital())
                        set.Add(i * j);
                }
            }

            Console.WriteLine(set.Sum());
            Console.ReadKey();
        }
    }
}
