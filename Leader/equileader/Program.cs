using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equileader
{
    /*
A non-empty zero-indexed array A consisting of N integers is given.
The leader of this array is the value that occurs in more than half of the elements of A.
An equi leader is an index S such that 0 ≤ S < N − 1 and two sequences A[0], A[1], ..., A[S] and A[S + 1], A[S + 2], ..., A[N − 1] have leaders of the same value.
For example, given array A such that:
    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
we can find two equi leaders:
0, because sequences: (4) and (3, 4, 4, 4, 2) have the same leader, whose value is 4.
2, because sequences: (4, 3, 4) and (4, 4, 2) have the same leader, whose value is 4.
The goal is to count the number of equi leaders. Write a function:
class Solution { int solution(int[] A); }
that, given a non-empty zero-indexed array A consisting of N integers, returns the number of equi leaders.
For example, given:
    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
the function should return 2, as explained above.
Assume that:
N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000,000..1,000,000,000].
Complexity:
expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.     
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(new Program().solution(new []{4,3,4,4,4,2}));
            Console.ReadLine();
        }

        public int solution(int[] A)
        {
            IDictionary<int, int> rights = new Dictionary<int, int>();
            foreach (var value in A)
            {
                if (!rights.ContainsKey(value)) rights.Add(value, 0);
                rights[value] += 1;
            }

            var result = 0;
            var maxCount = 0;
            var leader = -2000000000;
            IDictionary<int, int> lefts = new Dictionary<int, int>();
            for (var index = 0; index < A.Length; index++)
            {
                var value = A[index];
                if (!lefts.ContainsKey(value)) lefts.Add(value, 0);

                lefts[value] += 1;
                rights[value] -= 1;

                if (lefts[value] > maxCount)
                {
                    maxCount = lefts[value];
                    leader = value;
                }

                if (lefts.ContainsKey(value) && lefts[value] > (index / 2))
                {
                    if (rights.ContainsKey(value) && rights[value] > ((A.Length - index - 1) / 2))
                    {
                        result++;
                    }
                }
            }

            return result;
        }


        public int solutionNx2(int[] A)
        {
            List<int> values = A.ToList();
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var invalidLeader = -2000000000;
            var count = 0;
            var splitter = default(int);
            for (var splitIndex = 0; splitIndex < A.Length -1; splitIndex++)
            {
                splitter = splitIndex + 1;
                var leftLeader = getLeader(values, 0, splitter, invalidLeader);
                if (leftLeader == invalidLeader) continue;
                var rightLeader = getLeader(values, splitter, (A.Length - splitter), invalidLeader);
                if (rightLeader == invalidLeader) continue;
                if (leftLeader == rightLeader) count++;
            }

            return count;
        }

        public int getLeader(List<int> values, int start, int count, int invalidLeader)
        {
            if (count == 1) return values[start];

            var sorted = sort(values.GetRange(start, count));
            var mid = (sorted.Count) / 2;
            var candidate = sorted[mid];
            var candidateCount = 0;
            foreach (var value in sorted)
            {
                if (value == candidate)
                    candidateCount++;

                if (candidateCount > mid)
                    return candidate;
            }


            return invalidLeader;
        }

        public List<int> sort(List<int> values)
        {
            if (values.Count == 1)
                return values;

            var midIndex = values.Count / 2;
            var left = sort(values.GetRange(0, midIndex));
            var right = sort(values.GetRange(midIndex, values.Count - midIndex));

            var leftIndex = 0;
            var rightIndex = 0;
            var result = new List<int>();
            for (var index = 0; index < left.Count + right.Count; index++)
            {
                if (left.Count == leftIndex)
                {
                    result.AddRange(right.GetRange(rightIndex, right.Count - rightIndex));
                    break;
                }
                else if (right.Count == rightIndex)
                {
                    result.AddRange(left.GetRange(leftIndex, left.Count - leftIndex));
                    break;
                } else if(left[leftIndex] < right[rightIndex]) {
                    result.Add(left[leftIndex]);
                    leftIndex++;    
                } else {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            return result;
        }
    }
}
