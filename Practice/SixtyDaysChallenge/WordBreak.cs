using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class WordBreak
    {
        public static void Test()
        {
            var r = word_Break("leetcode", new HashSet<string>() { "leet", "code" }, 0, new Dictionary<int, bool>());
            r = Dp("catsanddog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" });
        }

        public static bool word_Break(string s, HashSet<string> wordDict, int start, Dictionary<int, bool> memo)
        {
            if(start == s.Length)
            {
                return true;
            }
            if(memo.ContainsKey(start))
            {
                return memo[start];
            }

            for( var end = start+1; end <= s.Length; end++)
            {
                if(wordDict.Contains(s.Substring(start, end - start)) && word_Break(s, wordDict, end, memo))
                {
                    return memo[start] = true;
                }
            }
            return memo[start] = false;
        }

        public static bool Dp(string s, HashSet<String> wordDictSet)
        {
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var subs = s.Substring(j, i - j);
                    Console.WriteLine(subs);
                    if (dp[j] == true && wordDictSet.Contains(subs))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
