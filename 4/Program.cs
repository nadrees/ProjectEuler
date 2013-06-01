using Lib;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = ProductGenerator.GenerateProducts(999)
                .Where(p => p.ToString().IsPalindrome())
                .Max();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
