namespace LeetCode.Task36
{
    public class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            var size = board.Length;
            var rowMap = new HashSet<string>(size);
            var columnMap = new HashSet<string>(size);
            var boxMap = new HashSet<string>(size);

            for (var row = 0; row < board.Length; row++)
            {
                for (var column = 0; column < board[row].Length; column++)
                {
                    var item = board[row][column];
                    if (item == '.')
                        continue;

                    if (!rowMap.Add($"{row}-{item}"))
                        return false;

                    if (!columnMap.Add($"{column}-{item}"))
                        return false;

                    int blockColumn = column / 3;
                    int blockRow = row / 3;
                    if (!boxMap.Add($"{blockRow * 3 + blockColumn}-{item}"))
                        return false;
                }
            }

            return true;
        }
    }
}
