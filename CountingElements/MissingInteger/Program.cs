using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingInteger
{
    class Program
    {
        /// <summary>
        /// class Solution { int solution(int[] A); }
        /// that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer that does not occur in A.
        /// For example, given:
        ///   A[0] = 1    
        ///   A[1] = 3    
        ///   A[2] = 6
        ///   A[3] = 4    
        ///   A[4] = 1    
        ///   A[5] = 2
        /// the function should return 5.
        /// Assume that:
        /// N is an integer within the range [1..100,000];
        /// each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
        /// Complexity:
        /// expected worst-case time complexity is O(N);
        /// expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
        /// Elements of input arrays can be modified.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(new[] { 1, 2 }));
            Console.WriteLine(new Program().solution(new[] { -0, -2, -3 }));
            Console.ReadLine();
        }

        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            if (A.Length < 0 || A.Length > 100000) throw new ArgumentOutOfRangeException();
            if (A.Length == 1)
            {
                if (A[0] <= 0) return 1;
                return A[0] + 1;
            }

            var minValue = A[0];
            var maxValue = A[0];
            for (var count = 0; count < A.Length; count++)
            {
                if (minValue > A[count])
                {
                    minValue = A[count];
                }

                if (maxValue < A[count])
                {
                    maxValue = A[count];
                }
            }

            var hasReversed = false;
            var hasNegative = false;
            if (minValue != maxValue && minValue < 0 && maxValue < 0)
            {
                minValue ^= maxValue;
                maxValue ^= minValue;
                minValue ^= maxValue;

                minValue = Math.Abs(minValue);
                maxValue = Math.Abs(maxValue);
                hasReversed = true;
            }

            if (minValue < 0) {
                minValue = 0;
                hasNegative = true;
            }

            var offset = 0;
            if (minValue >= 100000)
                offset -= 100000;
            
            var found = new bool[A.Length];
            var value = default(int);
            for (var count = 0; count < A.Length; count++)
            {
                if (A[count] < 0)
                {
                    if (hasReversed) value = Math.Abs(A[count]);
                    else value = 0;
                }
                else
                {
                    value = A[count];
                }
                value += offset;

                if (value >= A.Length) continue;
                found[value] = true;
            }
            


            for (var count = 0; count < found.Length; count++)
            {
                if (count >= minValue + offset)
                {
                    if (found[count] == false)
                    {
                        return count - offset;
                    }
                }
            }


            if (hasReversed || (maxValue == 1 && hasNegative)) return 1;
            return maxValue + 1;
        }
    }
}
