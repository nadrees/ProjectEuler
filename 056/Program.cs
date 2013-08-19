using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _056
{
    /// <summary>
    /// A googol (10100) is a massive number: one followed by one-hundred zeros; 100100 is almost unimaginably large: 
    /// one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.
    /// 
    /// Considering natural numbers of the form, ab, where a, b < 100, what is the maximum digital sum?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var answer = Enumerable.Range(1, 100).SelectMany(a =>
                Enumerable.Range(1, 100).Select(b => a.ToPower(b).ToString().GetDigits().Sum()))
                .Max();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
