using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicRangeQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().solution("GACACCATA", new [] {0, 0, 4, 7}, new [] {8, 2, 5, 7}));
        }

        public int[] solution(string S, int[] P, int[] Q)
        {
            // write your code in C# with .NET 2.0
            if (S.Length < 1 || S.Length > 100000
                || P.Length < 1 || P.Length > 50000
                || Q.Length < 1 || Q.Length > 50000
                || P.Length != Q.Length) throw new ArgumentOutOfRangeException();


            var nucleotideCount = new int[S.Length + 1, 4];
            for (var count = 0; count < S.Length; count++)
            {
                // Prefix Sums should start at 0 index = 0 and length + 1 with the total values
                if (count > 0)
                {
                    // Skip adding the first row at index 0 which contains only zeros
                    for (var index = 0; index < 4; index++)
                    {
                        nucleotideCount[count + 1, index] += nucleotideCount[count, index];
                    }
                }

                switch (S[count])
                {
                    case 'A':
                        nucleotideCount[count + 1, 0]++;
                        break;
                    case 'C':
                        nucleotideCount[count + 1, 1]++;
                        break;
                    case 'G':
                        nucleotideCount[count + 1, 2]++;
                        break;
                    case 'T':
                        nucleotideCount[count + 1, 3]++;
                        break;
                }

            }

            var result = new int[P.Length];
            for (var count = 0; count < P.Length; count++) {
                if(P[count] == Q[count])
                {
                   switch(S[P[count]]) {
                        case 'A':
                            result[count] = 1;
                            break;
                        case 'C':
                            result[count] = 2;
                            break;
                        case 'G':
                            result[count] = 3;
                            break;
                        case 'T':
                            result[count] = 4;
                            break;
                    }
                } else {
                    for(var index = 0; index < 4; index++) {
                        if((nucleotideCount[Q[count] + 1, index] - nucleotideCount[P[count], index]) > 0) {
                            result[count] = index + 1;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
