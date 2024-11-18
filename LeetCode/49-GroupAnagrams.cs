namespace LeetCode.Task49
{
    public class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, List<string>>(strs.Length);

            foreach (var str in strs)
            {
                var strCount = new char[26];
                foreach (var letter in str)
                {
                    strCount[letter - 'a']++;
                }

                var strCode = new string(strCount);
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
}
