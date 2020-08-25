using CopyDetection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopyDetectionTest
{
    public class IListDetectCopyTest
    {
        [Fact]
        public void CopyDetection_ShouldReturn_Items()
        {
            var input = new List<string>
            {
                "abc",
                "bcd",
                "abcd"
            };

            var ouput = new List<string>
            {
                "abc",
                "bcd",
                "abcd"
            };
            var result = input.DetectCopied(x => x<=9 && x>=3);
            result.Sort();
            ouput.Sort();
            Assert.True(ouput.SequenceEqual(result));

        }

        [Fact]
        public void CopyDetection_NoCopied_ShouldReturn_Empty()
        {
            var input = new List<string>
            {
                "ab",
                "bc",
                "abcd"
            };

            var result = input.DetectCopied(x => x <= 9 && x >= 3);
            Assert.Empty(result);

        }
    }
}
