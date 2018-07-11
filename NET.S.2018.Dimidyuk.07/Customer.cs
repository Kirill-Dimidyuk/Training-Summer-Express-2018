using System;
using System.Globalization;

namespace Customer
{
    public class Customer : IFormattable
    {
        #region Properties
        /// <summary>
        /// String property Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// String property Contact Phone.
        /// </summary>
        public string ContactPhone { get; private set; }

        /// <summary>
        /// Decimal property Revenue.
        /// </summary>
        public decimal Revenue { get; private set; }
        #endregion

        #region Ctor
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="name">Name of the customer.</param>
        /// <param name="phone">Contact phone of the customer.</param>
        /// <param name="revenue">Revenue of the customer.</param>
        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Overriding method converts Customer object into string representation with general format.
        /// </summary>
        /// <returns>String representation of the customer.</returns>
        public override string ToString()
        {
            return this.ToString("1", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts Customer object into string representation.
        /// </summary>
        /// <param name="format">Format of string representation.</param>
        /// <returns>String representation of the customer.</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts Customer object into string representation.
        /// </summary>
        /// <param name="format">Format of string representation.</param>
        /// <param name="formatProvider">Format provider.</param>
        /// <returns>String representation of the customer.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "1";
            }

            if (formatProvider is null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format)
            {
                case "1":
                    return $"Customer record: {Name}, {Revenue.ToString("N", NumberFormatInfo.InvariantInfo)}, {ContactPhone}";
                case "2":
                    return $"Customer record: {ContactPhone}";
                case "3":
                    return $"Customer record: {Name}, {Revenue.ToString("N", NumberFormatInfo.InvariantInfo)}";
                case "4":
                    return $"Customer record: {Name}";
                case "5":
                    return $"Customer record: {Revenue}";
                default:
                    throw new FormatException($"This format {format} is not supported.");
            }
        }
        #endregion

    }
}
