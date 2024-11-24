namespace LeetCode.Task1926
{
    public class NearestExitFromEntranceInMaze
    {
        public int NearestExit(char[][] maze, int[] entrance)
        {
            var totalRows = maze.Length;
            var totalColumns = maze[0].Length;

            var viewed = new HashSet<(int, int)>(totalRows * totalColumns);

            //using BFS algorithm
            var queue = new Queue<(int Row, int Column, int Distance)>();
            queue.Enqueue((entrance[0], entrance[1], 0));

            while (queue.Count > 0)
            {
                var (currentRow, currentColumn, currentDistance) = queue.Dequeue();

                if (currentRow < 0 || currentRow == totalRows)
                    continue;
                if (currentColumn < 0 || currentColumn == totalColumns)
                    continue;
                if (maze[currentRow][currentColumn] != '.' || viewed.Contains((currentRow, currentColumn)))
                    continue;

                if (currentDistance > 0 && (currentRow == 0 || currentRow == totalRows - 1 || currentColumn == 0 || currentColumn == totalColumns - 1))
                    return currentDistance;

                //mark cell as viewed
                viewed.Add((currentRow, currentColumn));

                //top
                queue.Enqueue((currentRow - 1, currentColumn, currentDistance + 1));
                //bottom
                queue.Enqueue((currentRow + 1, currentColumn, currentDistance + 1));
                //left
                queue.Enqueue((currentRow, currentColumn - 1, currentDistance + 1));
                //right 
                queue.Enqueue((currentRow, currentColumn + 1, currentDistance + 1));
            }

            return -1;
        }
    }
}
