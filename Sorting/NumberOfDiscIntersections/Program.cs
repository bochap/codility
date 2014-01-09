using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var discs = new List<List<int>>();
            for (var count = 0; count < A.Length; count++)
            {
                discs.Add(new List<int>(new [] {count - A[count], count + A[count]}));
            }
            var sortedDiscs = sort(discs);
            return -1;
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
