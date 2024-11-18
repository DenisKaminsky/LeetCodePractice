// See https://aka.ms/new-console-template for more information

using LeetCode.Daily;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Numerics;
using LeetCode.Basics;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Running;


var tast134 = new LeetCode.Task134.GasStation();
var arr_task134 = new int[100000];
for (var i = 0; i < arr_task134.Length; i++)
{
    arr_task134[i] = 1;
}
var result_task134 = tast134.CanCompleteCircuit(arr_task134, arr_task134);


Console.WriteLine("LeetCode practice");
