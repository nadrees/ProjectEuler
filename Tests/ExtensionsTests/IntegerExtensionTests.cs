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
        public void TestSpell()
        {
            Assert.AreEqual("three hundred and forty-two", 342.Spell());
            Assert.AreEqual("one hundred and fifteen", 115.Spell());
            Assert.AreEqual("one thousand", 1000.Spell());
            Assert.AreEqual("five hundred", 500.Spell());
            Assert.AreEqual("forty", 40.Spell());
            Assert.AreEqual("eighteen", 18.Spell());
        }

        [TestMethod]
        public void TestGetAllRotations()
        {
            var expected = new[] { 197, 719, 971 };

            var actual = 197.GetAllRotations();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < actual.Length; i++)
                Assert.IsTrue(expected.Contains(actual[i]));
        }

        [TestMethod]
        public void TestGetAllDivisors()
        {
            var expected = new[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 };
            var actual = 220.GetAllDivisors().OrderBy(d => d).ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void TestGetAbundancy()
        {
            var expected = NumberAbundancy.Abundant;
            var actual = 12.GetAbundancy();
            Assert.AreEqual(expected, actual);

            expected = NumberAbundancy.Perfect;
            actual = 28.GetAbundancy();
            Assert.AreEqual(expected, actual);

            expected = NumberAbundancy.Deficient;
            actual = 2.GetAbundancy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFactorial()
        {
            var expected = "1";
            var actual = 0.Factorial().ToString();
            Assert.AreEqual(expected, actual);

            expected = "120";
            actual = 5.Factorial().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToBase()
        {
            var expected = "111011";
            var actual = 59.ToBase(2);
            Assert.AreEqual(expected, actual);

            expected = "214";
            actual = 59.ToBase(5);
            Assert.AreEqual(expected, actual);
        }
    }
}
