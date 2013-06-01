﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
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
