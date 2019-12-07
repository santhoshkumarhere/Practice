using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Misc
{
    class WordBreak
    {
        public static void Test()
        {
          // var res = WordBreaks("leetcode", new List<string>() { "leet", "code" });
             //var res2 = wordBreakQueue("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            //var dict = new Dictionary<int, bool>();
            //var res3 = WordBreakWithMemoization("aaaaaaa", new HashSet<string>() { "aaaa", "aaa" }, 0, dict);

             var r= word_Break("leetcode", new HashSet<string>() { "leet", "code" }, 0);
            r = word_Break("catsanddog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0);
        }
        public static bool word_Break(String s, HashSet<String> wordDict, int start)
        {
            if (start == s.Length)
            {
                return true;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                var subs =  s.Substring(start, end - start);
                if (wordDict.Contains(subs) && word_Break(s, wordDict, end))
                {
                    Console.WriteLine(subs);
                    return true;
                }
            }
            return false;
        }

        public static bool WordBreakWithMemoization(string s, HashSet<string> set, int start, Dictionary<int, bool> memo)
        {
            if (start == s.Length)
            {
                return true;
            }
            if(memo.ContainsKey(start))
            {
                 return memo[start]; 
            }

            for (var end = start + 1; end <= s.Length; end++)
            {
                if(set.Contains(s.Substring(start, end - start)) && WordBreakWithMemoization(s, set, end, memo))
                {
                    //Console.WriteLine(s.Substring(start, end - start));
                    return memo[start] = true;
                }
            }
            return memo[start] = false;
        }


        public static bool wordBreakQueue(String s, List<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var queue = new Queue<int>();
            bool[] visited = new bool[s.Length];
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int start = queue.Dequeue();
                if (visited[start] == false)
                {
                    for (int end = start + 1; end <= s.Length; end++)
                    {
                        if (wordDictSet.Contains(s.Substring(start, end - start)))
                        {
                            Console.WriteLine(s.Substring(start, end - start));
                            queue.Enqueue(end);
                            if (end == s.Length)
                            {
                                return true;
                            }
                        }
                    }
                    visited[start] = true;
                }
            }
            return false;
        }
        
        public static bool WordBreaks(string s, List<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
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
