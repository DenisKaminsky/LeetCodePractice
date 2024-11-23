namespace LeetCode.Task48
{
    public class RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            var dimensions = matrix.Length;
            if (dimensions <= 1) 
                return;

            //step 1: swap diagonally
            for (var i = 0; i < dimensions; i++)
            {
                for (var j = i + 1; j < dimensions; j++)
                {
                    var tmp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = tmp;
                }
            }

            //step 2: swap vertically
            for (var i = 0; i < dimensions; i++)
            {
                for (var j = 0; j < dimensions / 2; j++)
                {
                    var tmp = matrix[i][dimensions - j - 1];
                    matrix[i][dimensions - j - 1] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }
        }
    }
}
