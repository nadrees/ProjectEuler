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
    }
}
