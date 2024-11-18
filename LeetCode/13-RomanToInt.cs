namespace LeetCode.Task13
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

        public int RomanToInt(string s)
        {
            var prevValue = _letters[s[0]];
            var result = prevValue;

            for (var i = 1; i < s.Length; i++)
            {
                var currValue = _letters[s[i]];
                result += currValue;

                if (currValue > prevValue)
                    result -= prevValue * 2;

                prevValue = currValue;
            }

            return result;
        }
    }
}
