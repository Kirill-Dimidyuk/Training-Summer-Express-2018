using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FindNthRoot;
using System;

namespace FindNthRoot.Tests
{
    [TestClass]
    public class FindNthRootTests
    {
        [TestCase(1, 5, 0.0001,  1)]
        [TestCase(8, 3, 0.0001,  2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001,  2)]
        [TestCase(0.0279936, 7, 0.0001,  0.6)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void NewtonMethod_CorrectInputValues_PositiveTest(double number, double n, double accuracy, double ExpectedResult)
        {
            double actual = FindNthRoot.NewtonMethod(number, n, accuracy);
            double expected = ExpectedResult;
            NUnit.Framework.Assert.AreEqual(actual, expected, accuracy);
        }
        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -0.0001)]
        public void Insertion_InputValuesLess0_ThrowsArgumentException(double number, double n, double accuracy)
        {
            NUnit.Framework.Assert.Throws<ArgumentException>(() => FindNthRoot.NewtonMethod(number, n, accuracy));
        }

    }
}
