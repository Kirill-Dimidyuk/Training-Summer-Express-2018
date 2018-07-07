using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using StringToDecimal;

namespace StringToDecimal.Tests
{
    [TestClass]
    public class StringToDecimalTests
    {

        [TestMethod]
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        public int StringToDecimal_CorrectValues_PositiveTest(string number, int scale)
        {
            Notation notation = new Notation(scale);
            return StringToDecimal.ConvertingToDecimal(number, notation);
        }

        [TestCase("764241", 20)]
        [TestCase("1AeF101", -2)]
        public void StringToDecimal_InputInvalidValues_ThrowsArgumentException(string number, int scale)
        {
            Notation notation = new Notation(scale);
            NUnit.Framework.Assert.Throws<ArgumentException>(() => StringToDecimal.ConvertingToDecimal(number, notation));
        }

        [TestCase(null, 2)]
        [TestCase("", 10)]
        public void StringToDecimal_InpotNullOrEmptyValues_ThrowsNullException(string number, int scale)
        {
            Notation notation = new Notation(scale);
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => StringToDecimal.ConvertingToDecimal(number, notation));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        public void StringToDecimal_InputTooBigValues_ThrowsOverflowException(string number, int scale)
        {
            Notation notation = new Notation(scale);
            NUnit.Framework.Assert.Throws<OverflowException>(() => StringToDecimal.ConvertingToDecimal(number, notation));
        }
    }
}
