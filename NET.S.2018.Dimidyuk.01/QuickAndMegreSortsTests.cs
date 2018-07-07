using System;
using SortMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OuickAndMergeSort.Tests
{
    [TestClass]
    public class UnitTestForTheMergeSort
    {
        [TestMethod]
        public void Sorting_Array_By_MergeSort_Success()
        {
            int[] array = new int[] { 5, 8, 4, 6, 9, 7, 1, 3, 2 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] actual = array.MergeSorting();
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_With_Throwing_ArgumentNullException()
        {
            int[] array = null;
            int[] actual = array.MergeSorting();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_With_Throwing_ArgumentException()
        {
            int[] array = { };
            int[] actual = array.MergeSorting();
        }
    }

    [TestClass]
    public class UnitTestsForTheQuickSort
    {
        [TestMethod]
        public void Sorting_Array_By_QuickSort_Success()
        {
            int[] array = new int[] { 5, 8, 4, 6, 9, 7, 1, 3, 2 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] actual = array.QuickSorting();
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_With_Throwing_ArgumentNullException()
        {
            int[] array = null;
            int[] actual = array.QuickSorting();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_With_Throwing_ArgumentException()
        {
            int[] array = { };
            int[] actual = array.QuickSorting();
        }
    }
}