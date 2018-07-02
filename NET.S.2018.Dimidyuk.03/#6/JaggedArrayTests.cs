using Microsoft.VisualStudio.TestTools.UnitTesting;
using JaggedMassive;

namespace JaggedMassiveTest
{
    [TestClass]
    public class JaggedArrayTest
    {
        [TestMethod]
        public void Testing_IncreasingSum_Success()
        {
            int[][] Matrix = new int[4][];
            Matrix[0] = new int[] { 2, 5, 8, 7, 12, 74 };//108
            Matrix[1] = new int[] { 3, 4, 9, 2, 15 };//33
            Matrix[2] = new int[] { 13, 25, 85, 95, 112, 544 };//874
            Matrix[3] = new int[] { 3, 21, 45, 10 };//79

            Matrix.SortMassive(new SumIncreasing());
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

            Matrix.SortMassive(new SumDecreasing());
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

            Matrix.SortMassive(new MaxItcreasing());
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

            Matrix.SortMassive(new MaxDecreasing());
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

            Matrix.SortMassive(new MinIncreasing());
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

            Matrix.SortMassive(new MinDecreasing());
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
    }
}
