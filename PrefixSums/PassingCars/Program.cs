using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution(new [] { 0, 1, 0, 1, 1 }));
        }

        public int solution(int[] A)
        {
            // write your code in C# with .NET 2.0
            var length = A.Length;
            if (length < 0 || length > 1000000) throw new ArgumentOutOfRangeException();

            var eastBoundCars = 0;
            var passingPairs = 0;

            foreach (var value in A)
            {
                if (value == 1)
                {
                    passingPairs += eastBoundCars;
                    if (passingPairs > 1000000000) return -1;
                }
                else
                    eastBoundCars++;
            }
            return passingPairs;
        }
    }
}
