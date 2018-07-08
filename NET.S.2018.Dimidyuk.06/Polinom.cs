using System;
using System.Text;

namespace Polinom
{
    /// <summary>
    /// Polinomial
    /// </summary>
    public sealed class Polynomial :  IEquatable<Polynomial>
    {
        #region public fields
        /// <summary>
        /// Gets max degree of polynom.
        /// </summary>
        public int Degree { get; }
        #endregion

        #region private fields
        private readonly СoefficientArray coefficientArray;
        private static double Eps { get; }
        #endregion

        #region struct СoefficientArray
        /// <summary>
        /// Struct for interact with an array of coefficients.
        /// </summary>
        private struct СoefficientArray
        {
            private double[] array;
            public int Length;

            public СoefficientArray(params double[] inputArray)
            {
                int index;
                for (index = inputArray.Length - 1; index >= 0; index--)
                {
                    if (inputArray[index] != 0)
                    {
                        break;
                    }

                }

                array = new double[index + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    if (inputArray[i] >= Eps)
                    {
                        array[i] = inputArray[i];
                    }
                }

                Length = array.Length;
            }

            public double[] GetArray()
            {
                double[] result = new double[array.Length];
                array.CopyTo(result, 0);
                return result;
            }

            public double this[int i]
            {
                get
                {
                    if (i < 0 || i >= Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i));
                    }

                    return array[i];
                }
            }
        }
        #endregion

        #region ctors
        /// <summary>
        /// Ctor for Polynomial instance.
        /// </summary>
        /// <param name="inputCoefficientArray">Double array of coefficients.</param>
        public Polynomial(params double[] inputCoefficientArray)
        {
            if (inputCoefficientArray == null)
            {
                throw new ArgumentNullException($"{ nameof(inputCoefficientArray) } is null.");
            }

            if (inputCoefficientArray.Length == 0)
            {
                throw new ArgumentException($"{ nameof(inputCoefficientArray) } is empty.");
            }

            coefficientArray = new СoefficientArray(inputCoefficientArray);
            Degree = coefficientArray.Length - 1;
        }

        /// <summary>
        /// Ctor for Polynomial instance.
        /// </summary>
        /// <param name="polynomial">Polynomial instance.</param>
        public Polynomial(Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"{ nameof(polynomial) } is null.");
            }

            coefficientArray = new СoefficientArray(polynomial.coefficientArray.GetArray());
            Degree = coefficientArray.Length - 1;
        }
        #endregion

        #region public methods

        #region overrided methods
        /// <summary>
        /// Converts instance into string representation.
        /// </summary>
        /// <returns>String representation of an instance.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < coefficientArray.Length; i++)
            {
                if (coefficientArray[i] == 0)
                {
                    continue;
                }

                if (coefficientArray[i] < 0)
                {
                    result.Append("(" + coefficientArray[i].ToString() + ")");
                }

                if (coefficientArray[i] > 0)
                {
                    result.Append(coefficientArray[i].ToString());
                }

                if (i != 0)
                {
                    result.Append("*" + "(x^" + i + ")");
                }

                if (i != coefficientArray.Length - 1)
                {
                    result.Append(" + ");
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="obj">One of the objects.</param>
        /// <returns>True, if objects are equal, and false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return Equals(obj as Polynomial);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region overloaded operators +,-,*,==,!=
        /// <summary>
        /// Finds the sum of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Sum of two polynomials.</returns>
        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            CheckData(polynomial1, polynomial2);

            int sizeMax = (polynomial1.Degree >= polynomial2.Degree) ? polynomial1.Degree + 1 : polynomial2.Degree + 1;
            double[] arrayResult = new double[sizeMax];

            for (int i = 0; i < sizeMax; i++)
            {
                if (i >= polynomial1.coefficientArray.Length)
                {
                    arrayResult[i] += polynomial2.coefficientArray[i];
                    continue;
                }

                if (i >= polynomial2.coefficientArray.Length)
                {
                    arrayResult[i] += polynomial1.coefficientArray[i];
                    continue;
                }

                arrayResult[i] = polynomial1.coefficientArray[i] + polynomial2.coefficientArray[i];
            }

            return new Polynomial(arrayResult);
        }

        /// <summary>
        /// Finds the difference of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Difference of two polynomials.</returns>
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            CheckData(polynomial1, polynomial2);

            int sizeMax = (polynomial1.Degree >= polynomial2.Degree) ? polynomial1.Degree + 1 : polynomial2.Degree + 1;
            double[] arrayResult = new double[sizeMax];

            for (int i = 0; i < sizeMax; i++)
            {
                if (i >= polynomial1.coefficientArray.Length)
                {
                    arrayResult[i] -= polynomial2.coefficientArray[i];
                    continue;
                }

                if (i >= polynomial2.coefficientArray.Length)
                {
                    arrayResult[i] += polynomial1.coefficientArray[i];
                    continue;
                }

                arrayResult[i] = polynomial1.coefficientArray[i] - polynomial2.coefficientArray[i];
            }

            return new Polynomial(arrayResult);
        }

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Multiplying of two polynomials.</returns>
        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            CheckData(polynomial1, polynomial2);

            int size = polynomial1.Degree + polynomial2.Degree + 1;
            double[] arrayResult = new double[size];

            for (int i = 0; i < polynomial1.coefficientArray.Length; i++)
            {
                for (int j = 0; j < polynomial2.coefficientArray.Length; j++)
                {
                    arrayResult[i + j] += polynomial1.coefficientArray[i] * polynomial2.coefficientArray[j];
                }
            }

            return new Polynomial(arrayResult);
        }

        /// <summary>
        /// Checks for equality of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>True, if objects are equal, and false otherwise.</returns>
        public static bool operator ==(Polynomial polynomial1, Polynomial polynomial2)
        {
            CheckData(polynomial1, polynomial2);
            return polynomial1.Equals(polynomial2);
        }

        /// <summary>
        /// Checks for inequality of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>True, if objects aren't equal, and false otherwise.</returns>
        public static bool operator !=(Polynomial polynomial1, Polynomial polynomial2)
        {
            CheckData(polynomial1, polynomial2);
            return !polynomial1.Equals(polynomial2);
        }
        #endregion

        #region Add, Subtract, Multiply
        /// <summary>
        /// Finds the sum of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Sum of two polynomials.</returns>
        public static Polynomial Add(Polynomial polynomial1, Polynomial polynomial2) => polynomial1 + polynomial2;

        /// <summary>
        /// Finds the difference of two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Difference of two polynomials.</returns>
        public static Polynomial Subtract(Polynomial polynomial1, Polynomial polynomial2) => polynomial1 - polynomial2;

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Multiplying of two polynomials.</returns>
        public static Polynomial Multiply(Polynomial polynomial1, Polynomial polynomial2) => polynomial1 * polynomial2;
        #endregion

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="polinom">One of the polynomials.</param>
        /// <returns>True, if polynomials are equal, and false otherwise.</returns>
        public bool Equals(Polynomial polinom)
        {
            if (polinom is null)
            {
                return false;
            }

            if (ReferenceEquals(polinom, this))
            {
                return true;
            }

            return EqualsCoefArray(polinom.coefficientArray);
        }
        #endregion

        #region private methods
        private bool EqualsCoefArray(СoefficientArray inputCoefArray)
        {
            if (this.coefficientArray.Length != inputCoefArray.Length)
            {
                return false;
            }

            for (int i = 0; i < inputCoefArray.Length; i++)
            {
                if (inputCoefArray[i] != this.coefficientArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static void CheckData(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 is null && polynomial2 is null)
            {
                throw new ArgumentNullException($"{ nameof(polynomial1) } and { nameof(polynomial2) } are null.");
            }

            if (polynomial1 is null)
            {
                throw new ArgumentNullException($"{ nameof(polynomial1) } is null.");
            }

            if (polynomial2 is null)
            {
                throw new ArgumentNullException($"{ nameof(polynomial2) } is null.");
            }
        }
        #endregion
    }
}
