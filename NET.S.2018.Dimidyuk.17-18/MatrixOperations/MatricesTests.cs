using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Matrices;

namespace Matrices.Tests
{
    [TestClass]
    public class MatricesTests
    {
        [Test]
        public void Sum_IntInputValues_PositiveTest()
        {
            AbstractMatrix<int> matr = new SquareMatrix<int>(2, new int[] { 1, 2, 3, 4 });
            AbstractMatrix<int> smatr = new SymmetricMatrix<int>(2, new int[] { 1, 1 });
            AbstractMatrix<int> actualResult = matr.Sum<int>(smatr);
            AbstractMatrix<int> expectedResult = new SquareMatrix<int>(2, new int[] { 2, 3, 4, 4 });
            NUnit.Framework.Assert.IsTrue((new MatrixComparer<int>()).Equals(actualResult, expectedResult));
        }

        [Test]
        public void Sum_OperationPlusIsNotDefinedForType_TrowArgumentException()
        {
            SquareMatrix<object> matr = new SquareMatrix<object>(2, new object[] { new object() });
            SquareMatrix<object> smatr = new SquareMatrix<object>(2, new object[] { new object() });
            NUnit.Framework.Assert.Throws<ArgumentException>(() => MatrixOperation.Sum<object>(matr, smatr));
        }

        [Test]
        public void Sum_LeftMatrixIsNull_TrowArgumentNullException()
        {
            SquareMatrix<int> matr = new SquareMatrix<int>(2, new int[] { 1 });
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => MatrixOperation.Sum<int>(null, matr));
        }

        [Test]
        public void Sum_RightMatrixIsNull_TrowArgumentNullException()
        {
            SquareMatrix<int> matr = new SquareMatrix<int>(2, new int[] { 1 });
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => MatrixOperation.Sum<int>(matr, null));
        }

        [Test]
        public void Sum_MatricesHaveDifferentSizes_TrowArgumentException()
        {
            SquareMatrix<int> matr = new SquareMatrix<int>(3, new int[] { 1 });
            SquareMatrix<int> smatr = new SquareMatrix<int>(2, new int[] { 2 });
            NUnit.Framework.Assert.Throws<ArgumentException>(() => MatrixOperation.Sum<int>(matr, smatr));
        }
    }
}
