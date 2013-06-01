using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2520; true; i++)
            {
                if (IsEvenlyDivisible(i))
                {
                    Console.WriteLine(i);
                    Console.ReadKey();
                    break;
                }
            }
        }

        private static bool IsEvenlyDivisible(int num)
        {
            for (int i = 2; i <= 20; i++)
            {
                if (num % i != 0)
                    return false;
            }
            return true;
        }
    }
}
