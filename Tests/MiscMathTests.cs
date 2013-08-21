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

        [TestMethod]
        public void TestGeneratePythagoreanTriplets()
        {
            var expected = new long[][]
            {
                new long[] { 3, 4, 5 },
                new long[] { 8, 6, 10 },
                new long[] { 5, 12, 13 }
            };
            var actual = MiscMath.GeneratePythagoreanTriples().Take(3).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < 3; i++)
            {
                var expectedTriplet = expected[i];
                var actualTriplet = actual[i];

                Assert.AreEqual(expectedTriplet.Length, actualTriplet.Length);

                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expectedTriplet[i], actualTriplet[i]);
            }
        }

        [TestMethod]
        public void TestIsLychrelNumber()
        {
            var expected = false;
            var actual = MiscMath.IsLynchrelNumber(47);

            Assert.AreEqual(expected, actual);

            expected = true;
            actual = MiscMath.IsLynchrelNumber(196);

            Assert.AreEqual(expected, actual);
        }
    }
}
