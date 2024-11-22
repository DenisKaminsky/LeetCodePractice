using LeetCode.Basics;

namespace LeetCodeTests.Basics
{
    public class FixedSlidingWindowTests
    {
        private SlidingWindowFixed _slidingWindow;
        public FixedSlidingWindowTests()
        {
            _slidingWindow = new SlidingWindowFixed();
        }

        [Theory]
        [InlineData("cbaebabacd", "abc", new int[] { 0, 6 })]
        [InlineData("abab", "ab", new int[] { 0, 1, 2 })]
        [InlineData("aaaaaaaaaa", "aaaaaaaaaaaaa", new int[] { })]
        [InlineData("baa", "aa", new int[] { 1 })]
        public void FindAnagrams(string text, string word, int[] expectedOutput)
        {
            var actual = _slidingWindow.FindAnagrams(text, word);
            Assert.Equal(expectedOutput, actual);
        }
    }
}
