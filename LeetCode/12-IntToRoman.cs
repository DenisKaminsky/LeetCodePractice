using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Task12
{
    public class Solution
    {
        public Dictionary<char, int> _letters = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public string IntToRoman(int num)
        {
            var result = new StringBuilder();

            var allowed = "MDCLXVI";
            

            return result.ToString();
        }
    }
}
