using System;

namespace InclusionNumbers
{
    public static class InclusionNumbers
    {
        private static int maxInt = 0x7fffffff;
        private static int quantityOfBits = 31;

       
        public static int Insertion(int first, int second, int startPosition, int finishPosition)
        {
            CheckPosition(startPosition, finishPosition);

            int maskSecondNumber = maxInt >> quantityOfBits - (finishPosition - startPosition + 1);
            maskSecondNumber &= second;
            maskSecondNumber <<= startPosition;

            int maskLeft = maxInt << (finishPosition + 1);
            maskLeft &= first;

            int maskRight = maxInt >> quantityOfBits - startPosition;
            maskRight &= first;

            return maskLeft ^ maskSecondNumber ^ maskRight;

        }


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