using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = new SievePrimeNumberGenerator().GetPrimesBelowLongMaxValue()
                .Take(10001)
                .ToList();

            Console.WriteLine(answer.Last());
            Console.ReadKey();
        }
    }
}
