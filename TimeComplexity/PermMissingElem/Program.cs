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
