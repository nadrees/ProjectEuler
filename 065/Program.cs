using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using System.Numerics;

namespace _065
{
    /// <summary>
    /// The square root of 2 can be written as an infinite continued fraction.
    /// 
    /// √2 = 1 + (1 / (2 + 1 / (2 +	1 / (2 + 1 / (2 + ... )))))
    /// 
    /// The infinite continued fraction can be written, √2 = [1;(2)], (2) indicates that 2 repeats ad infinitum. In a similar way, √23 = [4;(1,3,1,8)].
    /// 
    /// It turns out that the sequence of partial values of continued fractions for square roots provide the best rational approximations. Let us consider the convergents for √2.
    /// 1 +	1 / 2 = 3/2
    /// 1 + 1 / (2 + 1 / 2) = 7/5
    /// 1 + 1 / (2 + 1 / (2 + 1 / 2)) = 17/12
    /// 1 + 1 / (2 + 1 / (2 + 1 / (2 + 1 / 2))) = 41/29
    /// 
    /// Hence the sequence of the first ten convergents for √2 are:
    /// 1, 3/2, 7/5, 17/12, 41/29, 99/70, 239/169, 577/408, 1393/985, 3363/2378, ...
    /// 
    /// What is most surprising is that the important mathematical constant,
    /// e = [2; 1,2,1, 1,4,1, 1,6,1 , ... , 1,2k,1, ...].
    /// 
    /// The first ten terms in the sequence of convergents for e are:
    /// 2, 3, 8/3, 11/4, 19/7, 87/32, 106/39, 193/71, 1264/465, 1457/536, ...
    /// 
    /// The sum of digits in the numerator of the 10th convergent is 1+4+5+7=17.
    /// 
    /// Find the sum of digits in the numerator of the 100th convergent of the continued fraction for e.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var numerator = GetNumerator().ToString();

            int sum = 0;
            for (int i = 0; i < numerator.Length; i++)
                sum += numerator.ParseDigit(i);

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static BigInteger GetNumerator()
        {
            // only care about numerator
            // numerator takes form n_k = a_k * n_(k-1) + n_(k-2)

            BigInteger n = 2;

            BigInteger n_1 = 1;
            BigInteger n_2;

            for (int i = 2; i <= 100; i++)
            {
                BigInteger current;

                if (i % 3 == 0)
                    current = 2 * (i / 3);
                else
                    current = 1;

                n_2 = n_1;
                n_1 = n;
                n = current * n_1 + n_2;
            }

            return n;
        }
    }
}
