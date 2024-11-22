using LeetCode.Basics;

namespace LeetCodeTests.Basics
{

    public class BinarySearchTests
    {
        private BinarySearch _engine;

        public BinarySearchTests()
        {
            _engine = new BinarySearch();
        }

        [Theory]
        [InlineData(1, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(2, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(3, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(4, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        public void SortedArray_FindsResult(int target, int[] array)
        {
            var actual = _engine.Search(target, array);

            var expected = -1;
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    expected = i;
                    break;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}