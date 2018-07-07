using System;
using System.Linq;

namespace SortMethods
{
    /// <summary>
    /// Sorts array by QuickSort
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        /// Sorts by QuickSort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Sorted array or exceptions</returns>
        /// <exception cref="ArgumentNullException">exception of array</exception>
        /// <exception cref="ArgumentException">exception of array</exception>
        public static int[] QuickSorting(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"The total length of {nameof(array)} can't be 0");
            }

            return SortByQuicksort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts by quicksort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>Sorted array</returns>
        public static int[] SortByQuicksort(int[] array, int left, int right)
        {
            int l = left, r = right;
            int pivot = array[(left + right) / 2];

            while (l <= r)
            {
                while (array[l].CompareTo(pivot) < 0)
                {
                    l++;
                }

                while (array[r].CompareTo(pivot) > 0)
                {
                    r--;
                }

                if (l <= r)
                {
                    Swap(ref array[l], ref array[r]);
                    l++;
                    r--;
                }
            }

            if (left < r)
            {
                SortByQuicksort(array, left, r);
            }

            if (l < right)
            {
                SortByQuicksort(array, l, right);
            }

            return array;
        }

        /// <summary>
        /// Swaps a and b.
        /// </summary>
        /// <param name="a">The parameter a.</param>
        /// <param name="b">The parameter b.</param>
        private static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

    /// <summary>
    /// Sorts array by MergeSort
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Merges the sorting.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Sorted array or exceptions</returns>
        /// <exception cref="ArgumentNullException">exception of array</exception>
        /// <exception cref="ArgumentException">exception of array</exception>
        public static int[] MergeSorting(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"The total length of {nameof(array)} can't be 0");
            }

            return Sorting(array);
        }

        /// <summary>
        /// Sorts the by merge sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Sorted array</returns>
        private static int[] Sorting(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int point = array.Length / 2;

            return Merging(Sorting(array.Take(point).ToArray()), Sorting(array.Skip(point).ToArray()));
        }

        /// <summary>
        /// Merges the specified array1.
        /// </summary>
        /// <param name="array1">The array1.</param>
        /// <param name="array2">The array2.</param>
        /// <returns>Merged array</returns>
        private static int[] Merging(int[] array1, int[] array2)
        {
            int a = 0, b = 0;

            Valid(array1, array2);

            int[] merged = new int[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                {
                    if (array1[a] > array2[b])
                    {
                        merged[i] = array2[b++];
                    }
                    else
                    {
                        merged[i] = array1[a++];
                    }
                }
                else
                {
                    if (b < array2.Length)
                    {
                        merged[i] = array2[b++];
                    }
                    else
                    {
                        merged[i] = array1[a++];
                    }
                }
            }

            return merged;
        }

        /// <summary>
        /// Validate the specified array one.
        /// </summary>
        /// <param name="arrayOne">The array one.</param>
        /// <param name="arrayTwo">The array two.</param>
        /// <exception cref="ArgumentNullException">
        /// arrayOne
        /// or
        /// arrayTwo
        /// </exception>
        private static void Valid(int[] arrayOne, int[] arrayTwo)
        {
            if (arrayOne == null)
            {
                throw new ArgumentNullException(nameof(arrayOne));
            }

            if (arrayTwo == null)
            {
                throw new ArgumentNullException(nameof(arrayTwo));
            }
        }
    }
}
