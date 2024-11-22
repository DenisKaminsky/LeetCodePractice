// See https://aka.ms/new-console-template for more information

using System.Text;


var tast134 = new LeetCode.Task134.GasStation();
var arr_task134 = new int[100000];
for (var i = 0; i < arr_task134.Length; i++)
{
    arr_task134[i] = 1;
}
var result_task134 = tast134.CanCompleteCircuit(arr_task134, arr_task134);

Console.WriteLine("LeetCode practice");
