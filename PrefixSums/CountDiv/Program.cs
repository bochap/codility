using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDiv
{
    /*
        Write a function:
        class Solution { int solution(int A, int B, int K); }
        that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:
        { i : A ≤ i ≤ B, i mod K = 0 }
        For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.
        Assume that:
        A and B are integers within the range [0..2,000,000,000];
        K is an integer within the range [1..2,000,000,000];
        A ≤ B.
        Complexity:
        expected worst-case time complexity is O(1);
        expected worst-case space complexity is O(1).     
     */
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(6, 11, 2));
            Console.ReadLine();
        }

        public int solution(int A, int B, int K)
        {
            //int count = 0;
            //// write your code in C# 5.0 with .NET 4.5 (Mono)
            //for(var index = A; index <= B; index++) {
            //    if(index % K == 0) count++;
            //}
            //return count;
            return B / K - (A / K) + (A % K == 0 ? 1 : 0);
        }


    }
}
