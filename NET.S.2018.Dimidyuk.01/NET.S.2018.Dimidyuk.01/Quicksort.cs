using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Quicksort
    {
        public static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    Swap(ref array[marker], ref array[i]);
                    marker += 1;
                }
            }
            return marker - 1;
        }
        private static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        public static void quickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            int pivot = Partition(array, start, end);
            quickSort(array, start, pivot - 1);
            quickSort(array, pivot + 1, end);
        }
        public static void quicksort(int[] array)
        {
            quickSort(array, 0, array.Length - 1);
        }
    }
}
