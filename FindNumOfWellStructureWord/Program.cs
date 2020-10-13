using System;
using System.Linq;

namespace FindNumOfWellStructureWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().solution("RBA"));
        }

        class Solution
        {
            public int solution(string S)
            {
                var consonantString = S.Where(x => !"AOIEU".Contains(x));
                var countConsonant = consonantString.Count();
                var countDistinctConsonant = consonantString.Distinct().Count();
                var totalLength = S.Length;
                var countVowel = totalLength - countConsonant;


                return countConsonant < countVowel
                      ? 0
                      : Factional(countDistinctConsonant);
            }

            private int Factional(int n)
            {
                int res = 1;
                while (n != 1)
                {
                    res *= n;
                    n -= 1;
                }
                return res;
            }
        }
    }
}
