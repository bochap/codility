using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 A zero-indexed array A consisting of N integers is given. The dominator of array A is the value that occurs in more than half of the elements of A.
For example, consider array A such that
A[0] = 3    A[1] = 4    A[2] =  3
A[3] = 2    A[4] = 3    A[5] = -1
A[6] = 3    A[7] = 3
The dominator of A is 3 because it occurs in 5 out of 8 elements of A (namely in those with indices 0, 2, 4, 6 and 7) and 5 is more than a half of 8.
Write a function
class Solution { int solution(int[] A); }
that, given a zero-indexed array A consisting of N integers, returns index of any element of array A in which the dominator of A occurs. The function should return −1 if array A does not have a dominator.
Assume that:
N is an integer within the range [0..100,000];
each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
For example, given array A such that
A[0] = 3    A[1] = 4    A[2] =  3
A[3] = 2    A[4] = 3    A[5] = -1
A[6] = 3    A[7] = 3
the function may return 0, 2, 4, 6 or 7, as explained above.
Complexity:
expected worst-case time complexity is O(N);
expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.
 */

namespace dominator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(new Program().solution(new[] { 3, 4, 3, 2, 3, -1, 3, 3 }));
            Console.ReadLine();
        }

        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var size = 0;
            var value = default(int);
            for (var index = 0; index < A.Length; index++)
            {
                if (size == 0)
                {
                    value = A[index];
                    size++;
                }
                else
                {
                    if (value != A[index])
                    {
                        size--;
                    }
                    else
                    {
                        size++;
                    }
                }
            }

            var candidate = -1;
            if (size > 0)
                candidate = value;

            var count = 0;
            var candidateIndex = -1;
            var midIndex = A.Length / 2;
            for (var index = 0; index < A.Length; index++)
            {
                if (A[index] == candidate)
                {
                    count++;
                    candidateIndex = index;
                }

                if (count > midIndex)
                    return candidateIndex;
            }

            return -1;
        }

        public List<int> sort(List<int> values)
        {
            if (values.Count == 1)
            {
                return values;
            }

            var mid = values.Count / 2;
            var left = values.GetRange(0, mid);
            var right = values.GetRange(mid, values.Count - mid);

            left = sort(left);
            right = sort(right);

            var leftIndex = 0;
            var rightIndex = 0;
            List<int> result = new List<int>();
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
                else if (left[leftIndex] < right[rightIndex])
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
