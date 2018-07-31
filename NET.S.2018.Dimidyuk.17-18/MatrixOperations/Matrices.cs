using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace Matrices
{
    #region Abstract Matrix    
    /// <summary>
    /// Class for reperezentation abstract matrix
    /// </summary>
    public abstract class AbstractMatrix<T> : IEnumerable<T>
    {
        private int size = 1;

        /// <summary>
        /// Size of the matrix.
        /// </summary>
        public int Size
        {
            get => size;
            set
            {
                CheckSize(value);
                size = value;
            }
        }

        /// <summary>
        /// Changes event.
        /// </summary>
        public event EventHandler<ChangeElementEventArgs> NewElement = delegate { };

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Number of row.</param>
        /// <param name="j">Number of column.</param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i - 1, j - 1);
                return GetElement(i - 1, j - 1);
            }
            set
            {
                CheckIndexes(i - 1, j - 1);
                SetElement(value, i - 1, j - 1);
                OnNewElement(new ChangeElementEventArgs(GetType().ToString(), i, j));
            }
        }

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(T element, int i, int j);

        protected virtual void OnNewElement(ChangeElementEventArgs args)
        {
            NewElement.Invoke(this, args);
        }

        private void CheckSize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} can't be less than or equal to 0.");
            }
        }

        protected void CheckIndexes(int i, int j)
        {
            if (i >= Size || i < 0)
            {
                throw new ArgumentException($"Index {nameof(i)} is unsuitable.");
            }

            if (j >= Size || j < 0)
            {
                throw new ArgumentException($"Index {nameof(j)} is unsuitable.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i <= Size; i++)
            {
                for (int j = 1; j <= Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    #endregion

    #region Square Matrix
    /// <summary>
    /// Class for representation of the square matrix.
    /// </summary>
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        private T[,] array;

        #region ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public SquareMatrix()
        {
            array = new T[Size, Size];
        }

        /// <summary>
        /// Ctor with parameter.
        /// </summary>
        /// <param name="size">Size of the square matrix.</param>
        public SquareMatrix(int size)
        {
            Size = size;
            array = new T[Size, Size];
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="size">Size of the square matrix.</param>
        /// <param name="inputArray">Collection to fill square matrix.</param>
        public SquareMatrix(int size, IEnumerable<T> inputArray) : this(size)
        {
            FillMatrix(inputArray);
        }
        #endregion

        #region private and protected methods
        private void FillMatrix(IEnumerable<T> inputArray)
        {
            if (inputArray == null) throw new ArgumentNullException($"{nameof(inputArray)} is null.");

            int inputArrayIndex = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (inputArrayIndex < inputArray.Count())
                    {
                        array[i, j] = inputArray.ElementAt(inputArrayIndex);
                    }

                    inputArrayIndex++;
                }
            }
        }

        protected override T GetElement(int i, int j)
        {
            CheckIndexes(i, j);
            return array[i, j];
        }

        protected override void SetElement(T element, int i, int j)
        {
            CheckIndexes(i, j);

            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} is null.");
            }

            array[i, j] = element;
        }
        #endregion
    }
    #endregion

    #region Symmetric Matrix
    /// <summary>
    /// Class for the representation of the symmetric matrix.
    /// </summary>
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        #region fields
        private T[][] array;
        #endregion

        #region ctors
        /// <summary>
        /// Ctor without parameter.
        /// </summary>
        public SymmetricMatrix()
        {
            array = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                array[i] = new T[i + 1];
            }
        }

        /// <summary>
        /// Ctor with parameter.
        /// </summary>
        /// <param name="size">Size of the symmetric matrix.</param>
        public SymmetricMatrix(int size)
        {
            Size = size;
            array = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                array[i] = new T[i + 1];
            }
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="size">Size of the symmetric matrix.</param>
        /// <param name="inputArray">Collection to fill symmetric matrix.</param>
        public SymmetricMatrix(int size, IEnumerable<T> inputArray) : this(size)
        {
            FillMatrix(inputArray);
        }
        #endregion

        #region private & protected methods
        private void FillMatrix(IEnumerable<T> inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"{nameof(inputArray)} is null.");
            }

            int inputArrayIndex = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (inputArrayIndex < inputArray.Count())
                    {
                        array[i][j] = inputArray.ElementAt(inputArrayIndex);
                    }

                    inputArrayIndex++;
                }
            }
        }

        protected override T GetElement(int i, int j)
        {
            CheckIndexes(i, j);
            return (j <= i) ? array[i][j] : array[j][i];
        }

        protected override void SetElement(T element, int i, int j) //changes elements on (i,j) and (j,i)
        {
            CheckIndexes(i, j);
            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} is null.");
            }

            if (j <= i)
            {
                array[i][j] = element;
            }
            else
            {
                array[j][i] = element;
            }
        }
        #endregion
    }
    #endregion

    #region Diagonal Matrix
    /// <summary>
    /// Class for representation of the diagonal matrix.
    /// </summary>
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        #region fields
        private T[] array;
        #endregion

        #region ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public DiagonalMatrix()
        {
            array = new T[Size];
        }

        /// <summary>
        /// Ctor with parameter.
        /// </summary>
        /// <param name="size">Size of the diagonal matrix.</param>
        public DiagonalMatrix(int size)
        {
            Size = size;
            array = new T[Size];
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="size">Size of the diagonal matrix.</param>
        /// <param name="inputArray">Collection to fill diagonal matrix.</param>
        public DiagonalMatrix(int size, IEnumerable<T> inputArray) : this(size)
        {
            FillMatrix(inputArray);
        }
        #endregion

        #region private & protected methods
        private void FillMatrix(IEnumerable<T> inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"{nameof(inputArray)} is null.");
            }

            int inputArrayIndex = 0;

            for (int i = 0; i < Size; i++)
            {
                if (inputArrayIndex < inputArray.Count())
                {
                    array[i] = inputArray.ElementAt(inputArrayIndex);
                }

                inputArrayIndex++;
            }
        }

        protected override T GetElement(int i, int j)
        {
            CheckIndexes(i, j);

            return (i != j) ? default(T) : array[i];
        }

        protected override void SetElement(T element, int i, int j)
        {
            if (i != j)
            {
                throw new ArgumentException("You can't change element which is not on the diagonal.");
            }

            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} is null.");
            }

            CheckIndexes(i, j);

            array[i] = element;
        }
        #endregion
    }
    #endregion

    #region Matrix Operations
    /// <summary>
    /// Class contains operations for matrices.
    /// </summary>
    public static class MatrixOperation
    {
        /// <summary>
        /// Adds one matrix to another.
        /// </summary>
        /// <param name="lhs">One matrix to sum.</param>
        /// <param name="rhs">Second matrix to sum.</param>
        /// <returns>Matrix-result of summation.</returns>
        public static AbstractMatrix<T> Sum<T>(this AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null.");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null.");
            }

            if (lhs.Size != rhs.Size)
            {
                throw new ArgumentException($"{nameof(lhs)} and {nameof(rhs)} have different sizes and can't be summarized.");
            }

            T[,] result = new T[lhs.Size, lhs.Size];
            try
            {
                for (int i = 1; i <= result.GetLength(0); i++)
                {
                    for (int j = 1; j <= result.GetLength(1); j++)
                    {
                        result[i - 1, j - 1] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }
            catch (RuntimeBinderException)
            {
                throw new ArgumentException($"Operation '+' is not defined for type {nameof(T)}.");
            }

            return MatrixFactory.Create<T>(lhs.Size, result);
        }
    }
    #endregion

    #region Matrix Factory
    /// <summary>
    /// Creates different matrices based on the input values.
    /// </summary>
    internal static class MatrixFactory
    {
        /// <summary>
        /// Creates new matrix based on the input values.
        /// </summary>
        /// <param name="size">Size of the square matrix.</param>
        /// <param name="values">Values to insert into new matrix.</param>
        /// <returns>New matrix of the suitable type.</returns>
        public static AbstractMatrix<T> Create<T>(int size, T[,] values)
        {
            if (IsDiagonal<T>(values))
            {
                return new DiagonalMatrix<T>(size, GetValuesForDiagonal<T>(size, values));
            }
            else if (IsSymmetric<T>(values))
            {
                return new SymmetricMatrix<T>(size, GetValuesForSymmetric<T>(size, values));
            }
            else
            {
                return new SquareMatrix<T>(size, GetValuesForSquare<T>(size, values));
            }
        }

        #region gets matrix type
        private static bool IsDiagonal<T>(T[,] values)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (i != j && !values[i, j].Equals(default(T))) return false;
                }
            }
            return true;
        }

        private static bool IsSymmetric<T>(T[,] values)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (!values[i, j].Equals(values[j, i])) return false;
                }
            }
            return true;
        }
        #endregion

        #region gets values for insert in a suitable form
        private static T[] GetValuesForSquare<T>(int size, T[,] values)
        {
            T[] result = new T[size * size];
            int indexRes = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    result[indexRes++] = values[i, j];
                }
            }
            return result;
        }

        private static T[] GetValuesForSymmetric<T>(int size, T[,] values)
        {
            T[] result = new T[size * (size + 1) / 2];
            int indexRes = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[indexRes++] = values[i, j];
                }
            }
            return result;
        }

        private static T[] GetValuesForDiagonal<T>(int size, T[,] values)
        {
            T[] result = new T[size];
            int indexRes = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                    {
                        result[indexRes++] = values[i, j];
                    }
                }
            }
            return result;
        }
        #endregion
    }
    #endregion

    #region Martrix Comparer
    /// <summary>
    /// Compare two matrices
    /// </summary>
    public class MatrixComparer<T> : IEqualityComparer<AbstractMatrix<T>>
    {
        public bool Equals(AbstractMatrix<T> x, AbstractMatrix<T> y)
        {
            if (x is null)
            {
                return false;
            }

            if (y is null)
            {
                return false;
            }

            if (x.Size != y.Size)
            {
                return false;
            }

            if (ReferenceEquals(x, y))
            {
                return true;
            }

            for (int i = 1; i <= x.Size; i++)
            {
                for (int j = 1; j <= x.Size; j++)
                {
                    if (!x[i, j].Equals(y[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int GetHashCode(AbstractMatrix<T> obj)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Event
    /// <summary>
    /// Class contains data about change element event.
    /// </summary>
    public class ChangeElementEventArgs : EventArgs
    {
        #region properties
        /// <summary>
        /// Info about event.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Number of a row where element was changed.
        /// </summary>
        public int I { get; }

        /// <summary>
        /// Number of a column where element was changed.
        /// </summary>
        public int J { get; }
        #endregion

        #region ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="message">Info about event.</param>
        /// <param name="i">Number of a row where element was changed.</param>
        /// <param name="j">Number of a column where element was changed.</param>
        public ChangeElementEventArgs(string message, int i, int j)
        {
            Message = message;
            I = i;
            J = j;
        }
        #endregion
    }
    #endregion
}
