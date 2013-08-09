using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028
{
    /// <summary>
    /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
    /// 
    /// 21 22 23 24 25
    /// 20  7  8  9 10
    /// 19  6  1  2 11
    /// 18  5  4  3 12
    /// 17 16 15 14 13
    /// 
    /// It can be verified that the sum of the numbers on the diagonals is 101.
    /// 
    /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // let n = which ring we're on, where n=0 is the middle most ring
            // then n = 0 --> 1
            // and n = 1 --> 
            //  7 8 9
            //  6   2
            //  5 4 3

            // let value(n) = the sum of the corners of the ring
            // then value(0) = 1
            // and value(1) = 9 + 7 + 5 + 3 = 24

            // a side of a given ring is 2n+1 number wide,
            // the upper right corner is = area of the square --> upper right corner = (2n+1)^2
            // upper left corner is = upper right corner - 2n = (2n+1)^2 - 2n
            // bottom left corner is = upper left corner - 2n = (2n+1)^2 - 4n
            // bottom right corner is = bottom left corner - 2n = (2n+1)^2 - 6n
            // value(n) = upper right corner + upper left corner + bottom left corner + bottom right corner = 
            //    (2n+1)^2 + (2n+1)^2 - 2n + (2n+1)^2 - 4n + (2n+1)^2 - 6n =
            //    4(2n+1)^2 - 12n
            
            // number of n needed to make 1001x1001 grid is 1001 = 2n + 1 --> 500

            var result = Enumerable
                .Range(0, 501)
                .Select(i => Value(i))
                .Sum();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static int Value(int n)
        {
            if (n == 0)
                return 1;
            return (4 * (2 * n + 1) * (2 * n + 1)) - (12 * n);
        }
    }
}
