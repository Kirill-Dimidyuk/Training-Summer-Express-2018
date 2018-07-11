using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Customer.Tests
{
    public class CustomerTests
    {
        [TestCase(ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string ToString_FormatWithoutParameters_PositiveTest()
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return c.ToString();
        }

        [TestCase("1", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("2", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("3", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("4", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("5", ExpectedResult = "Customer record: 1000000")]
        public string ToString_FormatWithOneParameter_PositiveTest(string format)
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return c.ToString(format);
        }

        [TestCase("1", null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("2", null, ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("3", null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("4", null, ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("5", null, ExpectedResult = "Customer record: 1000000")]
        public string ToString_DifferentFormats_PositiveTest(string format, IFormatProvider formatProvider)
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return c.ToString(format, formatProvider);
        }

        public void ToString_InvalidFormat_ThrowsFormatException()
        {
            Customer c = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            NUnit.Framework.Assert.Throws<FormatException>(() => c.ToString("11", null));
        }

    }
}
