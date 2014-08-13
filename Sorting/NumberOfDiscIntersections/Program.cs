using System;
using System.Collections.Generic;

namespace NumberOfDiscIntersections
{
    /*
Given an array A of N integers, we draw N discs in a 2D plane such that the I-th disc is centered on (0,I) and has a radius of A[I]. We say that the J-th disc and K-th disc intersect if J ≠ K and J-th and K-th discs have at least one common point.
Write a function:
class Solution { int solution(int[] A); }
that, given an array A describing N discs as explained above, returns the number of pairs of intersecting discs. For example, given N=6 and:
A[0] = 1  A[1] = 5  A[2] = 2 
A[3] = 1  A[4] = 4  A[5] = 0  
intersecting discs appear in eleven pairs of elements:
0 and 1,
0 and 2,
0 and 4,
1 and 2,
1 and 3,
1 and 4,
1 and 5,
2 and 3,
2 and 4,
3 and 4,
4 and 5.
so the function should return 11.
The function should return −1 if the number of intersecting pairs exceeds 10,000,000.
Assume that:
N is an integer within the range [0..100,000];
each element of array A is an integer within the range [0..2147483647].
Complexity:
expected worst-case time complexity is O(N*log(N));
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.     
     */
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Program().solution(new [] {1, 5, 2, 1, 4, 0});
        }

        public int solution(int[] A)
        {
            // write your code in C# with .NET 2.0
            var length = A.Length;
            if (A == null || length <= 1) return 0;
            if (length > 100000) return -1;
            var accumulator = new int[length, 2];
            for (var count = 0; count < length; count++)
            {
                if (count < A[count]) accumulator[0, 0]++;
                else
                {
                    var index = count - A[count];
                    if(index < 0) index = 0;
                    accumulator[index, 0]++;
                }



                if (A[count] + count >= length) accumulator[length - 1, 1]++;
                else
                {
                    var index = A[count] + count;
                    if (index >= accumulator.Length) index = accumulator.Length - 1;
                    accumulator[index, 1]++;
                }
            }

            var result = 0;
            var open = 0; // 2
            for (var count = 0; count < length; count++)
            {
                result += open * accumulator[count, 0] + (accumulator[count, 0] * (accumulator[count, 0] - 1)) / 2; // 3
                if (result > 10000000)
                {
                    return -1;
                }


                open += accumulator[count, 0] - accumulator[count, 1]; // 4
            }

            return result;

        }

        public static List<List<int>> sort(List<List<int>> value)
        {
            if (value.Count == 1)
                return value;
            var midIndex = (int)(value.Count / 2);
            var left = value.GetRange(0, midIndex);
            var right = value.GetRange(midIndex, value.Count - midIndex);

            left = sort(left);
            right = sort(right);

            var leftIndex = 0;
            var rightIndex = 0;
            var result = new List<List<int>>();
            for (var count = 0; count < left.Count + right.Count; count++)
            {
                if (leftIndex == left.Count)
                {
                    // If no more elements in the left index append all sorted elements from the right array to the result then exit
                    result.AddRange(right.GetRange(rightIndex, right.Count - rightIndex));
                    break;
                }
                else if (rightIndex == right.Count)
                {
                    // If no more elements in the right index append all sorted elements from the left array to the result then exit
                    result.AddRange(left.GetRange(leftIndex, left.Count - leftIndex));
                    break;
                }
                else if (left[leftIndex][0] > right[rightIndex][0])
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
                else
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
            }
            return result;
        }
    }
}
