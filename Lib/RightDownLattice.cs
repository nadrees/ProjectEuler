using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class RightDownLattice
    {
        private int rows;
        private int columns;
        private long[,] lattice;

        public RightDownLattice(int rows, int columns)
        {
            this.rows = rows + 1;
            this.columns = columns + 1;
            lattice = new long[this.rows, this.columns];
            lattice[0, 0] = 1;
        }

        public long CountPaths(int row, int column)
        {
            if (lattice[row, column] == 0)
            {
                var leftCount = (column == 0 ? 0 : CountPaths(row, column - 1));
                var upCount = (row == 0 ? 0 : CountPaths(row - 1, column));
                lattice[row, column] = leftCount + upCount;
            }

            return lattice[row, column];
        }
    }
}
