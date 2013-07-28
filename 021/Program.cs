using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _021
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// 
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// 
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// 
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    class Program
    {
        private static Dictionary<int, int> divisorSums = new Dictionary<int, int>
        {
            { 1, 1 },
            { 2, 1 },
            { 3, 1 }
        };

        static void Main(string[] args)
        {
            var amicableNumbers = new List<int>();
            var queue = new Queue<int>(Enumerable.Range(4, 10000));
            
            while (queue.Count > 0)
            {
                var a = queue.Dequeue();
                if (amicableNumbers.Contains(a))
                    continue;

                var b = d(a);

                if (b > 0 && a != b && d(b) == a)
                {
                    Console.WriteLine("Found pair: {0} & {1}", a, b);

                    amicableNumbers.Add(a);
                    amicableNumbers.Add(b);
                }
            }

            Console.WriteLine(amicableNumbers.Sum());
            Console.ReadKey();
        }

        private static int d(int num)
        {
            if (!divisorSums.ContainsKey(num))
            {
                var sum = num.GetAllDivisors().Sum();
                divisorSums.Add(num, sum);
            }

            return divisorSums[num];
        }
    }
}
