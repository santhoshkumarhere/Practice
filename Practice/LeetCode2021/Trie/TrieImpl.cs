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
