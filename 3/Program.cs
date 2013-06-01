using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
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
