using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _038
{
    class Program
    {
        static void Main(string[] args)
        {
            long largest = 0;

            for (int i = 1; i < 10000; i++)
            {
                String current = String.Empty;

                int nextMultiplier = 1;
                while (current.Length < 9)
                {
                    long product = i * (nextMultiplier++);
                    current += product.ToString();
                }

                if (nextMultiplier > 1 && current.IsPandigital())
                {
                    var l = long.Parse(current);
                    Console.WriteLine("Found pandigital: {0}", l);

                    if (l > largest)
                        largest = l;
                }
            }

            Console.WriteLine(largest);
            Console.ReadKey();
        }
    }
}
