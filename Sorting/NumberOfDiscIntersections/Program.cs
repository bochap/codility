using System.Collections.Generic;

namespace NumberOfDiscIntersections
{
    // Work in progress
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
                else accumulator[count - A[count], 0]++;

                if (A[count] + count >= length) accumulator[length - 1, 1]++;
                else accumulator[A[count] + count, 1]++;
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
