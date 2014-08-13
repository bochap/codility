using System;

/*
A string S consisting of N characters is called properly nested if:
S is empty;
S has the form "(U)" where U is a properly nested string;
S has the form "VW" where V and W are properly nested strings.
For example, string "(()(())())" is properly nested but string "())" isn't.
Write a function:
class Solution { int solution(string S); }
that, given a string S consisting of N characters, returns 1 if string S is properly nested and 0 otherwise.
For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0, as explained above.
Assume that:
N is an integer within the range [0..1,000,000];
string S consists only of the characters "(" and/or ")".
Complexity:
expected worst-case time complexity is O(N);
expected worst-case space complexity is O(1) (not counting the storage required for input arguments).
 */
namespace nesting
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int solution(string S)
        {
            if(string.IsNullOrEmpty(S)) return 1;
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int numOfOpen = 0;
            foreach (var value in S)
            {
                if (value == '(')
                {
                    numOfOpen++;
                }
                else if (value == ')')
                {
                    if (numOfOpen > 0) numOfOpen--;
                    else return 0;
                }
                else
                    return 0;
            }

            return (numOfOpen == 0) ? 1 : 0;
        }
    }
}
