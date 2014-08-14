using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Solution to this task can be found at our blog.
You are going to build a stone wall. The wall should be straight and N meters long, and its thickness should be constant; however, it should have different heights in different places. The height of the wall is specified by a zero-indexed array H of N positive integers. H[I] is the height of the wall from I to I+1 meters to the right of its left end. In particular, H[0] is the height of the wall's left end and H[N−1] is the height of the wall's right end.
The wall should be built of cuboid stone blocks (that is, all sides of such blocks are rectangular). Your task is to compute the minimum number of blocks needed to build the wall.
Write a function:
class Solution { int solution(int[] H); }
that, given a zero-indexed array H of N positive integers specifying the height of the wall, returns the minimum number of blocks needed to build it.
For example, given array H containing N = 9 integers:
  H[0] = 8    H[1] = 8    H[2] = 5    
  H[3] = 7    H[4] = 9    H[5] = 8    
  H[6] = 7    H[7] = 4    H[8] = 8    
the function should return 7. The figure shows one possible arrangement of seven blocks.

Assume that:
N is an integer within the range [1..100,000];
each element of array H is an integer within the range [1..1,000,000,000].
Complexity:
expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified. 
*/

namespace stonewall
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new Program().solution(new []{ 8, 8, 5, 7, 9, 8, 7, 4, 8 }));
            Console.WriteLine(new Program().solution(new[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 }));
            Console.ReadLine();
        }

        public int solution(int[] H)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var openBlocks = new int[H.Length];
            var stackIndex = 0;
            var numOfBlocks = 0;
            foreach (var value in H)
            {
                while (stackIndex > 0 && openBlocks[stackIndex - 1] > value)
                {
                    stackIndex--;
                }

                if (stackIndex > 0 && openBlocks[stackIndex - 1] == value)
                {
                    continue;
                }
                else
                {
                    openBlocks[stackIndex] = value;
                    stackIndex++;
                    numOfBlocks++;
                }
            }

            return numOfBlocks;

        }
    }
}
