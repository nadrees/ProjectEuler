using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = 100.SquareOfSum() - 100.SumOfSquares();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
