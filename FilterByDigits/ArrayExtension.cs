using System;
using System.Diagnostics.Tracing;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns true if number contains given digit othervise returns false.
        /// </summary>
        public static bool IsNumberRight(int number, int digit)
        {
            if (number < 0)
            {
                number = -number;
            }

            int rest = number % 10;
            do
            {
                if (rest == digit)
                {
                    return true;
                }

                number /= 10;
                rest = number % 10;
            }
            while (number != 0);

            return false;
        }

        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[]? source, int digit)
        {
            if (digit > 9 | digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "digit value is out of range (0..9).");
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "array is null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty.");
            }

            List<int> result = new List<int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (IsNumberRight(source[i], digit))
                {
                    result.Add(source[i]);
                }
            }

            return result.ToArray();
        }
    }
}
