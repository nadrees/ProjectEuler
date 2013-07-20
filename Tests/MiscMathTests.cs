using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MiscMathTests
    {
        [TestMethod]
        public void TestNumberOfFactors()
        {
            var expected = 8;
            var actual = MiscMath.NumberOfFactors(24);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCircularPrimesBelow()
        {
            var expected = new[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97 };
            var actual = MiscMath.CircularPrimesBelow(100);

            Assert.AreEqual(expected.Length, actual.Length);

            foreach (var a in actual)
                Assert.IsTrue(expected.Contains(a));
        }
    }
}
