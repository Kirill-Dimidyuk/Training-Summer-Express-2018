using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace AdvancedCustomer.Tests
{
    public class AdvancedCustomerTests
    {
        [TestCase("1+", null, ExpectedResult = "Customer record: Name - Jeffrey Richter, Revenue - 1,000,000.00, Phone - +1 (425) 555-0100")]
        [TestCase("2+", null, ExpectedResult = "Customer record: Phone - +1 (425) 555-0100")]
        [TestCase("3+", null, ExpectedResult = "Customer record: Name - Jeffrey Richter, Revenue - 1,000,000.00")]
        [TestCase("4+", null, ExpectedResult = "Customer record: Name - Jeffrey Richter")]
        [TestCase("5+", null, ExpectedResult = "Customer record: Revenue - 1000000")]
        public string ToString_AdvancedCustomerFormats_PositiveTest(string format, IFormatProvider formatProvider)
        {
            AdvancedCustomer ce = new AdvancedCustomer();
            Customer.Customer c = new Customer.Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return ce.Format(format, c, formatProvider);
        }

        [Test]
        public void ToString_InvalidAdvancedCustomerFormat_ThrowsFormatException()
        {
            Customer.Customer c = new Customer.Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            NUnit.Framework.Assert.Throws<FormatException>(() => c.ToString("1++", null));
        }

    }
}
