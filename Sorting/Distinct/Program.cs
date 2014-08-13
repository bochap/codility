using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distinct
{
    /*
        Write a function
        class Solution { int solution(int[] A); }
        that, given a zero-indexed array A consisting of N integers, returns the number of distinct values in array A.
        Assume that:
        N is an integer within the range [0..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].
        For example, given array A consisting of six elements such that:
        A[0] = 2    A[1] = 1    A[2] = 1
        A[3] = 2    A[4] = 3    A[5] = 1
        the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.
        Complexity:
        expected worst-case time complexity is O(N*log(N));
        expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
        Elements of input arrays can be modified.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(new [] {2, 1, 1, 2, 3, 1}));
            Console.WriteLine(new Program().solution(new[] { 0, 2, 3}));
            Console.WriteLine(new Program().solution(new int[100000]));
            Console.ReadLine();
        }

        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            if (A.Length <= 1) return A.Length;
            var sorted = sort(A.ToList<int>());
            if (sorted.Count > 1 && (sorted[0] == sorted[sorted.Count - 1])) return 1;
            var lastValue = sorted[0];
            var unique = 1;
            for(var count = 1; count < sorted.Count; count++)
            {
                if (lastValue != sorted[count])
                {
                    lastValue = sorted[count];
                    unique++;
                }
            }
            return unique;
        }

        public List<int> sort(List<int> values)
        {
            if (values.Count == 1)
            {
                return values;
            }

            var mid = (int)(values.Count / 2);
            var right = values.GetRange(0, mid);
            var left = values.GetRange(mid, values.Count - mid);

            left = sort(left);
            right = sort(right);

            var leftIndex = 0;
            var rightIndex = 0;
            var result = new List<int>();
            for (var index = 0; index < left.Count + right.Count; index++)
            {
                if (leftIndex == left.Count)
                {
                    result.AddRange(right.GetRange(rightIndex, right.Count - rightIndex));
                    break;
                }
                else if (rightIndex == right.Count)
                {
                    result.AddRange(left.GetRange(leftIndex, left.Count - leftIndex));
                    break;
                }
                else if (right[rightIndex] > left[leftIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            return result;
        }
    }
}
