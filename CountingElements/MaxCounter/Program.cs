using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(5, new[] { 3, 4, 4, 6, 1, 4, 4 }));
        }

        public int[] solution(int N, int[] A)
        {
            var length = A.Length;
            if (N < 1 || length < 1 || N > 100000 || length > 100000) throw new ArgumentOutOfRangeException();
            // write your code in C# with .NET 2.0
            var result = new int[N];
            var maxValue = 0;
            var resetValue = 0;
            var hasReset = false;
            for (var count = 0; count < length; count++)
            {
                if (A[count] <= N)
                {
                    // Set to maximum value if a reset has been encountered
                    if (hasReset && (resetValue > result[A[count] - 1])) 
                        result[A[count] - 1] = resetValue;
                    
                    result[A[count] - 1] += 1;

                    // Get new maximum value
                    if (result[A[count] - 1] > maxValue)
                        maxValue = result[A[count] - 1];
                }
                else
                {
                    resetValue = maxValue;
                    hasReset = true;
                }
            }

            for (var count = 0; count < N; count++)
            {
                if (hasReset && resetValue > result[count])
                    result[count] = resetValue;
            }

            return result;
        }
    }
}
