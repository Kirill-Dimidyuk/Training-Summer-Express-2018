using System;

namespace FindNod
{
    public class Nod
    {
        /// <summary>
        /// Finds NOD using Euclid method for array of parameters.
        /// </summary>
        /// <param name="first">Left int parameter.</param>
        /// <param name="second">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int EuclidMethod(params int[] array)
        {
            CheckArray(array);

            int nod = EuclidMethod(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = EuclidMethod(array[i], nod);
            }

            return nod;
        }

        /// <summary>
        /// Finds NOD using Euclid method for 2 parameters.
        /// </summary>
        /// <param name="first">Left int parameter.</param>
        /// <param name="second">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int EuclidMethod(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == 0) return second;
            if (second == 0) return first;

            while (first != second)
            {
                if (first > second)
                {
                    first -= second;
                }
                else
                {
                    second -= first;
                }
            }
            return first;
        }

        /// <summary>
        /// Finds NOD using Stein method for array of parameters.
        /// </summary>
        /// <param name="first">Left int parameter.</param>
        /// <param name="second">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int SteinMethod(params int[] array)
        {
            CheckArray(array);

            int nod = SteinMethod(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = SteinMethod(array[i], nod);
            }

            return nod;
        }

        /// <summary>
        /// Finds NOD using Stein method for 2 parameters.
        /// </summary>
        /// <param name="first">Left int parameter.</param>
        /// <param name="second">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int SteinMethod(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == second) return first;
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == 1 || second == 1) return 1;

            if ((first & 1) == 0)
            {
                if ((second & 1) == 1)
                    return SteinMethod(first >> 1, second);
                else
                    return (SteinMethod(first >> 1, second >> 1) << 1);
            }
            else
            {
                if ((second & 1) == 0)
                    return SteinMethod(first, second >> 1);
                else
                {
                    if (first < second)
                        return SteinMethod(first, Math.Abs(first - second) >> 1);
                    else
                        return SteinMethod(Math.Abs(first - second) >> 1, second);
                }
            }
        }

        /// <summary>
        /// Method checks if for array is inputed correctly.
        /// </summary>
        /// <param name="array">Array, which will be checked.</param>
        /// <returns>True, if array is inputed correctly, and false otherwise.</returns>
        private static void CheckArray(int[] array)
        {
            if (array is null) throw new ArgumentNullException($"{nameof(array)} is null.");
            if (array.Length == 0) throw new ArgumentException($"{nameof(array)} is empty.");
            if (array.Length == 1) throw new ArgumentException($"{nameof(array)} has to take at least 2 elements.");
        }

    }
}
