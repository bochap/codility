using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogRiverOne
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int solution(int X, int[] A)
        {
            // write your code in C# with .NET 2.0
            var length = A.Length;
            if (X < 1 || length < 1 || X > 100000 || length > 100000) throw new ArgumentOutOfRangeException();

            var expectedSumOfSpots = 0;
            for (var count = 1; count <= X; count++)
                expectedSumOfSpots += count;

            var spotsFound = new bool[X];
            var currentSumOfSpots = 0;
            for (int count = 0; count < length; count++)
            {
                if (spotsFound[A[count] - 1] == false)
                    currentSumOfSpots += A[count];

                if (currentSumOfSpots == expectedSumOfSpots)
                    return count;

                spotsFound[A[count] - 1] = true;
            }

            return -1;
        }
    }
}
