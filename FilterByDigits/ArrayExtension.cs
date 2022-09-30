using System;
using System.Diagnostics.Tracing;

namespace FilterTask
{
    public static class ArrayExtension
    {
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
                throw new ArgumentOutOfRangeException("digit value is out of range (0..9).");
            }

            if (source == null)
            {
                throw new ArgumentNullException("array is null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty.");
            }

            List<int> result = new List<int>();
            foreach (int num in source)
            {
                string numStr = num.ToString();
                foreach (char charNum in numStr)
                {
                    double CharToNum(char a) => a switch
                    {
                        '0' => 0,
                        '1' => 1,
                        '2' => 2,
                        '3' => 3,
                        '4' => 4,
                        '5' => 5,
                        '6' => 6,
                        '7' => 7,
                        '8' => 8,
                        '9' => 9,
                        '-' => -1,
                        _ => 0,
                    };
                    if (CharToNum(charNum) == digit)
                    {
                        result.Add(num);
                    }

                    if (CharToNum(charNum) == digit)
                         break;
                }
            }

            return result.ToArray();
        }
    }
}
