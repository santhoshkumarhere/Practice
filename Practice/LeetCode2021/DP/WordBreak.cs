using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class WordBreak
    {
        public static void Test()
        {
            //var res = WordBreaks("leetcode", new List<string>() { "leet", "code", "ee" });
            //var res2 = wordBreakQueue("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            //var dict = new Dictionary<int, bool>();
            //var res3 = WordBreakWithMemoization("aaaaaaa", new HashSet<string>() { "aaaa", "aaa" }, 0, dict);
            var r = WordBreaksDP("leetcode", new List<string>() { "leet", "code" });

            // var r= MyWordBreaks("leetcode", new HashSet<string>() { "leet", "code" }, 0);
            // var r1 = MyWordBreaks("catsandog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0);

            //var m1 = MyWordBreakWithMemoization("leetcode", new HashSet<string>() { "leet", "code" }, 0, new Dictionary<int, bool>());
            // var m2 = MyWordBreakWithMemoization("catsandog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0, new Dictionary<int, bool>());

        }

        public static bool WordBreaksDP(string s, List<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int end = 1; end <= s.Length; end++)
            {
                for (int st = 0; st < end; st++)
                {
                    var subs = s.Substring(st, end - st);
                    Console.WriteLine(subs);
                    if (dp[st] == true && wordDictSet.Contains(subs))
                    {
                        dp[end] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }

        //based on recent subset backtrack understanding start = i + 1
        public static bool MyWordBreaks(string s, HashSet<string> set, int start)
        {
            if (start == s.Length)
            {
                return true;
            }

            for(var i = start; i < s.Length; i++)
            {
                var sb = s.Substring(start, (i - start) + 1);
                if (set.Contains(sb) && MyWordBreaks(s, set, i + 1))
                {
                    Console.WriteLine(sb.ToString());
                    return true;
                }
            }
            return false;
        }

        public static bool MyWordBreakWithMemoization(string s, HashSet<string> set, int start, Dictionary<int, bool> memo)
        {
            if (start == s.Length)
            {
                return true;
            }

            if(memo.ContainsKey(start))
            {
                return memo[start];
            }

            for (var i = start; i < s.Length; i++)
            {
                var sb = s.Substring(start, (i - start) + 1);
                if (set.Contains(sb) && MyWordBreakWithMemoization(s, set, i + 1, memo))
                {
                    memo[start] = true;
                    Console.WriteLine(sb.ToString());
                    return true;
                }
            }
            return memo[start] = false;
        }

        public static bool word_Break(string s, HashSet<string> wordDict, int start)
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
            if (start == s.Length) // use this for memo solution 12/1/2021
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
                if (!visited[start])
                {
                    for (int end = start + 1; end <= s.Length; end++)
                    {
                        if (wordDictSet.Contains(s.Substring(start, end - start)))
                        {
                            Console.WriteLine(s.Substring(start, end - start));
                            queue.Enqueue(end); //this will be the next start
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
        
        public static bool WordBreaksMyWay(string s, List<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var dp = new HashSet<int>();
            dp.Add(-1);

            for (int end = 1; end <= s.Length; end++)
            {
                for (int st = 0; st < end; st++)
                {
                    var subs = s.Substring(st, end - st);
                    Console.WriteLine(subs);
                    if (dp.Contains(st - 1) && wordDictSet.Contains(subs))
                    {
                        dp.Add(end-1);
                        break;
                    }
                }
            }
            return dp.Contains(s.Length - 1);
        }
    }
}
