using System;
using System.Linq;

namespace MergeSort
{
    public static class MergeSort
    {

        public static int[] TheMergeSort(this int[] array)
        {

            if (array == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"The total length of {nameof(array)} can't be 0");
            }
            
            return Sort(array);
        }

        static int[] Sort(int[] array)
        {

            if (array.Length == 1)
            {
                return array;
            }

            int point = array.Length / 2;

            return Merge(Sort(array.Take(point).ToArray()), Sort(array.Skip(point).ToArray()));
        }

        static int[] Merge(int[] array1, int[] array2)
        {

            int a = 0, b = 0;

            Valid(array1, array2);

            int[] merged = new int[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if (array1[a] > array2[b])
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                else
                if (b < array2.Length)
                    merged[i] = array2[b++];
                else
                    merged[i] = array1[a++];
            }

            return merged;
        }

        private static void Valid(int[] arrayOne, int[] arrayTwo)
        {
            if (arrayOne == null)
                throw new ArgumentNullException(nameof(arrayOne));

            if (arrayTwo == null)
                throw new ArgumentNullException(nameof(arrayTwo));
        }
    }
}