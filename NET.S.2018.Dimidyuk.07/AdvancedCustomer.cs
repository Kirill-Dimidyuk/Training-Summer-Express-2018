using System;
using System.Globalization;
using System.Text;

namespace AdvancedCustomer
{
    public class AdvancedCustomer : ICustomFormatter, IFormatProvider
    {
        #region private fields
        private readonly IFormatProvider parentFormatProvider;

        private readonly string[] _numberWords = "zero one two three four five six seven eight nine minus point".Split();
        #endregion

        #region ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public AdvancedCustomer() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Ctor with parameter.
        /// </summary>
        /// <param name="parent">Format provider.</param>
        public AdvancedCustomer(IFormatProvider parent)
        {
            parentFormatProvider = parent;
        }
        #endregion


        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Converts Customer object into string representation using additional formats.
        /// </summary>
        /// <param name="format">Format of string representation.</param>
        /// <param name="obj">Customer object for converting.</param>
        /// <param name="formatProvider">Format provider.</param>
        /// <returns>String representation of the customer.</returns>
        public string Format(string format, object obj, IFormatProvider formatProvider)
        {
            Customer.Customer customer = obj as Customer.Customer;
            if (customer is null)
            {
                throw new ArgumentNullException($"{nameof(customer)} is null.");
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "1+";
            }

            if (formatProvider is null)
            {
                formatProvider = parentFormatProvider;
            }

            switch (format)
            {
                case "1+":
                    return $"Customer record: Name - {customer.Name}, Revenue - {customer.Revenue.ToString("N", NumberFormatInfo.InvariantInfo)}, Phone - {customer.ContactPhone}";
                case "2+":
                    return $"Customer record: Phone - {customer.ContactPhone}";
                case "3+":
                    return $"Customer record: Name - {customer.Name}, Revenue - {customer.Revenue.ToString("N", NumberFormatInfo.InvariantInfo)}";
                case "4+":
                    return $"Customer record: Name - {customer.Name}";
                case "5+":
                    return $"Customer record: Revenue - {customer.Revenue}";
                case "6+":
                    return $"Customer record: Revenue - {NumberIntoWords((double)customer.Revenue)}";
                default:
                    throw new FormatException($"This format {format} is not supported.");
            }
        }

        public string NumberIntoWords(double number)
        {
            StringBuilder result = new StringBuilder();
            string digitList = number.ToString();
            foreach (char digit in digitList)
            {
                int i = "0123456789+-.".IndexOf(digit);
                if (i == -1) continue;
                if (result.Length > 0) result.Append(' ');
                result.Append(_numberWords[i]);
            }
            return result.ToString();
        }
    }
}
