using System;

namespace MaxCounter
{
    public class Solution
    {
        public int[] solution(int N, int[] A) 
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var maxCounter = 0;
            var target = N +1;
            var result = new int[N];
            var lastResetIndex = FindIndex(target, A);
            
            
            if (lastResetIndex >=0)
            {
                maxCounter = FindMaxCounter(A,0,lastResetIndex,target);
            }
            
            for(var index = 0; index< result.Length; index ++)
            {
                result[index] = maxCounter;
            }
            
            for(var index = lastResetIndex+1 ; index < A.Length; index ++)
            {
                if (A[index] <= N && A[index] >=1)
                {
                    result[A[index]-1]++;
                }
            }
            
            return result;
            
        }
        private int FindIndex(int target, int[] input)
        {
            for(var index = input.Length-1; index >=0; index--)
            {
                if (input[index] == target)
                {
                    return index;
                }
            }
            return -1;
        }
        
        private int FindMaxCounter(int[] input, int start, int end, int target)
        {
            var maxCounter = 0;
            var lastMaxCounter = 0;
            var temp = new int[target];
            for(int index = start; index <= end; index++)
            {
                if (input[index]>=1 && input[index] < target)
                {
                    if (temp[input[index]] < lastMaxCounter)
                    {
                        temp[input[index]] = lastMaxCounter;
                    }
                    
                    temp[input[index]]++;
                    
                    if (maxCounter < temp[input[index]])
                    {
                        maxCounter = temp[input[index]];
                    }
                }
                if (input[index] == target)
                {
                    lastMaxCounter = maxCounter;
                }
            
            }
            
            return lastMaxCounter;
            
        }
    }
}
