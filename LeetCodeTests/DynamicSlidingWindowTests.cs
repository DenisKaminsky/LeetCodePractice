using LeetCode.Basics;

namespace LeetCodeTests
{
    public class DynamicSlidingWindowTests
    {
        private SlidingWindowDynamic _slidingWindow;

        public DynamicSlidingWindowTests()
        {
            _slidingWindow = new SlidingWindowDynamic();
        }

        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
        public void MaxSubArray(int[] array, int expected)
        {
            var actual = _slidingWindow.MaxSubArray(array);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 15, 2, 4, 8, 9, 5, 10, 23 }, 23, new int[] { 2, 5 })]
        [InlineData(new int[] { 1, 4, 0, 0, 3, 10, 5 }, 7, new int[] { 2, 5 })]
        [InlineData(new int[] { 1, 4 }, 0, new int[] { -1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 3 })]
        [InlineData(new int[] { 1, 2, 3, 7, 8 }, 15, new int[] { 4, 5 })]
        public void SubarraySum(int[] array, long sum, int[] expected)
        {
            var actual = _slidingWindow.SubarraySum(array, sum);

            Assert.Equal(expected, actual);
        }
    }
}
