using Lib.PrimeNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PrimeNumbers
{
    [TestClass]
    public abstract class IPrimeNumberGeneratorTests
    {
        private static readonly ulong[] expected = new ulong[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71 };

        protected IPrimeNumberGenerator generator;

        [TestInitialize]
        public abstract void SetUp();

        [TestMethod]
        public void TestGetPrimesBelowLongMaxValue()
        {
            Assert.IsNotNull(generator);

            var actual = generator.GetPrimesBelowLongMaxValue()
                .Take(expected.Length)
                .ToArray();

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual((long)expected[i], actual[i]);
        }
    }
}
