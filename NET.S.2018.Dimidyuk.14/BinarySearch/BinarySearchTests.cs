using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearch;
using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestCase(new int[] { 0, 1, 2, 3, 6, 7, 10, 15, 16, 17, 18, 20, 22, 24, 26 }, 14, ExpectedResult = -1)]
        [TestCase(new int[] { 0, 1, 2, 3, 6, 7, 10, 15, 16, 17, 18, 20, 22, 24, 26 }, 26, ExpectedResult = 14)]
        [TestCase(new int[] { 0, 1, 2, 3, 6, 7, 10, 15, 16, 17, 18, 20, 22, 24, 26 }, 7, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 1, 2, 3, 6, 7, 10, 15, 16, 17, 18, 20, 22, 24, 26 }, 22, ExpectedResult = 12)]
        public int BinarySearchForElement_Success(int [] array, int item)
        {
            return BinarySearch.Binary(array, item);
        }

        [TestCase("ABCDEFGHIJKLMOPRSTUVWXYZ", 'A', ExpectedResult = 0)]
        [TestCase("ABCDEFGHIJKLMOPRSTUVWXYZ", 'a', ExpectedResult = 0)]
        [TestCase("ABCDEFGHIJKLMOPRSTUVWXYZ", 'k', ExpectedResult = 10)]
        [TestCase("ABCDEFGHIJKLMOPRSTUVWXYZ", 'p', ExpectedResult = 14)]
        [TestCase("ABCDEFGHIJKLMOPRSTUVWXYZ", 'w', ExpectedResult = 20)]
        public int? BinarySearch_CustomComparer_Succes(string input, char item)
        {
            char[] str = input.ToCharArray();
            return BinarySearch.Binary(str, char.ToUpper(item));
        }

        [TestCase(new double[] { 1.001, 1.003, 1.010, 1.012, 1.017 }, 1.010, ExpectedResult = 2)]
        [TestCase(new double[] { 2.221, 2.2313, 2.241, 2.251, 2.261 }, 2.261, ExpectedResult = 4)]
        public int? BinarySearch_InDoubleArray_Success(double[] array, double item)
        {
            return BinarySearch.Binary(array, item);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 6, 8, 10, 15, 16, 17, 18, 20, 22, 24, 26 }, 27, ExpectedResult = -1)]
        public int BinarySearch_ElementsNotFound_Success(int[] array, int item)
        {
            return BinarySearch.Binary(array, item);
        }
    }
}
