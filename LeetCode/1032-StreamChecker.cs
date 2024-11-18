using System.Diagnostics.Metrics;
using System.Text;

namespace LeetCode.Task1032
{
    public class StreamCheckerSlow
    {
        private HashSet<string> wordsSet;
        private int maxLength;
        private LinkedList<char> stream;

        public StreamCheckerSlow(string[] words)
        {
            wordsSet = new HashSet<string>();
            maxLength = 0;
            stream = new LinkedList<char>();

            // Reverse words and add them to the set, also track the max length of words
            foreach (string word in words)
            {
                wordsSet.Add(new string(word.Reverse().ToArray()));
                maxLength = Math.Max(maxLength, word.Length);
            }
        }

        public bool Query(char letter)
        {
            // Add the current character to the stream
            stream.AddFirst(letter);

            // Remove the oldest character if we exceed the max word length
            if (stream.Count > maxLength)
            {
                stream.RemoveLast();
            }

            // Check the suffixes in reverse order
            StringBuilder sb = new StringBuilder();
            foreach (char c in stream)
            {
                sb.Append(c);
                // Check if the current suffix (in reverse) is in the set
                if (wordsSet.Contains(sb.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class StreamChecker
    {
        private class TreeNode
        {
            public readonly Dictionary<char, TreeNode> Children = new();

            public bool IsEndOfWord = false;
        }

        private TreeNode _rootNode;
        private List<char> _lettersStream;

        public StreamChecker(string[] words)
        {
            //initialize tree
            _rootNode = new TreeNode();
            _lettersStream = new List<char>();

            foreach (var word in words)
            {
                var currentNode = _rootNode;
                for (var i = word.Length - 1; i >= 0; i--)
                {
                    var letter = word[i];
                    if (!currentNode.Children.ContainsKey(letter))
                    {
                        currentNode.Children.Add(letter, new TreeNode());
                    }

                    currentNode = currentNode.Children[letter];

                    if (i == 0)
                        currentNode.IsEndOfWord = true;
                }
            }
        }

        public bool Query(char letter)
        {
            _lettersStream.Add(letter);

            var currentNode = _rootNode;
            for (var i = _lettersStream.Count - 1; i >= 0; i--)
            {
                if (!currentNode.Children.ContainsKey(_lettersStream[i]))
                    return false;

                currentNode = currentNode.Children[_lettersStream[i]];

                if (currentNode.IsEndOfWord)
                    return true;
            }

            return false;
        }
    }
}
