namespace LeetCode.Basics
{
    public class SlidingWindowFixed
    {
        public IList<int> FindAnagrams(string text, string word)
        {
            var result = new List<int>();

            if (word.Length > text.Length)
                return result;

            var wordSize = word.Length;

            var wordCount = new int[26];
            foreach (var letter in word)
            {
                wordCount[letter - 'a']++;
            }

            var anagramCount = new int[26];
            for (var i = 0; i < wordSize; i++)
            {
                anagramCount[text[i] - 'a']++;
            }

            if (IsAnagram(anagramCount, wordCount))
                result.Add(0);

            for (var i = wordSize; i < text.Length; i++)
            {
                anagramCount[text[i - wordSize] - 'a']--;
                anagramCount[text[i] - 'a']++;

                if (IsAnagram(anagramCount, wordCount))
                    result.Add(i - wordSize + 1);
            }

            return result;
        }

        private bool IsAnagram(int[] anagramCount, int[] wordCount)
        {
            for (var i = 0; i < anagramCount.Length; i++)
            {
                if (anagramCount[i] != wordCount[i])
                    return false;
            }

            return true;
        }
    }
}
