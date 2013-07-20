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

        public static long MaxSum(this int[][] triangle)
        {
            int rows = triangle.Length;

            long?[][] memoizedSums = new long?[rows][];
            for (int i = 0; i < rows; i++)
            {
                int columns = triangle[i].Length;
                memoizedSums[i] = new long?[columns];
            }

            long currentMax = 0;
            int lastRowLength = triangle[rows - 1].Length;
            for (int i = 0; i < lastRowLength; i++)
            {
                long localMax = MaxSum(triangle, memoizedSums, rows - 1, i);
                if (localMax > currentMax)
                    currentMax = localMax;
            }

            return currentMax;
        }

        private static long MaxSum(int[][] triangle, long?[][] memoizedSums, int row, int column)
        {
            if (memoizedSums[row][column] == null)
            {
                long sum = 0;

                if (row == 0)
                    sum = triangle[row][column];
                else if (column == 0)
                    sum = triangle[row][column] + MaxSum(triangle, memoizedSums, row - 1, column);
                else if (column == triangle[row].Length - 1)
                    sum = triangle[row][column] + MaxSum(triangle, memoizedSums, row - 1, column - 1);
                else
                {
                    var leftMaxSum = MaxSum(triangle, memoizedSums, row - 1, column);
                    var rightMaxSum = MaxSum(triangle, memoizedSums, row - 1, column - 1);
                    if (leftMaxSum > rightMaxSum)
                        sum = triangle[row][column] + leftMaxSum;
                    else
                        sum = triangle[row][column] + rightMaxSum;
                }

                memoizedSums[row][column] = sum;
            }

            return memoizedSums[row][column].Value;
        }
    }
}
