using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Task1072
{
    public class FlipColumnsForMaximumNumberOfEqualRows
    {
        public int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            var totalRows = matrix.Length;
            var totalColumns = matrix[0].Length;

            var currentBits = new char[totalColumns];
            var map = new Dictionary<string, int>(totalRows);

            var result = 0;
            for (var row = 0; row < totalRows; row++)
            {
                if (matrix[row][0] == 0)
                {
                    for (var column = 0; column < totalColumns; column++)
                    {
                        currentBits[column] = (char)('0' + matrix[row][column]);
                    }
                }
                else
                {
                    //invert
                    for (var column = 0; column < totalColumns; column++)
                    {
                        currentBits[column] = (char)('1' - matrix[row][column]);
                    }
                }

                var key = new string(currentBits);
                map.TryGetValue(key, out var count);
                map[key] = count + 1;

                result = Math.Max(result, count + 1);
            }

            return result;
        }
    }
}
