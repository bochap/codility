/*
A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.
Your goal is to find that missing element.
Write a function:
int solution(int A[], int N);
that, given a zero-indexed array A, returns the value of the missing element.
For example, given array A such that:
  A[0] = 2
  A[1] = 3
  A[2] = 1
  A[3] = 5
the function should return 4, as it is the missing element.
Assume that:
N is an integer within the range [0..100,000];
the elements of A are all distinct;
each element of array A is an integer within the range [1..(N + 1)].
Complexity:
expected worst-case time complexity is O(N);
expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace PermMissingElem
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public int solution(int[] A)
        {
            if (A == null) throw new ArgumentNullException();
            if (A.Length > 100000) throw new ArgumentOutOfRangeException();
            // write your code in C# with .NET 2.0
            var values = new bool[A.Length + 1];

            var result = 0;
            foreach (var value in A)
                values[value - 1] = true;

            for (var index = 0; index < values.Length; index++)
            {
                if (!values[index])
                {
                    result = index + 1;
                    break;
                }
            }

            return result;
        }
    }
}
