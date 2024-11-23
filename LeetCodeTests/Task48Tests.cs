using LeetCode.Task48;

namespace LeetCodeTests
{
    public class Task48Tests
    {
        private RotateImage _solution;

        public static IEnumerable<object[]> Data = new object[][]
        {
            new object[]
            {
                new []
                {
                    new[] { 1, 2, 3},
                    new[] { 4, 5, 6},
                    new[] { 7, 8, 9}
                }
            },
            new object[]
            {
                new []
                {
                    new[] { 5, 1, 9, 11 },
                    new[] { 2, 4, 8, 10 },
                    new[] { 13, 3, 6, 7 },
                    new[] { 15, 14, 12, 16 }
                }
            }
        };

        public Task48Tests()
        {
            _solution = new RotateImage();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Rotate(int[][] matrix)
        {
            var expected = new int[matrix.Length][];
            for (var i = 0; i < matrix.Length; i++)
            {
                expected[i] = new int[matrix.Length];
                for (var j = 0; j < matrix.Length; j++)
                {
                    expected[i][matrix.Length - j - 1] = matrix[j][i];
                }
            }

            _solution.Rotate(matrix);
            
            Assert.Equal(expected, matrix);
        }
    }
}
