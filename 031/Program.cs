using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    /// 
    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    /// 
    /// It is possible to make £2 in the following way:
    /// 
    /// 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    /// 
    /// How many different ways can £2 be made using any number of coins?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // basic idea: at every level, calculate how many of that coin you can use without going over 200 pence
            // then unwind one coin at a time and reprocess lower levels
            // inner most loop counts the number of comibindations

            int count = 0;

            foreach (var twoPound in GetTwoPoundValues())
                foreach (var onePound in GetOnePoundValues(twoPound))
                    foreach (var fiftyPence in GetFiftyPenceValues(twoPound, onePound))
                        foreach (var twentyPence in GetTwentyPenceValues(twoPound, onePound, fiftyPence))
                            foreach (var tenPence in GetTenPenceValues(twoPound, onePound, fiftyPence, twentyPence))
                                foreach (var fivePence in GetFivePenceValues(twoPound, onePound, fiftyPence, twentyPence, tenPence))
                                    foreach (var twoPence in GetTwoPenceValues(twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence))
                                        foreach (var onePence in GetOnePenceValues(twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence, twoPence))
                                        {
                                            Console.WriteLine(String.Format("{0}x2P, {1}x1P, {2}x50p, {3}x20p, {4}x10p, {5}x5p, {6}x2p, {7}x1p",
                                                twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence, twoPence, onePence));
                                            count++;
                                        }

            Console.WriteLine(count);
            Console.ReadKey();
        }

        private static IEnumerable<int> GetOnePenceValues(int twoPound, int onePound, int fiftyPence, int twentyPence, int tenPence, int fivePence, int twoPence)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence, twoPence);

            int count = 200 - currentAmount;

            yield return count;
        }

        private static IEnumerable<int> GetTwoPenceValues(int twoPound, int onePound, int fiftyPence, int twentyPence, int tenPence, int fivePence)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound, fiftyPence, twentyPence, tenPence, fivePence);

            int count = (200 - currentAmount) / 2;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetFivePenceValues(int twoPound, int onePound, int fiftyPence, int twentyPence, int tenPence)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound, fiftyPence, twentyPence, tenPence);

            int count = (200 - currentAmount) / 5;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetTenPenceValues(int twoPound, int onePound, int fiftyPence, int twentyPence)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound, fiftyPence, twentyPence);

            int count = (200 - currentAmount) / 10;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetTwentyPenceValues(int twoPound, int onePound, int fiftyPence)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound, fiftyPence);

            int count = (200 - currentAmount) / 20;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetFiftyPenceValues(int twoPound, int onePound)
        {
            var currentAmount = GetCurrentAmount(twoPound, onePound);

            int count = (200 - currentAmount) / 50;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetOnePoundValues(int twoPound)
        {
            var currentAmount = GetCurrentAmount(twoPound);

            int count = (200 - currentAmount) / 100;

            while (count >= 0)
                yield return count--;
        }

        private static IEnumerable<int> GetTwoPoundValues()
        {
            yield return 1;
            yield return 0;
        }

        private static int GetCurrentAmount(int twoPound = 0, int onePound = 0, int fiftyPence = 0, int twentyPence = 0, int tenPence = 0, int fivePence = 0, int twoPence = 0)
        {
            return twoPound * 200 + onePound * 100 + fiftyPence * 50 + twentyPence * 20 + tenPence * 10 + fivePence * 5 + twoPence * 2;
        }
    }
}
