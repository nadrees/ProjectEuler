using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class ArrayExtensions
    {
        public static long MaxProductOfLength(this int[][] grid, int length)
        {
            long maxPrime = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid.Length; column++)
                {
                    long rightProduct = 1, downProduct = 1, diagDownProduct = 1, diagUpProduct = 1;

                    for (int k = 0; k < length; k++)
                    {
                        if (column <= grid.Length - length)
                            rightProduct *= grid[row][column + k];

                        if (row <= grid.Length - length)
                            downProduct *= grid[row + k][column];

                        if (column <= grid.Length - length && row <= grid.Length - length)
                            diagDownProduct *= grid[row + k][column + k];

                        if (row >= length && column <= grid.Length - length)
                            diagUpProduct *= grid[row - k][column + k];
                    }

                    maxPrime = Math.Max(maxPrime, Math.Max(rightProduct, Math.Max(downProduct, Math.Max(diagUpProduct, diagDownProduct))));
                }
            }

            return maxPrime;
        }
    }
}
