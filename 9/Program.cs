using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    /// <summary>
    /// A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,
    /// a^2 + b^2 = c^2
    /// 
    /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
    /// 
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Pythagorean theorem: a^2 + b^2 = c^2
            // want a + b + c = 1000

            // c = 1000 - (a + b)
            // a^2 + b^2 = (1000 - (a + b))^2 (substituting c in to pythagorean theorem)
            // a^2 + b^2 = (1000 - (a + b))(1000 - (a + b))
            // a^2 + b^2 = 1000000 - 2000(a + b) + (a + b)(a + b)
            // a^2 + b^2 = 1000000 - 2000(a + b) + a^2 + 2ab + b^2
            
            // 0 = 1000000 - 2000(a + b) + 2ab
            // 2000(a + b) - 2ab = 1000000
            // 1000(a + b) - ab = 500000
            // 1000a + 1000b - ab = 500000
            // a(1000 - b) + 1000b = 500000
            // a(1000 - b) = 500000 - 1000b
            // a = (500000 - 1000b)/(1000 - b)

            // try lots of b's up to 1000 and see if a is an int.

            for (int b = 1; b <= 1000; b++)
            {
                var a = (500000d - (1000d * b)) / (1000d - b);
                if (a == Math.Floor(a))
                {
                    // found a and b, find c
                    // from original equation a + b + c = 1000
                    var c = 1000 - a - b;

                    Console.WriteLine(a*b*c);
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
