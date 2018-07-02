using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber
{
    public class NextBiggerNumber
    {

        #region NextBiggerNumber
        /// <summary>
        /// Method searches the nearest greatest integer which consists of digits of the input number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>The nearest greatest integer (returns -1, if integer doesn't exist).</returns>
        public static int TheNextBiggerNumber(int number)
        {
            if (!CheckNumber(number))
            {
                return -1;
            }

            string numberString = number.ToString();
            char[] numberCharArray = numberString.ToCharArray();
            Array.Sort(numberCharArray);

            while (true)
            {
                number++;
                string newNumberString = number.ToString();
                char[] newNumberCharArray = newNumberString.ToCharArray();
                Array.Sort(newNumberCharArray);
                if (string.Concat(newNumberCharArray) == string.Concat(numberCharArray))
                {
                    return number;
                }
            }
        }

        #region NextBiggerNumberWithTime
        /// <summary>
        /// Method searches the nearest greatest integer which consists of digits of the input number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>The tuple of greatest integer and date and time of finding.</returns>
        public static Tuple<int, DateTime> NextBiggerNumberWithTimeUsingTuple(int number)
        {
            return Tuple.Create(TheNextBiggerNumber(number), DateTime.Now);
        }

        /// <summary>
        /// Method searches the nearest greatest integer which consists of digits of the input number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <param name="date">Date and time of finding.</param>
        /// <returns>The nearest greatest integer (returns -1, if integer doesn't exist).</returns>
        public static int NextBiggerNumberWithTimeUsingOut(int number, out DateTime date)
        {
            date = DateTime.Now;
            return TheNextBiggerNumber(number);
        }
        #endregion

        /// <summary>
        /// Method checks if for input number exists the nearest greatest integer which consists of the digits of the input number.
        /// </summary>
        /// <param name="number">Integer, which will be checked.</param>
        /// <returns>True, if for input number exists the nearest greatest integer, and false otherwise.</returns>
        private static bool CheckNumber(int number)
        {
            string numberString = number.ToString();

            string newNumberString = number.ToString();
            char[] newNumberCharArray = newNumberString.ToCharArray();
            Array.Sort(newNumberCharArray);
            Array.Reverse(newNumberCharArray);

            return numberString != string.Concat(newNumberCharArray);
        }
        #endregion

    }
}
