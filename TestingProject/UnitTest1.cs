using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToWatch.ProcessClasses;
using NumbersToWatch.Extensions;

namespace TestingProject
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void TestNotEqual()
        {
            string result = Converter.NumbersToWordsConverter(32453418723.23m);
            Assert.AreNotEqual(result, "Zippity Doo Dah");
        }

        [TestMethod]
        public void TestEqual()
        {
            string result = Converter.NumbersToWordsConverter(32453418723.23m);
            Assert.AreEqual(result, "Thirty Two Billion Four Hundred Fifty Three Million Four Hundred Eighteen Thousand Seven Hundred Twenty Three Dollars and 23/100");
        }

        [TestMethod]
        public void TestNotEqualExtension()
        {
            Decimal testValue = 32453418723.23m;
            Assert.AreNotEqual(testValue.ProvideChequeText(), "Zippity Doo Dah");
        }

        [TestMethod]
        public void TestEqualExtension()
        {
            Decimal testValue = 728163.11m;
            Assert.AreEqual(testValue.ProvideChequeText(), "Seven Hundred Twenty Eight Thousand One Hundred Sixty Three Dollars and 11/100");
        }
    }
}
