using System;
using System.Linq;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int solution(int[] A)
        {
            // write your code in C# with .NET 2.0
            if (A.Length < 0 || A.Length > 1000000) throw new ArgumentOutOfRangeException();
            var sorted = A.ToList<int>();
            sorted.Sort();
            for (var count = 0; count < sorted.Count - 2; count++)
            {
                if (sorted[count + 1] > sorted[count + 2] - sorted[count])
                    return 1;
            }
            return 0;
        }
    }
}
