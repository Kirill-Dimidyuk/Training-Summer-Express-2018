using System;
using System.Linq;

namespace JaggedArray
{
    /// <summary>
    /// Static class for working with Jagged arrays
    /// </summary>
    public static class JaggedArray
    {
        /// <summary>
        /// Sorts jagged array
        /// </summary>
        /// <param name="jaggedArray">array for sorting</param>
        /// <param name="comparer">instruction for sorting</param>
        public static void BubbleSort<T>(this T[][] jaggedArray, IComparer<T> comparer)
        {
            CheckData(jaggedArray, comparer);
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < jaggedArray.Length - 1; i++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[i + 1]) > 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[i + 1]);
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks data for valid
        /// </summary>
        /// <param name="jaggedArray">array for sorting</param>
        /// <param name="comparer">instruction for sorting</param>
        private static void CheckData<T>(T[][] jaggedArray, IComparer<T> comparer)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
        }

        /// <summary>
        /// Swaps elements a and b
        /// </summary>
        /// <param name="a">elemrnt a</param>
        /// <param name="b">element b</param>
        private static void Swap<T>(ref T[] a, ref T[] b)
        {
            T[] tmp = a;
            a = b;
            b = tmp;
        }
    }

    public interface IComparer<T>
    {
        int Compare(T[] FirstItem, T[] SecondItem);
    }

    /// <summary>
    /// Compare by increasing Sum
    /// </summary>
    public class IncreasingSum : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }

            if (firstItem == null)
            {
                return 1;
            }

            if (secondItem == null)
            {
                return -1;
            }

            return firstItem.Sum() - secondItem.Sum();
        }
    }

    /// <summary>
    /// Compare by decreasing Sum
    /// </summary>
    public class DecreasingSum : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }
            if (firstItem == null)
            {
                return -1;
            }
            if (firstItem == null)
            {
                return 1;
            }

            return secondItem.Sum() - firstItem.Sum();
        }
    }

    /// <summary>
    /// Compare by increasing max element
    /// </summary>
    public class IncreasingMaxElements : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }

            if (firstItem == null)
            {
                return 1;
            }

            if (secondItem == null)
            {
                return -1;
            }

            return firstItem.Max() - secondItem.Max();
        }
    }

    /// <summary>
    /// Compare by decreasing max element
    /// </summary>
    public class DecreasingMaxElements : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }

            if (firstItem == null)
            {
                return 1;
            }

            if (secondItem == null)
            {
                return -1;
            }

            return secondItem.Max() - firstItem.Max();
        }
    }

    /// <summary>
    /// compare by increasing min element
    /// </summary>
    public class IncreasingMinElements : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }

            if (firstItem == null)
            {
                return 1;
            }

            if (secondItem == null)
            {
                return -1;
            }

            return firstItem.Min() - secondItem.Min();
        }
    }

    /// <summary>
    /// compare by decreasing min element
    /// </summary>
    public class DecreasingMinElements : IComparer<int>
    {
        public int Compare(int[] firstItem, int[] secondItem)
        {
            if (firstItem == null && secondItem == null)
            {
                return 0;
            }

            if (firstItem == null)
            {
                return 1;
            }

            if (firstItem == null)
            {
                return -1;
            }

            return secondItem.Min() - firstItem.Min();
        }
    }
}
