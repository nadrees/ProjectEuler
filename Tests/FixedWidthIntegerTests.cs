using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace Tests
{
    [TestClass]
    public class FixedWidthIntegerTests
    {
        [TestMethod]
        public void TestFixedWidthInteger_InitialValueZero()
        {
            var fwi = new FixedWidthInteger(0);

            Assert.AreEqual("0", fwi.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_InitialValue()
        {
            var fwi = new FixedWidthInteger(1234567890);

            Assert.AreEqual("1234567890", fwi.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_InitialValueAndSize()
        {
            var fwi = new FixedWidthInteger(1234567890, 10);

            Assert.AreEqual("1234567890", fwi.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_InitialValueAndSize_SizeLarger()
        {
            var fwi = new FixedWidthInteger(1234567890, 11);

            Assert.AreEqual("1234567890", fwi.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_InitialValueAndSize_SizeSmaller()
        {
            var fwi = new FixedWidthInteger(1234567890, 5);

            Assert.AreEqual("67890", fwi.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_Addition()
        {
            var fwi1 = new FixedWidthInteger(11);
            var fwi2 = new FixedWidthInteger(109);

            var answer = fwi1 + fwi2;

            Assert.AreEqual("20", answer.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_AdditionGreaterWidth()
        {
            var fwi1 = new FixedWidthInteger(1011, 4);
            var fwi2 = new FixedWidthInteger(109, 4);

            var answer = fwi1 + fwi2;

            Assert.AreEqual("1120", answer.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_Multiplication()
        {
            var fwi1 = new FixedWidthInteger(10);
            var fwi2 = new FixedWidthInteger(101);

            var answer = fwi1 * fwi2;

            Assert.AreEqual("10", answer.ToString());
        }

        [TestMethod]
        public void TestFixedWidthInteger_Exponent()
        {
            var fwi = new FixedWidthInteger(2, 2) ^ 4;

            Assert.AreEqual("16", fwi.ToString());
        }
    }
}
