using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033
{
    /// <summary>
    /// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to 
    /// simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
    /// 
    /// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    /// 
    /// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    /// 
    /// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Fraction(1, 1);

            for (int denom = 10; denom < 100; denom++)
            {
                for (int num = 10; num < denom; num++)
                {
                    if (denom % 10 == 0 && num % 10 == 0)
                        continue; // trivial case
                    else if (num % 10 == denom / 10)
                    {
                        var actual = (num * 1.0) / denom;
                        var other = (num / 10 * 1.0) / (denom % 10);

                        if (Math.Abs(actual - other) <= double.Epsilon)
                        {
                            var fraction = new Fraction(num, denom);
                            Console.WriteLine("Found {0}", fraction);
                            product *= fraction;
                        }
                    }
                }
            }

            Console.WriteLine(product.Denominator);
            Console.ReadKey();
        }
    }
}
