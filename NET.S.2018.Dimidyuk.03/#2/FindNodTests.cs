﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace FindNod.Tests
{
    [TestClass]
    public class FindNodTests
    {
        #region EuclidForTwo
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(24, 24, ExpectedResult = 24)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        public int FindNod_EuclidMethodForTwo_CorrectInputValues_PositiveTest(int first, int second)
        {
            return Nod.EuclidMethod(first, second);
        }
        #endregion

        #region EuclidForArray
        [TestCase(new int[] {5, 10, 15, 20}, ExpectedResult = 5)]
        [TestCase(new int[] { 5, 0, 15, -20 }, ExpectedResult = 5)]
        [TestCase(new int[] { 5, -5, 15, 20 }, ExpectedResult = 5)]
        public int FindNod_EuclidMethodForArray_CorrectInputValues_PositiveTest(int[] array)
        {
            return Nod.EuclidMethod(array);
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
            return Nod.EuclidMethod(first, second);
        }
        #endregion

        #region SteinForArray
        [TestCase(new int[] { 5, 10, 15, 20 }, ExpectedResult = 5)]
        [TestCase(new int[] { 24, 0, 24, -24 }, ExpectedResult = 24)]
        [TestCase(new int[] { 5, -5, 15, 20 }, ExpectedResult = 5)]
        public int FindNod_SteinMethodForArray_CorrectInputValues_PositiveTest(int[] array)
        {
            return Nod.SteinMethod(array);
        }
        #endregion
    }
}