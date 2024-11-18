using System.Collections;
using LeetCode.Basics;

namespace LeetCodeTests
{
    public class TwoPointerTests
    {
        private TwoPointers _twoPointers;

        public TwoPointerTests()
        {
            _twoPointers = new TwoPointers();
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
        [InlineData(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
        [InlineData(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
        public void TwoSumTests(int[] array, int target, int[] expected)
        {
            var actual = _twoPointers.TwoSum(array, target);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { -1, 0, 1, 2, -1, -4 }, new object[] { new int[] { -1, -1, 2 }, new int[] { -1, 0, 1 } })]
        [InlineData(new int[] { 0, 1, 1 }, new object[0])]
        [InlineData(new int[] { 0, 0, 0 }, new object[] { new int[] { 0, 0, 0 } })]
        public void ThreeSumTests(int[] array, object[] expected)
        {
            var a = new int[][] { new int[] { 1 } };
            var actual = _twoPointers.ThreeSum(array);

            Assert.Equal(expected, actual);
        }
    }
}
