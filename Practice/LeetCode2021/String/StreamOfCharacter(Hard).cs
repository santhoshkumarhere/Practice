using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.String
{
    public class StreamOfCharacter_Hard_
    {
        public static void Test()
        {
            HashSet<string> set = new HashSet<string>(new string[] { "abaa", "abaab", "aabbb", "bab", "ab" });
            StringBuilder str = new StringBuilder();
            var words = new string[] { "cd", "f", "kl" };
            var trie = new TrieNode();
            foreach (string word in words)
            {
                var curr = trie;
                var reversedWord = new StringBuilder(word).ToString().Reverse(); // reverse
                foreach (var c in reversedWord)
                {
                    if (!curr.Children.ContainsKey(c))
                    {
                        curr.Children[c] = new TrieNode(c);
                    }
                    curr = curr.Children[c];
                }
                curr.IsWord = true;
            }

            var search = "abcdef";
            foreach (var c in search)
            {
                //var res = Query(c, str, set);
                var res = Query(c, str, trie);

            }
        }

        private static bool Query(char letter, StringBuilder str, TrieNode root)
        {
            var curr = root;
            str.Append(letter);
            
            for(var i = str.Length-1; i >=0; i--)
            {
                if (curr.IsWord)
                    return true;

                if (!curr.Children.ContainsKey(str[i]))
                    return false;
                curr = curr.Children[str[i]];
            }

            return curr.IsWord;
        }

        private static bool Query(char letter, StringBuilder str, HashSet<string> set)
        {
            //TL exceeded
            str.Append(letter);
            var term = str.ToString();

            var start = 0; var end = term.Length;
            while (start < end)
            {
                var sb = term.Substring(start, end - start);
                if (set.Contains(sb))
                    return true;
                start++;
            }
            return false;
        }
    }
}

    public class TrieNode
    {
        public char Letter;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsWord;

        public TrieNode(char c)
        {
            this.Letter = c;
        }

        public TrieNode()
        {

        }
    }


