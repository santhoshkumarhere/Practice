using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.Trie
{
    public class Trie
    {
        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children;
            public bool EndOfWord;

            // Constructor
            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                EndOfWord = false;
            }
        }

        private readonly TrieNode root;
	 
	    public Trie()
        {
            root = new TrieNode();
        }        

        public void Insert(String word)
        {
            TrieNode currentNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];                
                if (!currentNode.Children.ContainsKey(ch))
                {
                    var node = new TrieNode();
                    currentNode.Children.Add(ch, node);
                    currentNode = node;
                }
                else
                {
                    currentNode = currentNode.Children[ch];
                }
            }
            currentNode.EndOfWord = true;
            Console.WriteLine("Successfully inserted " + word + " in Trie !");
        }

        //CASE#1 -- if node does not exist for given char then return false
        //CASE#2 -- Word exists in Trie
        //CASE#3 -- Current word is a prefix of another word. But this word does not exists
        public bool Search(String word)
        {
            TrieNode currentNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (!currentNode.Children.ContainsKey(ch))
                { 
                    Console.WriteLine("Word: " + word + " does not exists in Trie !");
                    return false;
                }
                currentNode = currentNode.Children[ch];
            }
            if (currentNode.EndOfWord == true)
            {
                Console.WriteLine("Word: " + word + " exists in Trie !");
            }
            else
            {                
                Console.WriteLine("Word: " + word + " does not exists in Trie ! But this is a Prefix of another Word !");
            }
            return currentNode.EndOfWord;
        }
        
        // Delete word from Trie
        public void Delete(String word)
        {
            if (Search(word) == true)
            {
                Delete(root, word, 0);
            }
        }

        // CASE#1 -- Some other word's prefix is same as Prefix of this word (BCDE, BCKG)
        // CASE#2 -- We are at last character of this word and This word is a Prefix of some other word (BCDE, BCDEFG)
        // CASE#3 -- Some other word is a Prefix of this word (BCDE, BC)
        // CASE#4 -- No one is dependent on this Word (BCDE, BCDE)
        private bool Delete(TrieNode parentNode, String word, int index)
        {
            char ch = word[index];
            TrieNode currentNode = parentNode.Children[ch];

            bool canThisNodeBeDeleted;
            // CASE#1
            if (currentNode.Children.Count > 1)
            {
                Console.WriteLine("Entering Case#1");
                Delete(currentNode, word, index + 1);
                return false;
            }

            // CASE#2
            if (index == word.Length - 1)
            { 
                Console.WriteLine("Entering Case#2");
                if (currentNode.Children.Count >= 1)
                {
                    currentNode.EndOfWord = false;//updating endOfWord will signify that this word is not there in Trie
                    return false;
                }
                else
                {
                    Console.WriteLine("Character " + ch + " has no dependency, hence deleting it from last");
                    parentNode.Children.Remove(ch);
                    return true;// If this word is not a prefix of some other word, and since this is last character, we should return true, indicating we are ok to delete this node
                }
            }

            // CASE#3
            if (currentNode.EndOfWord == true)
            { 
                Console.WriteLine("Entering Case#3");
                Delete(currentNode, word, index + 1);
                return false;
            }


            Console.WriteLine("Entering Case#1");
            canThisNodeBeDeleted = Delete(currentNode, word, index + 1); // CASE#4
            if (canThisNodeBeDeleted == true)
            {
                Console.WriteLine("Character " + ch + " has no dependency, hence deleting it");
                parentNode.Children.Remove(ch);
                return true;
            }
            else
            {
                return false; // Someone is dependent on this node, hence dont delete it
            }

        }

    }
}
