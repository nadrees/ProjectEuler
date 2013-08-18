using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _039
{
    /// <summary>
    /// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
    /// 
    /// {20,48,52}, {24,45,51}, {30,40,50}
    /// 
    /// For which value of p ≤ 1000, is the number of solutions maximised?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // p = a + b + c
            // a^2 + b^2 = c^2

            // c = p - a - b
            // a^2 + b^2 = (p - a - b)^2 = p^2 + a^2 + b^2 - 2pa - 2pb + 2ab
            
            // b^2 = p^2 + b^2 - 2pa - 2pb + 2ab
            // 0 = p^2 - 2pa - 2pb + 2ab
            // 2pb - 2ab = p^2 - 2pa
            // pb - ab = (p^2 - 2pa) / 2
            // b(p - a) = (p^2 - 2pa) / 2
            // b = (p^2 - 2pa) / 2(p-a)
            // b = (p^2 - 2pa) / (2p - 2a)

            var answer = Enumerable.Range(2, 999).Select(p =>
            {
                int numSolutions = 0;
                for (int a = 2; a < p; a++)
                {
                    long numerator = (p * p) - (2 * p * a),
                         denominator = (2 * p) - (2 * a);
                    if (numerator % denominator == 0)
                        numSolutions++;
                }

                return new { p = p, numSolutions = numSolutions };
            })
            .OrderByDescending(r => r.numSolutions)
            .Select(r => r.p)
            .First();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
