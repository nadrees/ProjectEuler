using System;
using System.Linq;
using Lib.Extensions;

namespace Lib
{
    /// <summary>
    /// Class that represents a fixed width integer. It stores up to n digits of a number,
    /// with higher digits being left off if they do not fit within the size of the number.
    /// </summary>
    public class FixedWidthInteger
    {
        // digits are stored in reverse order (lowest bit at index 0)
        private int?[] digits;

        #region Constructors
        private FixedWidthInteger() { }

        /// <summary>
        /// Creates a new FixedWidthInteger with the initial value specified
        /// and a size large enough to hold it.
        /// </summary>
        /// <param name="initialValue">The initial value of the FixedWidthInteger</param>
        public FixedWidthInteger(int initialValue) : this(initialValue, initialValue.ToString().Length) { }

        /// <summary>
        /// Creates a new FixedWidthInteger with the initial value and sizes specified.
        /// </summary>
        /// <param name="initialValue">The initial value of the FixedWidthInteger</param>
        /// <param name="width">
        /// The size of the FixedWidthInteger. If the size is too small to hold all of the
        /// digits of the initial value, the higher value digits (digits on the left) will
        /// be dropped until it does fit. If there is extra space, the extra digits will
        /// be 0.
        /// </param>
        public FixedWidthInteger(long initialValue, int width)
        {
            digits = new int?[width];

            var initialValueDigits = initialValue.ToString()
                                                 .GetDigits()
                                                 .Reverse()
                                                 .ToArray();

            for (var i = 0; i < width && i < initialValueDigits.Length; i++)
                digits[i] = initialValueDigits[i];
        }
        #endregion

        public override string ToString()
        {
            var str = String.Join(String.Empty, digits.Reverse()).TrimStart('0');
            if (str == String.Empty)
                str = "0";
            return str;
        }

        #region operator +
        /// <summary>
        /// Adds two fixed width integers together. The result is the addition of both integers, and the size
        /// is equal to the size of the smaller of the two integers.
        /// </summary>
        /// <param name="first">The first integer to add</param>
        /// <param name="second">The second integer to add</param>
        /// <returns>The sum of the two integers, with the size of the smaller of the two</returns>
        public static FixedWidthInteger operator +(FixedWidthInteger first, FixedWidthInteger second)
        {
            var result = new FixedWidthInteger();

            if (first.digits.Length < second.digits.Length)
            {
                result.digits = first.digits;
                result.AddDigits(second.digits);
            }
            else
            {
                result.digits = second.digits;
                result.AddDigits(first.digits);
            }

            return result;
        }

        public static FixedWidthInteger operator +(FixedWidthInteger fwi, int num)
        {
            return fwi + new FixedWidthInteger(num);
        }

        public static FixedWidthInteger operator +(int num, FixedWidthInteger fwi)
        {
            return fwi + new FixedWidthInteger(num);
        }

        private void AddDigits(int?[] otherDigits)
        {
            int overflow = 0;

            for (int i = 0; i < digits.Length && i < otherDigits.Length; i++)
            {
                int digitSum = (digits[i] ?? 0) + (otherDigits[i] ?? 0) + overflow;
                if (digitSum >= 10)
                {
                    overflow = digitSum / 10;
                    digitSum = digitSum % 10;
                }
                else
                    overflow = 0;

                digits[i] = digitSum;
            }
        }
        #endregion

        #region operator *
        /// <summary>
        /// Multiplies the two FixedWidthIntegers together. The product will have the same length as
        /// the shorter of the two integers.
        /// </summary>
        /// <param name="first">The first number to be multiplied.</param>
        /// <param name="second">The second number to be multiplied.</param>
        /// <returns>The product of first and second, with the length of the shorter of the two numbers.</returns>
        public static FixedWidthInteger operator *(FixedWidthInteger first, FixedWidthInteger second)
        {
            var firstNum = long.Parse(first.ToString());
            var secondNum = long.Parse(second.ToString());

            var ans = firstNum * secondNum;

            return new FixedWidthInteger(ans, first.digits.Length < second.digits.Length ? first.digits.Length : second.digits.Length);
        }

        public static FixedWidthInteger operator *(FixedWidthInteger fwi, int num)
        {
            return fwi * new FixedWidthInteger(num);
        }

        public static FixedWidthInteger operator *(int num, FixedWidthInteger fwi)
        {
            return fwi * new FixedWidthInteger(num);
        }
        #endregion

        #region operator ^
        public static FixedWidthInteger operator ^(FixedWidthInteger fwi, int power)
        {
            var answer = new FixedWidthInteger();
            answer.digits = fwi.digits;

            for (int i = 1; i < power; i++)
                answer *= fwi;

            return answer;
        }
        #endregion
    }
}
