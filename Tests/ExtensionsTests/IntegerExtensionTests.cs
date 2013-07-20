using Lib.Extensions;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ExtensionsTests
{
    [TestClass]
    public class IntegerExtensionTests
    {
        [TestMethod]
        public void TestPrimeFactorize()
        {
            var factors = 24.PrimeFactorize().OrderBy(i => i).ToArray();
            var expected = new[] { 2, 2, 2, 3 };

            Assert.AreEqual(expected.Length, factors.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], factors[i]);
            }
        }

        [TestMethod]
        public void TestSumOfSquares()
        {
            var sum = 10.SumOfSquares();
            Assert.AreEqual(385, sum);
        }

        [TestMethod]
        public void TestSquareOfSum()
        {
            var square = 10.SquareOfSum();
            Assert.AreEqual(3025, square);
        }

        [TestMethod]
        public void TestSpell_342()
        {
            var expected = "three hundred and fourty-two";

            var actual = 342.Spell();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpell_115()
        {
            var expected = "one hundred and fifteen";

            var actual = 115.Spell();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpell_1000()
        {
            var expected = "one thousand";
            var actual = 1000.Spell();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpell_500()
        {
            var expected = "five hundred";
            var actual = 500.Spell();
            Assert.AreEqual(expected, actual);
        }
    }
}
