using System;

namespace StringToDecimal
{
    /// <summary>
    /// Converts string to decimal
    /// </summary>
    public static class StringToDecimal
    {
        /// <summary>
        /// Converts string to any notation from 2 to 16.
        /// </summary>
        /// <param name="source">Input string</param>
        /// <param name="notation">The notation for converting</param>
        /// <returns>Decimal number or exceptions</returns>
        public static int ConvertingToDecimal(this string source, Notation notation)
        {
            CheckData(source, notation);
            return StringToDecimalNumber(source, notation);
        }

        /// <summary>
        /// Returns converted string.
        /// </summary>
        /// <param name="source">Input string</param>
        /// <param name="notation">The notation for converting</param>
        /// <returns>Decimal number</returns>
        private static int StringToDecimalNumber(this string source, Notation notation)
        {
            int result = 0;
            for (int i = 0, j = source.Length - 1; i < source.Length; i++)
            {
                result += (int)Math.Pow(notation.Scale, j - i) * notation.Alphabet.IndexOf(source[i].ToString().ToUpper());
            }

            return result;
        }

        /// <summary>
        /// Method for checking input data
        /// </summary>
        /// <param name="source">Input string number</param>
        /// <param name="notation">The notation for converting</param>
        /// <exception cref="ArgumentNullException">Throws when input source is null or empty.</exception>    
        /// <exception cref="ArgumentException">Throws when scale of notation isn't from 2 to 16 .</exception>
        /// <exception cref="OverflowException">Throws when the source.Length is greater than capacity of Int32.</exception>
        private static void CheckData(this string source, Notation notation)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException($"{nameof(source)} is null or empty.");
            }

            if (source.Length >= sizeof(int) * 8)
            {
                throw new ArgumentException($"The {nameof(notation.Scale)} of an notation must be from 2 to 16.");
            }

            if (notation.Scale < 2 || notation.Scale > 16)
            {
                throw new ArgumentException($"The {nameof(notation.Scale)} of an notation must be from 2 to 16.");
            }

            if (source.Length >= sizeof(int) * 8)
            {
                throw new OverflowException($"Length of {nameof(source)} should be less than 32.");
            }
        }
    }

    /// <summary>
    /// The notation for converting
    /// </summary>
    public class Notation
    {
        private readonly string alphabetOfTypes = "0123456789ABCDEF";

        public Notation(int scale) => Scale = scale;

        public string Alphabet => alphabetOfTypes.Substring(0, Scale);

        public int Scale { get; }
    }
}
