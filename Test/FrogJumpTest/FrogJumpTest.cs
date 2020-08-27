using System;
using Xunit;

namespace FrogJumpTest
{
    public class FrogJumpTest
    {
        [Theory]
        [InlineData(10, 80, 30, 3)]
        public void FrogJump_SampleTestcase_ShouldReturn_Success(int x, int y, int d, int expectedResult)
        {
            var frog = new FrogJump.Solution();
            var result = frog.solution(x,y,d);
            Assert.True(result == expectedResult);
        }
    }
}
