using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = Enumerable.Range(0, 1000).Where(i => i % 3 == 0 || i % 5 == 0).Sum();
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
