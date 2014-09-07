using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _092
{
    /// <summary>
    /// A number chain is created by continuously adding the square of the digits in a number to form a new number until it has been seen before.
    /// 
    /// For example,
    /// 
    /// 44 → 32 → 13 → 10 → 1 → 1
    /// 85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
    /// 
    /// Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.
    /// 
    /// How many starting numbers below ten million will arrive at 89?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var nums = from i in Enumerable.Range(2, int.MaxValue - 1).TakeWhile(i => i < 10000000)
                       where LastNumberChainNum(i) == 89
                       select i;

            Console.WriteLine(nums.Count());
            Console.ReadKey();
        }

        // memoize answers to avoid solving it again
        private static Dictionary<int, int> lastChainNumberMap = new Dictionary<int, int>
        {
            { 1, 1 },
            { 89, 89 }
        };
        private static int LastNumberChainNum(int num)
        {
            if (!lastChainNumberMap.ContainsKey(num))
            {
                var nextInChain = num.ToString().GetDigits().Select(n => n * n).Sum();
                lastChainNumberMap.Add(num, LastNumberChainNum(nextInChain));
            }

            return lastChainNumberMap[num];
        }
    }
}
