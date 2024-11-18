using System.Text;

namespace LeetCode.Task1957
{
    public class Solution
    {
        public string MakeFancyString(string s)
        {
            var result = new StringBuilder();

            var duplicates = 0;
            result.Append(s[0]);
            for (var i = 1; i < s.Length; i++)
            {
                duplicates += s[i] == s[i - 1] 
                    ? 1 
                    : duplicates * -1;

                if (duplicates < 2)
                    result.Append(s[i]);

            }

            return result.ToString();
        }
    }
}
