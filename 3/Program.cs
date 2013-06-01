using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// 
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            long target = 600851475143;
            var primeFactors = target.PrimeFactorize();

            Console.WriteLine(primeFactors.Max());
            Console.ReadKey();
        }
    }
}
