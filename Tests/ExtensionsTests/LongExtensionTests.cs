using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ExtensionsTests
{
    [TestClass]
    public class LongExtensionTests
    {
        [TestMethod]
        public void TestPrimeFactorize()
        {
            var primeFactors = 24L.PrimeFactorize().OrderBy(l => l).ToArray();
            var expected = new[] { 2L, 2L, 2L, 3L };

            Assert.AreEqual(expected.Length, primeFactors.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], primeFactors[i]);
        }

        [TestMethod]
        public void TestPrimeFactorizeOf1()
        {
            var primeFactors = 1L.PrimeFactorize();
            var expected = new int[0];

            Assert.AreEqual(primeFactors.ToArray().Length, expected.Length);
        }

        [TestMethod]
        public void TestFactorize()
        {
            var factors = 28L.Factorize().OrderBy(l => l).ToArray();
            var expected = new[] { 1, 2, 4, 7, 14, 28 };

            Assert.AreEqual(expected.Length, factors.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], factors[i]);
        }
    }
}
