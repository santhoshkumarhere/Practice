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
           // var res1= LongestWord(new string[] { "w", "wo", "wor", "worl", "world" });
            var res2 = LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" });
            var res3 = LongestWord(new string[] { "ts", "e", "x", "pbhj", "opto", "xhigy", "erikz", "pbh", "opt", "erikzb", "eri", "erik", "xlye", "xhig", "optoj", "optoje", "xly", "pb", "xhi", "x", "o" });
            var res4 = LongestWord(new string[] { "a" });
        }

        private static string LongestWord(string[] words)
        {
            var wordset = new HashSet<string>(words);

            Array.Sort(words, (a, b) => a.Length == b.Length
                        ? a.CompareTo(b) 
                        : b.Length - a.Length);
            
            foreach (string word in words)
            {
                var good = true;
                for (int k = 1; k < word.Length; ++k)
                {
                    if (!wordset.Contains(word.Substring(0, k)))
                    {
                        good = false;
                        break;
                    }
                }
                if (good) return word;
            }

            return "";
        }

        private static string LongestWordMy(string[] words)
        {
            if (words.Length == 1) return words[0];

            var wordSet = new HashSet<string>(words); //run time goes down from 2000ms to 650ms by changing it to set from List
            var sortedWords = words.OrderByDescending(x => x.Length);
            var result = new SortedDictionary<string, string>();
            int currentMaxWord = 0;

            foreach(var word in sortedWords)
            {
                if (word.Length >= currentMaxWord)
                {
                  currentMaxWord = Math.Max(currentMaxWord, DFS2(0, word, string.Empty, result, wordSet));
                }
                else
                    break;
            }
            return result.Keys.Count > 0 ? result.Keys.First() : "";
        }

        private static int DFS2(int start, string word, string track, SortedDictionary<string, string> result, HashSet<string> wordSet)
        {
            if (word.Length == 1 && !result.ContainsKey(word) && wordSet.Contains(word)) //words with 1 character
            {
                result.Add(word, track);
                return word.Length;
            }

            for (int i = start; i < word.Length - 1; i++)
            {
                track = track + word[i];
                if (wordSet.Contains(track))
                {
                    if (track.Length == word.Length - 1 && !result.ContainsKey(word) && wordSet.Contains(track))
                    {
                        result.Add(word, track);
                        return word.Length;
                    }
                    continue;
                }
                else
                {
                    break;
                }
            }
            return 0;
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
