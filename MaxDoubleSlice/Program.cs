using System;

namespace MaxDoubleSlice
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(s.solution(new int[]
            {
                3,2,6,-1,4,5,-1,2
            }));
        }

        class Solution
        {
            public int solution(int[] A)
            {
                var max = new int[A.Length];
                max[2] = A[0] + A[1] + A[2];

                for(int i = 3; i< A.Length;i++)
                {
                    max[i] = Max(max[i - 1] + A[i], A[i - 1] + A[i] + A[i - 2]);
                }
                var max_ending = max[2];
                for(int i = 2; i<max.Length;i++)
                {
                    max_ending = Max(max_ending, max[i]);
                }
                return max_ending;
            }

            private int Max(int x, int y)
            {
                return x > y ? x : y;
            }
        }
    }
}
