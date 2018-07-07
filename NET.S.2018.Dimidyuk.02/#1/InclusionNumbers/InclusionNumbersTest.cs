using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using InclusionNumbers;

namespace InclusionNumbers.Tests
{
    [TestClass]
    public class InclusionNumbersTest
    {
        #region Insertion
        [TestMethod]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int Inclusion_Numbers_PositiveTest(int first, int second, int startPosition, int finishPosition)
        {
            return InclusionNumbers.Insertion(first, second, startPosition, finishPosition);
        }
        #endregion

        [TestCase(0, 15, -1, 30)]
        [TestCase(0, 15, 1, 35)]
        public void Insertion_InputInvalidValues_ThrowsArgumentOutOfRangeException(int first, int second, int startPosition, int finishPosition)
        {
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => InclusionNumbers.Insertion(first, second, startPosition, finishPosition));
        }

        #region Exceptions
        [TestCase(0, 15, 30, 3)]
        public void Insertion_InputInvalidValues_ThrowsArgumentException(int first, int second, int startPosition, int finishPosition)
        {
            NUnit.Framework.Assert.Throws<ArgumentException>(() => InclusionNumbers.Insertion(first, second, startPosition, finishPosition));
        }
        #endregion
    }
}

