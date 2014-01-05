using System;
using System.Collections.Generic;
using System.Text;

namespace FrogJmp
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public int solution(int X, int Y, int D)
        {
            // write your code in C90
            if (X < 0 || Y < 0 || D < 0 || X > 1000000000 || Y > 1000000000 || D > 1000000000) throw new ArgumentOutOfRangeException();
            if (X > Y) throw new InvalidOperationException();

            return (int)Math.Ceiling(((Y - X) / (D * 1.0M)));
        }
    }
}
