using System;

namespace multidimesionarray
{
    class Solution {
        private int[][] A2, A5, A10;
        private int[][] AMaxDownTop, AMaxRowLeft, AMaxRowRight;
        private int[][] A2Max, A5Max, A10Max;
        int N,M;
        public int solution(int[][] A) {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            M = A[0].Length;
            N = A.Length ;
            A2 = new int[N, M];
            A5 = new int[N, M]; 
            A10 = new int[N, M]; 
            AMaxDownTop = new int[N, M];
            AMaxRowLeft = new int[N, M];
            AMaxRowRight = new int[N, M];

            var max = 0;

            for(int i = N-1; i>= 0; i--)
            {
                for(int j = M - 1; j >= 0; j--)
                {
                    if (A[i][j] % 10 == 0)
                    {
                        A10[i][j] = NumOf(A[i][j], 10);
                    }
                    else if (A[i][j] % 5 == 0)
                    {
                        A5[i][j] = NumOf(A[i][j], 5);
                    }
                    else if (A[i][j] % 2 == 0)
                    {
                        A2[i][j] = NumOf(A[i][j], 2);
                    }
                    else
                    {
                        A10[i][j] = 0;
                        A2[i][j] = 0;
                        A5[i][j]  =0;
                    }
                }
            }
            return max;

        }

        private void FindMaxMatrix()
        {
            A10Max = new int[N][M];
            A2Max = new int[N][M];
            A5Max = new int[N][M];

            for(int i = N-2; i>= 0; i--)
            {
                for(int j = M - 1; j >= 0; j--)
                {
                    A2[i][j] += A2[i][j-1]; 
                    A2[i][j] += A2[i][j-1];
                    A2[i][j] += A2[i][j-1];
                }
            }
        }

        private int GetMaxZeroLength(int x, int y, int z)
        {
            return (x > y && x > z)
                    ? x 
                    : y > z 
                        ? y
                        : z; 
        }

        private int NumOf(int input, int num)
        {
            var count = 0;
            while(number % num == 0)
            {
                count += 1;
                number = number / num;
            }
            return count;
        }
    }
}
