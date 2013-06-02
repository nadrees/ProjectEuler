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
    }
}
