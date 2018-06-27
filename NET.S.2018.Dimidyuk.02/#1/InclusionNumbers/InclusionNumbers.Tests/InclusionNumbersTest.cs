using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InclusionNumbers;

namespace InclusionNumbers.Tests
{
    [TestClass]
    public class InclusionNumbersTest
    {

        [TestMethod]
        public void Inclusion_Numbers_Success()
        {
            int first = 8;
            int second = 15;
            int startPosition = 0;
            int finishPosition = 0;

            int actual = InclusionNumbers.Insertion(first, second, startPosition, finishPosition);

            Assert.AreEqual(actual, 9);
        }

        [TestMethod]
        public void Inclusion_Numbers_Unsuccess()
        {
            int first = 0;
            int second = 15;
            int startPosition = 0;
            int finishPosition = 30;

            int actual = InclusionNumbers.Insertion(first, second, startPosition, finishPosition);

            Assert.AreEqual(actual, 17); //15
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Inclusion_Numbers_ArgumentException()
        {
            int first = 0;
            int second = 15;
            int startPosition = 30;
            int finishPosition = 3;

            int actual = InclusionNumbers.Insertion(first, second, startPosition, finishPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Inclusion_Numbers_ArgumentOutOfRangeException_Of_StartPosition()
        {
            int first = 0;
            int second = 15;
            int startPosition = -1;
            int finishPosition = 30;

            int actual = InclusionNumbers.Insertion(first, second, startPosition, finishPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Inclusion_Numbers_ArgumentOutOfRangeException_Of_FinishPosition()
        {
            int first = 0;
            int second = 15;
            int startPosition = 1;
            int finishPosition = 35;

            int actual = InclusionNumbers.Insertion(first, second, startPosition, finishPosition);
        }

    }
}

