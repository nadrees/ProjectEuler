using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _024
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    /// 
    /// 012   021   102   120   201   210
    /// 
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var permutation = "0123456789".GeneratePermutations()
                .Take(1000000)
                .Distinct()
                .OrderBy(p => p)
                .Last();

            Console.WriteLine(permutation);
            Console.ReadKey();
        }
    }
}
