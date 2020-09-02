using System;
using Xunit;
using LeaderNumber;

namespace LeaderNumberTest
{
    public class LeaderNumberTest
    {
        [Fact]
        public void Test1()
        {
            Solution solution = new Solution();
            var input = new int[]
            {
                1,2,2,2,2,2,2,3,4
            };
            var result = solution.solution(input);
            Assert.True( result == 2);
        }
    }
}
