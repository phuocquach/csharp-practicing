using CopyDetection;
using Xunit;

namespace CopyDetectionTest
{
    public class StringCopyDetectionTest
    {
        [Theory]
        public void StringCopiedDetectionTest_ShouldReturn_True()
        {
            var sourceString = "abc";
            var containedCopyString = "abc";

            var result = sourceString.ContainCopyString(containedCopyString, x => x>=3 && x <=9);

            Assert.True(result);
        }

        [Fact]
        public void StringCopiedDetectionTest_NoCopied_ShouldReturn_False()
        {
            var sourceString = "abc";
            var containedCopyString = "123";

            var result = sourceString.ContainCopyString(containedCopyString, x => x >= 3 && x <= 9);

            Assert.False(result);
        }
    }
}
