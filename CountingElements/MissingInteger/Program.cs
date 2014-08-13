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
        // Work In Process
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(new[] { 2 }));
            Console.WriteLine(new Program().solution(new[] { 5, 4, 0, 2 }));
            Console.WriteLine(new Program().solution(new[] { 1, 3, 6, 4, 1, 2 }));
            Console.WriteLine(new Program().solution(new[] { -2, 1, 2 }));
            Console.WriteLine(new Program().solution(new[] { -22222222, 3, 100000000 }));
            Console.WriteLine(new Program().solution(new[] { -22222222, 3, -12222222 }));
            Console.WriteLine(new Program().solution(new[] { -100, -99, -1 }));
            Console.WriteLine(new Program().solution(new[] { -22222222, -12222222 }));
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

                if (A[count] < 0)
                {
                    minValue = 0;
                }

                if (maxValue < A[count])
                {
                    maxValue = A[count];
                }
            }

            var offset = -minValue;
            var found = new bool[A.Length];
            var value = default(int);
            for (var count = 0; count < A.Length; count++)
            {
                value = A[count] + offset;
                if (value >= A.Length) continue;
                if (value < 0) found[0] = true;
                else found[value] = true;
            }
            
            for (var count = 0; count < found.Length; count++)
            {
                if (found[count] == false)
                {
                    var result = count - offset;
                    return result;
                }
            }

            return maxValue + 1;
        }
    }
}
