using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Trie
{
    public class TrieImpl
    {

        public static void Test ()
        {
            var trie = new TrieImpl();
            trie.Insert("apple");
            trie.Insert("application");           
            trie.Insert("baby");
            trie.Insert("babs");
            var startWith = trie.StartsWith("bab");
            var exists = trie.Search("baby");

            string[] products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mou";

            trie = new TrieImpl();
            var result = new List<IList<string>>();
            // Add all words to trie.
            foreach (var word in products)
                trie.Insert(word);

            var prefix = string.Empty;
            foreach (var c in searchWord)
            {
                prefix += c;
                result.Add(trie.GetWordsStartingWith(prefix));
            }           
        }

        TrieNode root;

        public TrieImpl()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            var curr = root;

            foreach(var c in word)
            {
                if (!curr.children.ContainsKey(c))
                    curr.children[c] = new TrieNode(c);

                curr = curr.children[c];
            }
            curr.isLeaf = true;
        }

        private List<string> GetWordsStartingWith(string prefix)
        {
            var curr = root;
            var resultBuffer = new List<string>();

            // Move curr to the end of prefix in its trie representation.
            foreach (var c in prefix)
            {
                if (!curr.children.ContainsKey(c))
                    return resultBuffer;
                curr = curr.children[c];
            }
            DFSwithPrefix(curr, prefix, resultBuffer);
            return resultBuffer;
        }

        void DFSwithPrefix(TrieNode curr, string word, List<string> resultBuffer)
        {
            if (resultBuffer.Count == 3)
                return;
            if (curr.isLeaf)
                resultBuffer.Add(word);

            // Run DFS on all possible paths.
            for (char c = 'a'; c <= 'z'; c++)
                if (curr.children.ContainsKey(c))
                    DFSwithPrefix(curr.children[c], word + c, resultBuffer);
        }

        public bool Search(string word)
        {
            var node = SearchNode(word);
            return node != null && node.isLeaf;
        }

        public bool StartsWith(string word)
        {
            var node = SearchNode(word);
            return node != null;
        }

        private TrieNode SearchNode(string word)
        {
            var curr = root;

            foreach(var c in word)
            {
                if (!curr.children.ContainsKey(c))
                    return null;

                curr = curr.children[c];
            }

            return curr;
        }
        internal class TrieNode
        {
            public char c;
            public bool isLeaf;
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public TrieNode(char c)
            {
                this.c = c;
            }

            public TrieNode() { }
        }



    }
}
