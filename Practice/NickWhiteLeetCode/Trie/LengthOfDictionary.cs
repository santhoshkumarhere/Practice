using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode.Trie
{
    public class LengthOfDictionary
    {

        public static void Test()
        {
           // LongestWord(new string[] { "w", "wo", "wor", "worl", "world" });
          //  LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" });
            LongestWord(new string[] { "ts", "e", "x", "pbhj", "opto", "xhigy", "erikz", "pbh", "opt", "erikzb", "eri", "erik", "xlye", "xhig", "optoj", "optoje", "xly", "pb", "xhi", "x", "o" });
            LongestWord(new string[] { "a" });
        }

        private static string LongestWord(string[] words)
        {
            if (words.Length == 1) return words[0];

            var sortedWords = words.OrderByDescending(x => x.Length);
            var result = new SortedDictionary<string, string>();
            int currentMaxWord = 0;

            foreach(var word in sortedWords)
            {
                if (word.Length >= currentMaxWord)
                {
                  currentMaxWord = Math.Max(currentMaxWord, DFS(0, word, string.Empty, result, words));
                }
                else
                    break;
            }
            return result.Keys.Count > 0 ? result.Keys.First() : "";
        }

        private static int DFS(int start, string word, string track, SortedDictionary<string, string> result, string[] wordList)
        {
            if(word.Length == 1 && !result.ContainsKey(word) && wordList.Contains(word)) //words with 1 character
            {
                result.Add(word, track);
                return word.Length;
            }

            if(track.Length == word.Length - 1 && !result.ContainsKey(word) && wordList.Contains(track))
            {
                result.Add(word, track);
                return word.Length;
            }
             
            for(int i = start; i < word.Length-1; i++)
            {
                track = track + word[i];
                if (wordList.Contains(track))
                {
                   return DFS(i + 1, word, track, result, wordList);
                }
                else
                {
                   break;
                }
            }
            return 0;
        }
    }
}
