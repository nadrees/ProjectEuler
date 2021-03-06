﻿using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _045
{
    /// <summary>
    /// Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
    /// 
    /// Triangle	 	Tn=n(n+1)/2	 	1, 3, 6, 10, 15, ...
    /// Pentagonal	 	Pn=n(3n−1)/2	1, 5, 12, 22, 35, ...
    /// Hexagonal	 	Hn=n(2n−1)	 	1, 6, 15, 28, 45, ...
    /// 
    /// It can be verified that T285 = P165 = H143 = 40755.
    /// 
    /// Find the next triangle number that is also pentagonal and hexagonal.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // all hexagonal numbers are also triangle numbers
            // only need to find next hexagonal number which is also
            // a pentagonal number

            int p = 166;
            int h = 144;

            BigInteger pNum = PentagonalNumberGenerator.NthNumber(p);
            BigInteger hNum = HexagonalNumberGenerator.NthNumber(h);

            while (pNum != hNum && pNum > 0)
            {
                if (pNum < hNum)
                {
                    p++;
                    pNum = PentagonalNumberGenerator.NthNumber(p);
                }
                else
                {
                    h++;
                    hNum = HexagonalNumberGenerator.NthNumber(h);
                }
            }

            Console.WriteLine(hNum);
            Console.ReadKey();
        }
    }
}
