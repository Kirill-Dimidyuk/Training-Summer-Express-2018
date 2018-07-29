using System.Collections.Generic;
using System;
using System.Numerics;

namespace FibonacciNumbers
{
    /// <summary>
    /// Class for generating numbers Fibnacci
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Metod for generating numbers Fibnacci
        /// </summary>
        /// <param name="count">Number of numbers</param>
        /// <returns></returns>
        public static BigInteger[] Fibonacci(int count)
        {
            CheckData(count);

            BigInteger[] array = new BigInteger[count];

            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i < count; i++) 
            {
                array[i] = array[i - 2] + array[i - 1];
            }

            return array;
        }

        /// <summary>
        /// Checks the count.
        /// </summary>
        /// <param name="count">The number of parameters</param>
        /// <exception cref="ArgumentException">count</exception>
        private static void CheckData(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} must be more than zero");
            }
        }
    }
}
