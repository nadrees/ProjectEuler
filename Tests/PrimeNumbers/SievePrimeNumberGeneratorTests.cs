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
    public class SievePrimeNumberGeneratorTests : IPrimeNumberGeneratorTests
    {
        [TestInitialize]
        public override void SetUp()
        {
            generator = new SievePrimeNumberGenerator();
        }
    }
}
