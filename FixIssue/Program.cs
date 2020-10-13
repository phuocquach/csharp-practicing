using System;

namespace FixIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().solution(new int[] {1}));
        }

        class Solution
        {
            public int solution(int[] A)
            {
                int n = A.Length;
                int[] L = new int[n + 1];
                L[0] = -1;
                for (int i = 0; i < n; i++)
                {
                    L[i + 1] = A[i];
                }
                int count = 0;
                int pos = (n + 1) / 2;
                int candidate = L[pos];
                for (int i = 1; i <= n; i += count)
                {
                    while (((i + count) <= n) && (L[i+count] == candidate))
                        count = count + 1;
                }
                if (count > (pos/2))
                    return candidate;
                return (-1);
            }
        }

    }
}
