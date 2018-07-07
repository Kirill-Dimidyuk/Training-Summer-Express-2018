using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DoubleToBinaryString
{
    /// <summary>
    /// Converts double into binary string
    /// </summary>
    public static class DoubleToBinaryString
    {
        /// <summary>
        /// Converts double number into bit representation.
        /// </summary>
        /// <param name="number">Double number to be converted.</param>
        /// <returns>String of bits.</returns>
        public static string DoubleToBinaryRepresentation(this double number)
        {
            NumberUnion union = new NumberUnion
            {
                DNumber = number
            };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                result.Append(((union.LNumber & 1) == 1) ? "1" : "0");
                union.LNumber >>= 1;
            }

            char[] resultArray = result.ToString().ToCharArray();
            Array.Reverse(resultArray);

            return new string(resultArray);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct NumberUnion
        {
            [FieldOffset(0)]
            public double DNumber;
            [FieldOffset(0)]
            public long LNumber;
        }
    }
}
