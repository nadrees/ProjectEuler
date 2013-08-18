using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularPrimes = MiscMath.CircularPrimesBelow(1000000);

            Console.WriteLine(circularPrimes.Length);
            Console.ReadKey();
        }
    }
}
