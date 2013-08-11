using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace Tests
{
    [TestClass]
    public class ShapeNumberGeneratorTests
    {
        [TestMethod]
        public void TestTriangleNumberGenerator()
        {
            var triangeNumbers = TriangleNumberGenerator.Generate().Take(7).ToArray();
            var expected = new[] { 1, 3, 6, 10, 15, 21, 28 };

            Assert.AreEqual(expected.Length, triangeNumbers.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], (int)triangeNumbers[i]);
        }

        [TestMethod]
        public void TestTriangleNthNumber()
        {
            var expected = 40755;
            var actual = TriangleNumberGenerator.NthNumber(285);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPentagonalNumberGenerator()
        {
            var expected = new[] { 1, 5, 12, 22, 35 };
            var actual = PentagonalNumberGenerator.Generate().Take(5).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void TestPentagonalNthNumber()
        {
            var expected = 40755;
            var actual = PentagonalNumberGenerator.NthNumber(165);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHexagonalNumberGenerator()
        {
            var expected = new[] { 1, 6, 15, 28, 45 };
            var actual = HexagonalNumberGenerator.Generate().Take(5).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void TestHexagonalNthNumber()
        {
            var expected = 40755;
            var actual = HexagonalNumberGenerator.NthNumber(143);
            Assert.AreEqual(expected, actual);
        }
    }
}
