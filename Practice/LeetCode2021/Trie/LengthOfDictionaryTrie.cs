using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Trie
{
    public class LengthOfDictionaryTrie
    {
        public static void Test()
        {
            var words = new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" };

            TrieTree trie = new TrieTree();
            int index = 0;
            foreach (string word in words)
            {
                trie.Insert(word, ++index); //indexed by 1
            }
            trie.Words = words;
        }       
    }

    internal class Node
    {
        public char C;
        public Dictionary<char, Node> Children = new Dictionary<char, Node>();
        public int End;
        public Node(char c)
        {
            this.C = c;
        }        
    }

    internal class TrieTree
    {
        Node Root;
        public string[] Words;

        public TrieTree()
        {
            Root = new Node('0');
        }

        public void Insert(string word, int index)
        {
            Node curr = Root;

            foreach(var c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children[c] = new Node(c);
                }
                curr = curr.Children[c];
            }
            curr.End = index;
        }
    }
}
