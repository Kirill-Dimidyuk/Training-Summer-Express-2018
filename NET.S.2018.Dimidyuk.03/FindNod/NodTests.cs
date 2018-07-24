using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Nod.Tests
{
    [TestClass]
    public class NodTests
    {
        #region EuclidForTwo
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(24, 24, ExpectedResult = 24)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        public int FindNod_EuclidMethodForTwo_CorrectInputValues_PositiveTest(int first, int second)
        {
            return Nod.Euclid(first, second);
        }
        #endregion

        #region EuclidForThree
        [TestCase(1, 10, 11, ExpectedResult = 1)]
        [TestCase(5, 10, 13, ExpectedResult = 1)]
        [TestCase(24, 24, 24, ExpectedResult = 24)]
        [TestCase(-5, 10, 15, ExpectedResult = 5)]
        [TestCase(5, 0, 2, ExpectedResult = 1)]
        public int FindNod_EuclidMethodForThree_CorrectInputValues_PositiveTest(int first, int second, int third)
        {
            return Nod.Euclid(first, second, third);
        }
        #endregion

        #region EuclidForArray
        [TestCase(new int[] { 5, 10, 15, 20 }, ExpectedResult = 5)]
        [TestCase(new int[] { 5, 0, 15, -20 }, ExpectedResult = 5)]
        [TestCase(new int[] { 5, -5, 15, 20 }, ExpectedResult = 5)]
        public int FindNod_EuclidMethodForArray_CorrectInputValues_PositiveTest(int[] array)
        {
            return Nod.Euclid(array);
        }
        #endregion

        #region SteinForTwo
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(24, 24, ExpectedResult = 24)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        public int FindNod_SteinMethodForTwo_CorrectInputValues_PositiveTest(int first, int second)
        {
            return Nod.Stein(first, second);
        }
        #endregion

        #region SteinForThree
        [TestCase(1, 10, 11, ExpectedResult = 1)]
        [TestCase(5, 10, 13, ExpectedResult = 1)]
        [TestCase(24, 24, 24, ExpectedResult = 24)]
        [TestCase(-5, 10, 15, ExpectedResult = 5)]
        [TestCase(5, 0, 2, ExpectedResult = 1)]
        public int FindNod_SteinMethodForThree_CorrectInputValues_PositiveTest(int first, int second, int third)
        {
            return Nod.Stein(first, second, third);
        }
        #endregion

        #region SteinForArray
        [TestCase(new int[] { 5, 10, 15, 20 }, ExpectedResult = 5)]
        [TestCase(new int[] { 24, 0, 24, -24 }, ExpectedResult = 24)]
        [TestCase(new int[] { 5, -5, 15, 20 }, ExpectedResult = 5)]
        public int FindNod_SteinMethodForArray_CorrectInputValues_PositiveTest(int[] array)
        {
            return Nod.Stein(array);
        }
        #endregion

    }
}
