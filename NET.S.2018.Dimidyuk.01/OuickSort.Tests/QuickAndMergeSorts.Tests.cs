using System;
using MergeSort;
using QuickSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForMergeAndQuickSorts
{
    [TestClass]
    public class UnitTestForTheMergeSort
    {
        [TestMethod]
        public void Sorting_Array_By_MergeSort_Success()
        {
            int[] array = new int[] { 6, 7, 3, 2, 1, 5, 9, 1, 8 };

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] actual = array.TheMergeSort();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void MergeSort_With_Throwing_ArgumentNullException()
        {
            int[] array = null;

            int[] actual = array.TheMergeSort();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_With_Throwing_ArgumentException()
        {
            int[] array = { };

            int[] actual = array.TheMergeSort();
        }
    }

    [TestClass]
    public class UnitTestsForTheQuickSort
    {
        [TestMethod]
        public void Sorting_Array_By_QuickSort_Success()
        {
            int[] array = new int[] { 6, 7, 3, 2, 1, 5, 9, 1, 8 };

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] actual = array.TheQuickSort();

            CollectionAssert.AreEqual(actual, expected);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_With_Throwing_ArgumentNullException()
        {
            int[] array = null;

            int[] actual = array.TheQuickSort();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_With_Throwing_ArgumentException()
        {
            int[] array = { };

            int[] actual = array.TheQuickSort();
        }
    }
}
