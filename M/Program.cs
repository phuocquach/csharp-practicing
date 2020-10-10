using System;

namespace MaxDoubleSliceSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().solution(new int[] {5, 17, 0, 3}));
        }

        class Solution
        {
            public int solution(int[] A)
            {
                var maxFromStart = new int[A.Length];
                maxFromStart[0] = 0;
                maxFromStart[1] = 0;
                maxFromStart[2] = Max(A[1],0);

                for(int i=3;i<A.Length-1;i++)
                {
                    maxFromStart[i] = Max(maxFromStart[i - 1] + A[i-1], A[i-1]);
                    maxFromStart[i] = Max(maxFromStart[i], 0);
                    //Console.WriteLine(maxFromStart[i]);
                }

                var maxFromEnd = new int[A.Length];
                maxFromEnd[A.Length - 1] = 0;
                maxFromEnd[A.Length - 2] = 0;
                maxFromEnd[A.Length - 3] = Max(A[^2],0);

                for (int i = A.Length-4;i>=0; i--)
                {
                    maxFromEnd[i] = Max(maxFromEnd[i + 1] + A[i + 1], A[i + 1]);
                    maxFromEnd[i] = Max(maxFromEnd[i], 0);
                    //Console.WriteLine(maxFromEnd[i]);
                }

                var max = 0;
                for(int i = 1;i<A.Length-1;i++)
                {
                    max = Max(max, maxFromEnd[i] + maxFromStart[i]);
                }

                return max;
            }

            private int Max(int v1, int v2) => v1 > v2 ? v1 : v2;
        }
    }
}
