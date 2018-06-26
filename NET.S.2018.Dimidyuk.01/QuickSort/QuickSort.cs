using System;

namespace QuickSort
{

    public static class QuickSort
    {

        public static int[] TheQuickSort(this int[] array)
        {

            if (array == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"The total length of {nameof(array)} can't be 0");
            }

            return Quicksort(array, 0, array.Length - 1);
        }

        public static int[] Quicksort(int[] array, int left, int right)
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
                Quicksort(array, left, r);
            }

            if (l < right)
            {
                Quicksort(array, l, right);
            }

            return array;
        }

        private static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}
