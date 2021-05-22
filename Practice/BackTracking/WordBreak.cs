using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    public class WordBreak
    {
        public static void Test()
        {
            //var res = WordBreaks("leetcode", new List<string>() { "leet", "code", "ee" });
            //var res2 = wordBreakQueue("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            //var dict = new Dictionary<int, bool>();
            //var res3 = WordBreakWithMemoization("aaaaaaa", new HashSet<string>() { "aaaa", "aaa" }, 0, dict);

            var r = MyWordBreaks("leetcode", new HashSet<string>() { "leet", "code" }, 0);
            var r1 = MyWordBreaks("catsandog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0);

            var m1 = MyWordBreakWithMemoization("leetcode", new HashSet<string>() { "leet", "code" }, 0, new Dictionary<int, bool>());
            var m2 = MyWordBreakWithMemoization("catsandog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0, new Dictionary<int, bool>());

        }

        //based on recent subset backtrack understanding start = i + 1
        public static bool MyWordBreaks(string s, HashSet<string> set, int start)
        {
            if (start == s.Length)
            {
                return true;
            }

            for (var i = start; i < s.Length; i++)
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

            if (memo.ContainsKey(start))
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
    }
}
