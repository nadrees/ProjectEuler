using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _063
{
    /// <summary>
    /// The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.
    /// 
    /// How many n-digit positive integers exist which are also an nth power?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // another way of phrasing the problem is we need to find x such that 10^(n-1) <= x^n < 10^n
            // for a given n, this will include all positive integers of length n

            // ex: for n=3, -> 100 <= x^3 < 1000
            // we know the upper bound, x <= 9 since x^10 will always have 11 digits or more

            // for the lower bound, we need to isolate the left hand portion of the equation:
            // 10^(n-1) <= x^n =>
            // n-1 <= log_10(x)*n =>
            // (n-1)/n <= log_10(x) =>
            // 10^((n-1)/n) <= x

            int result = 0,
                lower = 0,
                n = 1;

            while (lower < 10)
            {
                lower = (int)Math.Ceiling(Math.Pow(10, (n - 1.0) / n));
                result += 10 - lower;
                n++;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
