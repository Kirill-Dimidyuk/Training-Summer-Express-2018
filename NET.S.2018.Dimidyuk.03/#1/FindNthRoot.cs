using System;

namespace FindNthRoot
{
    public class FindNthRoot
    {
        #region NewtonMethod
        /// <summary>
        /// Method for finding the root of n degree of a number with a given accuracy.
        /// </summary>
        /// <param name="number">Number for taking a root.</param>
        /// <param name="n">Degree.</param>
        /// <param name="accuracy">Calculation accuracy.</param>
        /// <returns></returns>
        public static double NewtonMethod(double number, double n, double accuracy)
        {
            CheckData(number, n, accuracy);

            double x0 = number / n;
            double x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));
            }

            return x1;
        }
        #endregion

        #region CheckData
        ///<summary>
        ///Method for checking given data in method
        ///</summary>
        ///<param name="number">Number for taking a root.</param>
        ///<param name="n">Degree.</param>
        /// <param name="accuracy">Calculation accuracy.</param>
        /// <returns></returns>
        private static void CheckData(double number, double n, double accuracy)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Incorrect input of {nameof(number)}.");
            }

            if (n < 0)
            {
                throw new ArgumentException($"Incorrect input of {nameof(n)}.");
            }

            if (accuracy < 0)
            {
                throw new ArgumentException($"Incorrect input of {nameof(accuracy)}.");
            }
        }
        #endregion
    }
}
