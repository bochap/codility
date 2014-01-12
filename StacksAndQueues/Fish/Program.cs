using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(new []{4, 3, 2, 1, 5}, new []{0, 1, 0, 0, 0}));
        }

        public int solution(int[] A, int[] B)
        {
            // write your code in C# with .NET 2.0
            if(A == null || A.Length < 1 || A.Length > 100000) throw new ArgumentOutOfRangeException();

            var result = 0;
            var downStreamFishes = new Stack<int>();
            for (var count = 0; count < A.Length; count++) {
                if(B[count] == 0) {
                    while(downStreamFishes.Count > 0 && downStreamFishes.Peek() < A[count]) {
                        downStreamFishes.Pop();
                    }
                    if(downStreamFishes.Count == 0) result++;
                } else {
                    downStreamFishes.Push(A[count]);
                }
            }

            result += downStreamFishes.Count;

            return result;
        }
    }
}
