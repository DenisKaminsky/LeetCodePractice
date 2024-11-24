using LeetCode.Task1926;

namespace LeetCodeTests
{
    public class Task1926Tests
    {
        private NearestExitFromEntranceInMaze _solution;

        public static IEnumerable<object[]> Data = new[]
        {
            new object[]
            {
                new[]
                {
                    new[] { '+', '+', '.', '+' },
                    new[] { '.', '.', '.', '+' },
                    new[] { '+', '+', '+', '.' }
                },
                new[] { 1, 2 },
                1
            },
            new object[]
            {
                new[]
                {
                    new[] { '+', '+', '+' },
                    new[] { '.', '.', '.' },
                    new[] { '+', '+', '+' }
                },
                new[] { 1, 0 },
                2
            },
            new object[]
            {
                new[]
                {
                    new[] { '.', '+' }
                },
                new[] { 0, 0 },
                -1
            },
        };

        public Task1926Tests()
        {
            _solution = new NearestExitFromEntranceInMaze();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void NearestExitTests(char[][] maze, int[] entrance, int expected)
        {
            var actual = _solution.NearestExit(maze, entrance);

            Assert.Equal(expected, actual);
        }
    }
}
