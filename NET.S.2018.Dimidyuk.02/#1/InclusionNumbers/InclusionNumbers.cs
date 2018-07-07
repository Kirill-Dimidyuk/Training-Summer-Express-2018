using System;

namespace InclusionNumbers
{
    /// <summary>
    /// Includes one number into another
    /// </summary>
    public static class InclusionNumbers
    {
        private static readonly int MaxInt = 0x7fffffff;
        private static readonly int QuantityOfBits = 31;

        /// <summary>
        /// Inserts the first number into the second number.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="finishPosition">The finish position.</param>
        /// <returns>Inserted number or exceptions</returns>
        public static int Insertion(int first, int second, int startPosition, int finishPosition)
        {
            CheckPosition(startPosition, finishPosition);

            int maskSecondNumber = MaxInt >> QuantityOfBits - (finishPosition - startPosition + 1);
            maskSecondNumber &= second;
            maskSecondNumber <<= startPosition;

            int maskLeft = MaxInt << (finishPosition + 1);
            maskLeft &= first;

            int maskRight = MaxInt >> QuantityOfBits - startPosition;
            maskRight &= first;

            return maskLeft ^ maskSecondNumber ^ maskRight;
        }

        /// <summary>
        /// Checks positions.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        /// <param name="finishPosition">The finish position.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Incorrect input start positions.
        /// or
        /// Incorrect input finish positions.
        /// </exception>
        /// <exception cref="ArgumentException">Incorrect input positions.</exception>
        private static void CheckPosition(int startPosition, int finishPosition)
        {
            if (startPosition < 0 || startPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input start positions.");
            }

            if (finishPosition < 0 || finishPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input finish positions.");
            }

            if (finishPosition < startPosition)
            {
                throw new ArgumentException("Incorrect input positions.");
            }
        }
    }
}