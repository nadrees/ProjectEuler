using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _081
{
    /// <summary>
    /// In the 5 by 5 matrix below, the minimal path sum from the top left to the bottom right, by only moving to the right and down, 
    /// is indicated in bold red and is equal to 2427.
    /// 
    /// 131	673	234	103	18
    /// 201	96	342	965	150
    /// 630	803	746	422	111
    /// 537	699	497	121	956
    /// 805	732	524	37	331
    /// 
    /// Find the minimal path sum, in matrix.txt (right click and 'Save Link/Target As...'), 
    /// a 31K text file containing a 80 by 80 matrix, from the top left to the bottom right by only moving right and down.
    /// </summary>
    class Program
    {
        private static long[,] minSums = new long[80, 80];
        private static int[][] matrix;

        static void Main(string[] args)
        {
            matrix = File.ReadAllLines(@"matrix.txt").Select(
                l => l.Split(',').Select(n => int.Parse(n)).ToArray()
            ).ToArray();

            minSums[0, 0] = matrix[0][0];

            Console.WriteLine(GetMinSum(79, 79));
            Console.ReadKey();
        }

        private static long GetMinSum(int x, int y)
        {
            if (minSums[x, y] == 0)
            {
                var leftMin = (x == 0 ? long.MaxValue : GetMinSum(x - 1, y));
                var upMin = (y == 0 ? long.MaxValue : GetMinSum(x, y - 1));

                var totalMin = matrix[x][y] + Math.Min(leftMin, upMin);
                minSums[x, y] = totalMin;
            }

            return minSums[x, y];
        }
    }
}
