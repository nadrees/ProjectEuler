using Lib.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CrypoTests
{
    [TestClass]
    public class XorTests
    {
        private static readonly String inputString = @"The list below of most common words in English cannot be definitive. It is based on an analysis of the Oxford English Corpus of over a billion words, and represents one study done by Oxford Online, associated with the Oxford English Dictionary.[1] This source includes writings of all sorts from literary novels and specialist journals to everyday newspapers and magazines and from Hansard to the language of chatrooms, emails, and weblogs,[2] unlike some sources which use texts from only specific sources.[3]
The Reading Teachers Book of Lists claims that the first 25 words make up about one-third of all printed material in English, and that the first 100 make up about one-half of all written material.[4]
Note that word may mean either a word form (essentially, a distinct spelling), or a lexeme (essentially, a base word or dictionary-entry). For instance the lexeme be listed below, includes occurrences of are, is, were, was, etc.[5] Note also that these top 100 lemmas listed below account for 50% of all the words in the Oxford English Corpus.";
        private static byte[] secretBytes = new byte[] { 0, 15, 47, 58 };

        private Xor xor;

        [TestInitialize]
        public void SetUp()
        {
            xor = new Xor(secretBytes);
        }

        [TestMethod]
        public void TestDoXorBytes()
        {
            var bytes = Encoding.ASCII.GetBytes(inputString);
            var xoredBytes = xor.DoXor(bytes);
            var originalBytes = xor.DoXor(xoredBytes);
            var resultString = Encoding.ASCII.GetString(originalBytes);

            Assert.AreEqual(inputString, resultString);
        }

        [TestMethod]
        public void TestDoXorString()
        {
            var bytes = Encoding.ASCII.GetBytes(inputString);
            var xoredBytes = xor.DoXor(bytes);
            var resultString = xor.DoXor(xoredBytes, Encoding.ASCII);

            Assert.AreEqual(inputString, resultString);
        }
    }
}
