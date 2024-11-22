using LeetCode.Task1072;

namespace LeetCodeTests
{
    public class Task1072Tests
    {
        private FlipColumnsForMaximumNumberOfEqualRows _solution;

        public static IEnumerable<object[]> Data => new object[][]
        {
            new object[]
            {
                new[] { new[] { 0, 1}, new[] { 1, 1} },
                1
            },
            new object[]
            {
                new[] { new[] { 0, 1}, new[] { 1, 0} },
                2
            },
            new object[]
            {
                new[] { new[] { 0, 0, 0}, new[] { 0, 0, 1}, new[] { 1, 1, 0} },
                2
            },
        };

        public Task1072Tests()
        {
            _solution = new FlipColumnsForMaximumNumberOfEqualRows();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void MaxEqualRowsAfterFlips(int[][] matrix, int expected)
        {
            var e = new int[2][] { new int[] { 1 }, new int[] { 1 } };
            var actual = _solution.MaxEqualRowsAfterFlips(matrix);

            Assert.Equal(expected, actual);
        }
    }
}
