using System.Collections.Generic;
using System.Linq;

namespace MaxProductOfThree
{
    class Solution
    {
        static void Main(string[] args)
        {

        }

        public int solution(int[] A)
        {
            // write your code in C# with .NET 2.0
            var sorted = Solution.sort(A.ToList<int>());
            var count = sorted.Count;
            var rightMaximum = sorted[count - 3] * sorted[count - 2] * sorted[count - 1];
            var leftMaximum = sorted[0] * sorted[1] * sorted[count - 1];    // In the event first 2 elements are negative 
            
            return (rightMaximum >= leftMaximum ? rightMaximum : leftMaximum);
        }

        // Merge sort not really required as the Sort function provided by .NET performs the same functionality but just for knowledge
        public static List<int> sort(List<int> value)
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
            var result = new List<int>();
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
                else if (left[leftIndex] > right[rightIndex])
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
