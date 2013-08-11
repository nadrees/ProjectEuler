﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;
using Lib;

namespace _042
{
    /// <summary>
    /// The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:
    /// 
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. 
    /// For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.
    /// 
    /// Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var count = File.ReadAllText(@"words.txt")
                .Split(',')
                .Select(t => t.Trim(' ', '"').GetAlphabetScore())
                .Where(s => IsTriangleNumber(s))
                .Count();

            Console.WriteLine(count);
            Console.ReadKey();
        }

        private static IEnumerable<long> triangleNums = new List<long>();
        private static bool IsTriangleNumber(int s)
        {
            if (triangleNums.Count() == 0 || triangleNums.Max() < s)
                triangleNums = TriangleNumberGenerator.Generate().TakeWhile(n => n <= s).ToList();

            return triangleNums.Contains(s);
        }
    }
}