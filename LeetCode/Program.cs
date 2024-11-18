// See https://aka.ms/new-console-template for more information

/*var task380 = new LeetCode.Task380.RandomizedSet();
task380.Insert(1);
task380.Remove(2);
task380.Insert(2);
task380.GetRandom();
task380.Remove(1);
task380.Insert(2);
task380.GetRandom();
*/

/*var tast134 = new LeetCode.Task134.GasStation();
var arr_task134 = new int[100000];
for (var i = 0; i < arr_task134.Length; i++)
{
    arr_task134[i] = 1;
}
var result_task134 = tast134.CanCompleteCircuit(arr_task134, arr_task134);*/


using LeetCode.Daily;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Numerics;
using LeetCode.Basics;
using System.Linq;
using System.Collections.Generic;


var t = char.IsLetterOrDigit('a');


public class Solution2
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
                if (!rowMap.Add($"{row}-{item}"))
                    return false;

                if (!columnMap.Add($"{column}-{item}"))
                    return false;

                int blockColumn = column / 3;
                int blockRow = row / 3;
                if (!boxMap.Add($"{blockRow*3 + blockColumn}-{item}"))
                    return false;
            }
        }

        return true;
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, List<string>>(strs.Length);

        foreach (var str in strs)
        {
            var strCount = new int[26];
            foreach (var letter in str)
            {
                strCount[letter - 'a']++;
            }

            var strCode = string.Join("-", strCount);
            if (!map.ContainsKey(strCode))
            {
                map.Add(strCode, new List<string> { str });
            }
            else
            {
                map[strCode].Add(str);
            }
        }

        var result = new List<IList<string>>();
        foreach (var key in map.Keys)
        {
            result.Add(map[key]);
        }
        

        return result;
    }
}
