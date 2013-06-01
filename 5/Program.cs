using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// 
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
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
