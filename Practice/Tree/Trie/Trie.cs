using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.Trie
{
    public class Trie
    {

        // Private class
        private class TrieNode
        {
            public Dictionary<char, TrieNode> children;
            public bool endOfWord;

            // Constructor
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                endOfWord = false;
            }
        }// End of inner class

        private readonly TrieNode root;

	
	// Constructor
	public Trie()
        {
            root = new TrieNode();
        }
        
        // Insert word into Trie
        public void insert(String word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = current.children[ch];
                if (node == null)
                {
                    node = new TrieNode();
                    current.children.Add(ch, node);
                }
                current = node;
            }
            current.endOfWord = true;
            Console.WriteLine("Successfully inserted " + word + " in Trie !");
        }
        
        // Search for a word in Trie
        public bool search(String word)
        {
            TrieNode currentNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = currentNode.children[ch];
                if (node == null)
                { //CASE#1 -- if node does not exist for given char then return false
                    Console.WriteLine("Word: " + word + " does not exists in Trie !");
                    return false;
                }
                currentNode = node;
            }
            if (currentNode.endOfWord == true)
            {
                Console.WriteLine("Word: " + word + " exists in Trie !"); //CASE#2 -- Word exists in Trie
            }
            else
            {//CASE#3 -- Current word is a prefix of another word. But this word does not exists
                Console.WriteLine("Word: " + word + " does not exists in Trie ! But this is a Prefix of another Word !");
            }
            return currentNode.endOfWord;
        }
        
        // Delete word from Trie
        public void Delete(String word)
        {
            if (search(word) == true)
            {
                Delete(root, word, 0);
            }
        }

        // Returns true if parent should delete the mapping
        private bool Delete(TrieNode parentNode, String word, int index)
        {

            // CASE#1 -- Some other word's prefix is same as Prefix of this word (BCDE, BCKG)
            // CASE#2 -- We are at last character of this word and This word is a Prefix of some other word (BCDE, BCDEFG)
            // CASE#3 -- Some other word is a Prefix of this word (BCDE, BC)
            // CASE#4 -- No one is dependent on this Word (BCDE, BCDE)

            char ch = word[index];
            TrieNode currentNode = parentNode.children[ch];

            bool canThisNodeBeDeleted;

            if (currentNode.children.Count > 1)
            {
                Console.WriteLine("Entering Case#1");
                Delete(currentNode, word, index + 1); // CASE#1
                return false;
            }
            

            if (index == word.Length - 1)
            { // CASE#2
                Console.WriteLine("Entering Case#2");
                if (currentNode.children.Count >= 1)
                {
                    currentNode.endOfWord = false;//updating endOfWord will signify that this word is not there in Trie
                    return false;
                }
                else
                {
                    Console.WriteLine("Character " + ch + " has no dependency, hence deleting it from last");
                    parentNode.children.Remove(ch);
                    return true;// If this word is not a prefix of some other word, and since this is last
                                // character, we should
                                // return true, indicating we are ok to delete this node
                }
            }


            if (currentNode.endOfWord == true)
            { // CASE#3
                Console.WriteLine("Entering Case#3");
                Delete(currentNode, word, index + 1);
                return false;
            }


            Console.WriteLine("Entering Case#1");
            canThisNodeBeDeleted = Delete(currentNode, word, index + 1); // CASE#4
            if (canThisNodeBeDeleted == true)
            {
                Console.WriteLine("Character " + ch + " has no dependency, hence deleting it");
                parentNode.children.Remove(ch);
                return true; // Current node can also be deleted
            }
            else
            {
                return false; // Someone is dependent on this node, hence dont delete it
            }

        }

    }// End of class
}
