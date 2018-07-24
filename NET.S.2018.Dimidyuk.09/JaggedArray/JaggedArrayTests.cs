using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaggedArray.Tests
{
    [TestClass]
    public class JaggedArrayTests
    {
        [TestMethod]
        public void Testing_IncreasingSum_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//108
            Matrix[1] = new int[] { 3, 4, 9, 2, 15 };//33
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//874
            Matrix[3] = new int[] { 3, 21, 45, 10 };//79

            Matrix.BubbleSort(new IncreasingSum());
            int[][] expected = new int[4][];
            expected[0] = new int[] { 3, 4, 9, 2, 15 };
            expected[1] = new int[] { 3, 21, 45, 10 };
            expected[2] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[3] = new int[] { 13, 25, 85, 95, 112, 544 };


            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_DecreasingSum_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//108
            Matrix[1] = new int[] { 3, 4, 9, 2, 15 };//33
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//874
            Matrix[3] = new int[] { 3, 21, 45, 10 };//79

            Matrix.BubbleSort(new DecreasingSum());
            int[][] expected = new int[4][];
            expected[3] = new int[] { 3, 4, 9, 2, 15 };
            expected[2] = new int[] { 3, 21, 45, 10 };
            expected[1] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[0] = new int[] { 13, 25, 85, 95, 112, 544 };


            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_IncreasingMaxElements_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//74
            Matrix[1] = new int[] { 3, 4, 9, 2, 15 };//15
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//544
            Matrix[3] = new int[] { 3, 21, 45, 10 };//45

            Matrix.BubbleSort(new IncreasingMaxElements());
            int[][] expected = new int[4][];
            expected[0] = new int[] { 3, 4, 9, 2, 15 };
            expected[1] = new int[] { 3, 21, 45, 10 };
            expected[2] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[3] = new int[] { 13, 25, 85, 95, 112, 544 };


            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_DecreasingMaxElements_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//74
            Matrix[1] = new int[] { 3, 4, 9, 2, 15 };//15
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//544
            Matrix[3] = new int[] { 3, 21, 45, 10 };//45

            Matrix.BubbleSort(new DecreasingMaxElements());
            int[][] expected = new int[4][];
            expected[3] = new int[] { 3, 4, 9, 2, 15 };
            expected[2] = new int[] { 3, 21, 45, 10 };
            expected[1] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[0] = new int[] { 13, 25, 85, 95, 112, 544 };


            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_IncreasingMinElements_Success()
        {

            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//2
            Matrix[1] = new int[] { 5, 4, 10, 3, 15 };//3
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//13
            Matrix[3] = new int[] { 1, 2, 21, 45, 10 };//1

            Matrix.BubbleSort(new IncreasingMinElements());
            int[][] expected = new int[4][];
            expected[0] = new int[] { 1, 2, 21, 45, 10 };
            expected[1] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[2] = new int[] { 5, 4, 10, 3, 15 };
            expected[3] = new int[] { 13, 25, 85, 95, 112, 544 };

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_DecreasingMinElements_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//2
            Matrix[1] = new int[] { 5, 4, 10, 3, 15 };//3
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//13
            Matrix[3] = new int[] { 1, 2, 21, 45, 10 };//1

            Matrix.BubbleSort(new DecreasingMinElements());
            int[][] expected = new int[4][];
            expected[3] = new int[] { 1, 2, 21, 45, 10 };
            expected[2] = new int[] { 2, 5, 8, 7, 12, 74 };
            expected[1] = new int[] { 5, 4, 10, 3, 15 };
            expected[0] = new int[] { 13, 25, 85, 95, 112, 544 };

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(Matrix[i], expected[i]);
            }
        }

        [TestMethod]
        public void Testing_NullReferenceArray_Throwing_ArgumentNullException()
        {
            int[][] Matrix = null;
            Assert.ThrowsException<ArgumentNullException>(() => Matrix.BubbleSort(new IncreasingMaxElements()));
        }

        [TestMethod]
        public void Testing_NullComparerParameter_Throwing_ArgumentNulleException()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//2
            Matrix[1] = new int[] { 5, 4, 10, 3, 15 };//3
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//13
            Matrix[3] = new int[] { 1, 2, 21, 45, 10 };//1
            Assert.ThrowsException<ArgumentNullException>(() => Matrix.BubbleSort(null));
        }
    }
}
