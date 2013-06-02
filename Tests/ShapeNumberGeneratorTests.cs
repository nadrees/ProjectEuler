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
    }
}
