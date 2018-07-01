using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayExtensions;
using System;

namespace ArrayExtensionTests
{
    [TestClass]
    public class ArrayExtensionTest
    {

        [TestMethod]
        public void FilterNumbers_WithDigit0_Success()
        {
            int[] array = new int[] { 0, 10, 20, 111, 456, 250 };

            PredicateDigit0 digit = new PredicateDigit0();

            int[] expected = new int[] { 0, 10, 20, 250 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit0_Unsuccess()
        {
            int[] array = new int[] { 0, 10, 20, 111, 456 };

            PredicateDigit0 digit = new PredicateDigit0();

            int[] expected = new int[] { 0, 10, 20, 111, 250 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit1_Success()
        {
            int[] array = new int[] { 1, 2, 7, 17, 701 };
            PredicateDigit1 digit = new PredicateDigit1();

            int[] expected = new int[] { 1, 17, 701 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit2_Success()
        {
            int[] array = new int[] { 1, 2, 77, 7, 701 };
            PredicateDigit2 digit = new PredicateDigit2();

            int[] expected = new int[]  { 2 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit3_Success()
        {
            int[] array = new int[] { 3, 2, 77, 37, 701 };
            PredicateDigit3 digit = new PredicateDigit3();

            int[] expected = new int[] { 3, 37 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit4_Success()
        {
            int[] array = new int[] { 4, 24, 27, 74, 101 };
            PredicateDigit4 digit = new PredicateDigit4();

            int[] expected = new int[] { 4, 24, 74 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit5_Success()
        {
            int[] array = new int[] { 51, 2, 5, 7, 751 };
            PredicateDigit5 digit = new PredicateDigit5();

            int[] expected = new int[] { 51, 5, 751 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithNegativeDigit6_Success()
        {
            int[] array = new int[] { 6, 2, -76, -6, -701 };
            PredicateDigit6 digit = new PredicateDigit6();

            int[] expected = new int[] { 6, -76, -6 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterNumbers_WithDigit7_Success()
        {
            int[] array = new int[] { 51, 2, 5, 7, 751 };
            PredicateDigit7 digit = new PredicateDigit7();

            int[] expected = new int[] { 7, 751 };

            int[] actual = ArrayExtension.FilterNumbers(array, digit);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterNumbers_WithEmptyArgument_ThrowArgumentException()
        {
            int[] array = new int[] { };
            PredicateDigit3 digit = new PredicateDigit3();

            int[] actual = ArrayExtension.FilterNumbers(array, digit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterNumbers_WithNullArgument_ThrowArgumentNulException()
        {
            int[] array = null;
            PredicateDigit3 digit = new PredicateDigit3();

            int[] actual = ArrayExtension.FilterNumbers(array, digit);
        }

    }

}
   