using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int Binary<T>(T[] array, T element)
        {
            CheckData(array, element);

            return Search<T>(array, element, Comparer<T>.Default, 0, array.Length - 1);
        }

        private static int Search<T>(T[] array,T element, Comparer<T> comparer, int start, int last)
        {
            int middle;

            while (start <= last)
            {
                middle = (start + last) / 2;
                int arg = comparer.Compare(array[middle], element);

                if (arg < 0) 
                {
                    start = middle + 1;
                }

                if (arg > 0)
                {
                    last = middle - 1;
                }

                if(arg == 0)
                {
                    return middle;
                }
            }
            return -1;

        }

        private static void CheckData<T>(T[] array, T element)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"The value of parametr {nameof(array)} can`t ne null");
            }

            if (element == null)
            {
                throw new ArgumentNullException($"The value of parametr {nameof(element)} can`t ne null");
            }
        }
    }
}
