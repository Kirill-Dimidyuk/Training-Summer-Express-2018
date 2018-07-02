using System;
using System.Linq;


namespace JaggedMassive
{
    public static class JaggedArray
    {
        public static void SortMassive<T>(this T[][] JaggedArray, IComparement<T> comparement)
        {
            if (JaggedArray == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(JaggedArray)} can't be null");
            }


            if (comparement == null)
            {
                throw new ArgumentNullException($"The value of parameter{nameof(comparement)} can't be null");
            }

            bool indicator = true;

            while (indicator)
            {
                indicator = false;
                for (int i = 0; i < JaggedArray.Length - 1; i++)
                {
                    if (comparement.Comparement(JaggedArray[i], JaggedArray[i + 1]) > 0)
                    {
                        Swap(ref JaggedArray[i], ref JaggedArray[i + 1]);
                        indicator = true;
                    }
                }
            }

        }

        #region SumIncreasing

        public class SumIncreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return -1;
                }
                if (SecondNumber == null)
                {
                    return 1;
                }

                return FirstNumber.Sum() - SecondNumber.Sum();
            }
        }

        #endregion

        #region SumDecreasing

        public class SumDecreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return 1;
                }
                if (SecondNumber == null)
                {
                    return -1;
                }

                return SecondNumber.Sum() - FirstNumber.Sum();
            }
        }

        #endregion

        #region MaxIncreasing

        public class MaxIncreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return -1;
                }
                if (SecondNumber == null)
                {
                    return 1;
                }

                return FirstNumber.Max() - SecondNumber.Max();
            }
        }

        #endregion

        #region MaxDecreasing

        public class MaxDecreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return 1;
                }
                if (SecondNumber == null)
                {
                    return -1;
                }

                return SecondNumber.Max() - FirstNumber.Max();
            }
        }

        #endregion

        #region MinIncreasing

        public class MinIncreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return -1;
                }
                if (SecondNumber == null)
                {
                    return 1;
                }

                return FirstNumber.Min() - SecondNumber.Min();
            }
        }

        #endregion

        #region MinDecreasing

        public class MinDecreasing : IComparement<int>
        {
            public int Comparement(int[] FirstNumber, int[] SecondNumber)
            {
                if (FirstNumber == null && SecondNumber == null)
                {
                    return 0;
                }
                if (FirstNumber == null)
                {
                    return 1;
                }
                if (SecondNumber == null)
                {
                    return -1;
                }

                return SecondNumber.Min() - FirstNumber.Min();
            }
        }

        #endregion

        private static void Swap<T>(ref T[] a, ref T[] b)
        {
            T[] tmp = a;
            a = b;
            b = tmp;
        }

        public interface IComparement<T>
        {
            int Comparement(T[] FirstNumber, T[] SecondNumber);
        }
    }
}
