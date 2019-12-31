using Practice.MiscProb;
using System.Collections.Generic;
using System.Linq;

public class Autocomplete
{

    // Trie node class
    private class TrieNode
    {
        public string prefix;
        public Dictionary<char, TrieNode> children;
        public bool isWord;

        public TrieNode(string prefix)
        {
            this.prefix = prefix;
            this.children = new Dictionary<char, TrieNode>();
        }
    }

    private TrieNode trie;

    public Autocomplete(string[] dict)
    {
        trie = new TrieNode("");
        foreach (string s in dict) insertWord(s);
    }

    private void insertWord(string s)
    {
        TrieNode curr = trie;
        for (int i = 0; i < s.Length; i++)
        {
            if (!curr.children.ContainsKey(s[i]))
            {
                curr.children[s[i]]= new TrieNode(s.Substring(0, i + 1));
            }
            curr = curr.children[s[i]];
        }
        curr.isWord = true;
    }

    public List<string> getWordsForPrefix(string pre)
    {
       var results = new List<string>();
        TrieNode curr = trie;
        foreach (char c in pre)
        {
            if (curr.children.ContainsKey(c))
            {
                curr = curr.children[c];
            }
            else
            {
                return results;
            }
        }

        findAllChildWords(curr, results);
        return results;
    }

    private void findAllChildWords(TrieNode n, List<string> results)
    {
        if (n.isWord) results.Add(n.prefix);
        foreach (char c in n.children.Keys)
        {
            findAllChildWords(n.children[c], results);
        }
    }

    public static void Test()
    {
       // var ll = new LetterCombination();
      //  var res =  ll.letterCombinations("23");
         Autocomplete a = new Autocomplete(new string[] { "abc", "acd", "bcd", "def", "a", "aba" });
        //Autocomplete a = new Autocomplete(res.Select(i => i.ToString()).ToArray());

        var x = a.getWordsForPrefix("be");
        x = a.getWordsForPrefix("a");
        x = a.getWordsForPrefix("def");
        x = a.getWordsForPrefix("abcd");
    }
}
    