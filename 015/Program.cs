﻿using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015
{
    /// <summary>
    /// Starting in the top left corner of a 2 × 2 grid, and only being able to move to the right and down, 
    /// there are exactly 6 routes to the bottom right corner.
    /// 
    /// How many such routes are there through a 20 × 20 grid?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var lattice = new RightDownLattice(20, 20);
            
            Console.WriteLine(lattice.CountPaths(20, 20));
            Console.ReadKey();
        }
    }
}
