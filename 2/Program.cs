using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = FibonacciGenerator.Generate()
                .TakeWhile((value) => value <= 4000000)
                .Where(v => v % 2 == 0)
                .Select(v => (int)v)
                .Sum();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
