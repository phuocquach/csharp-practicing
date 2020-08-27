using System;

namespace FrogJump
{
    public class Solution
    {
        public int solution(int X, int Y, int D) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        var distance = Y - X;
        var mod = distance % D;
        var result = distance / D;
        return mod > 0
            ? result + 1
            : result;
    }
    }
}
