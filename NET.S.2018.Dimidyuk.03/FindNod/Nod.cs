using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nod
{
    public class Nod
    {
        private delegate int FindNod(int first, int second);

        #region Euclid Methods
        /// <summary>
        /// Finds NOD using Euclid method for array of parameters.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(params int[] array) => FindNodMethod(Euclid, array);

        /// <summary>
        /// Finds NOD using Euclid method for three parameters.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>NOD of three parameters</returns>
        public static int Euclid(int first, int second, int third) => FindNodMethod(Euclid, first, second, third);

        /// <summary>
        /// Finds NOD using Euclid method for 2 parameters.
        /// </summary>
        /// <param name="first">Left parameter.</param>
        /// <param name="second">Right parameter.</param>
        /// <returns>NOD of two parameters.</returns>
        public static int Euclid(int first, int second) => FindNodMethod(EuclidMethod, first, second);
        #endregion

        #region Stein Methods
        /// <summary>
        /// Finds NOD using Stein method for array of parameters.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(params int[] array) => FindNodMethod(SteinMethod, array);

        /// <summary>
        /// Finds NOD using Stein method for three parameters.
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        /// <param name="third">The third parameter.</param>
        /// <returns>NOD of three parameters</returns>
        public static int Stein(int first, int second, int third) => FindNodMethod(SteinMethod, first, second, third);

        /// <summary>
        /// Finds NOD using Stein method for 2 parameters.
        /// </summary>
        /// <param name="first">The left number.</param>
        /// <param name="second">Right parameter.</param>
        /// <returns>NOD of two parameters.</returns>
        public static int Stein(int first, int second) => FindNodMethod(SteinMethod, first, second);
        
        #endregion

        #region Private Methods
        private static int FindNodMethod(FindNod find, int first, int second)
        {
            return find(first, second);
        }

        private static int FindNodMethod(FindNod find, int first, int second, int third)
        {
            return find(third, find(first, second));
        }

        private static int FindNodMethod(FindNod find, params int[] array)
        {
            CheckArray(array);

            int nod = find(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                nod = find(array[i], nod);
            }

            return nod;
        }

        private static int EuclidMethod(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

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

        private static int SteinMethod(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == second)
            {
                return first;
            }

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if (first == 1 || second == 1)
            {
                return 1;
            }

            if ((first & 1) == 0)
            {
                if ((second & 1) == 1)
                {
                    return SteinMethod(first >> 1, second);
                }
                else
                {
                    return SteinMethod(first >> 1, second >> 1) << 1;
                }
            }
            else
            {
                if ((second & 1) == 0)
                {
                    return SteinMethod(first, second >> 1);
                }
                else
                {
                    if (first < second)
                    {
                        return SteinMethod(first, Math.Abs(first - second) >> 1);
                    }
                    else
                    {
                        return SteinMethod(Math.Abs(first - second) >> 1, second);
                    }
                }
            }
        }


        /// <summary>
        /// Checks the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">array</exception>
        /// <exception cref="ArgumentException">array</exception>
        private static void CheckArray(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                throw new ArgumentException($"{nameof(array)} has to take at least 2 elements.");
            }
        }
        #endregion
    }
}
