using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ExtensionsTests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void TestMaxProductOfLength()
        {
            var grid = File.ReadAllLines(@"Resources\grid.txt")
                .Select(l => l.Split(' ').Select(n => int.Parse(n)).ToArray())
                .ToArray();
            var answer = grid.MaxProductOfLength(4);

            Assert.AreEqual(70600674, answer);
        }

        [TestMethod]
        public void TestMaxSum()
        {
            var triangle = new int[][]
            {
                new int[] { 3 },
                new int[] { 7, 4 },
                new int[] { 2, 4, 6 },
                new int[] { 8, 5, 9, 3 }
            };
            var expected = 23;

            var actual = triangle.MaxSum();

            Assert.AreEqual(expected, actual);
        }
    }
}
