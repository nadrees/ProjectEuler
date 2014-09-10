using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _057
{
    /// <summary>
    /// It is possible to show that the square root of two can be expressed as an infinite continued fraction.
    /// 
    /// √ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...
    /// 
    /// By expanding this for the first four iterations, we get:
    /// 
    /// 1 + 1/2 = 3/2 = 1.5
    /// 1 + 1/(2 + 1/2) = 7/5 = 1.4
    /// 1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
    /// 1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
    /// 
    /// The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example 
    /// where the number of digits in the numerator exceeds the number of digits in the denominator.
    /// 
    /// In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // numerators = 3, 7, 17, 41, ... -> n_(k+1) = 2*d_k + n_k
            // denominator = 2, 5, 12, 29, ... -> d_(k+1) = d_k + n_k

            var numerator = new BigInteger(3);
            var denominator = new BigInteger(2);

            var counter = 0;

            for (var i = 0; i < 1000; i++)
            {
                if (numerator.ToString().Length > denominator.ToString().Length)
                    counter++;

                var nextNumerator = 2 * denominator + numerator;
                var nextDenominator = numerator + denominator;

                numerator = nextNumerator;
                denominator = nextDenominator;
            }

            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
