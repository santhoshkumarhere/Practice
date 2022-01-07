using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class StringProblems
    {

        public static void Test()
        {
            var words = new string[] { "hello", "leetcode" };
            var order = "hlabcdefgijkmnopqrstuvwxyz";
            var res = IsAlienSorted(words, order);

            var words2 = new string[] { "apple", "app" };
            var order2 = "abcdefghijklmnopqrstuvwxyz";
            var res2 = IsAlienSorted(words2, order2);

            var words3 = new string[] { "accord", "add" };
            var order3 = "abcdefghijklmnopqrstuvwxyz";
            var res3 = IsAlienSorted(words3, order3);

            var words4 = new string[] { "app", "apple" };
            var order4 = "abcdefghijklmnopqrstuvwxyz";
            var res4 = IsAlienSorted(words4, order4);
        }


        private static bool IsAlienSorted(string[] words, string order)
        {
            if (words.Length == 1) return true;

            var dict = new Dictionary<char, int>();

            for(var i = 0; i < order.Length; i++)
            {
                dict[order[i]] = i;
            }

            for(int i = 1; i < words.Length; i++)
            {
                if(!IsSorted(words[i-1], words[i], dict))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSorted(string word1, string word2, Dictionary<char, int> dict)
        {
            var minLength = Math.Min(word1.Length, word2.Length);

            for(var i = 0; i < minLength; i++)
            {
                if(word1[i] == word2[i])                        
                    continue;
                return dict[word1[i]] < dict[word2[i]];
            }

            return word1.Length <= word2.Length;
        }

    }
}
