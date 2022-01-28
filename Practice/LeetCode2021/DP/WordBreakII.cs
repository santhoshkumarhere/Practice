using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Misc
{
    class WordBreakII
    {
        public static void Test()
        {
            var res1 = WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            var res2 = WordBreakIIRecursion("catsanddog", new HashSet<string>() { "cat", "cats", "and", "sand", "dog" }, 0, new System.Collections.Generic.Dictionary<int, IList<string>>());
        }

        public static IList<string> WordBreakIIRecursion(string s, HashSet<string> set, int start, Dictionary<int, IList<string>> memo)
        {
           var res = new List<string>();

            if(s.Length == start)
            {
                res.Add("");
                return res;
            }

            if(memo.ContainsKey(start))
            {
                return memo[start];
            }

            for(var end = start + 1; end <= s.Length; end++)
            {
                var subs = s.Substring(start, end - start);
                if (set.Contains(subs))
                {
                    var list = WordBreakIIRecursion(s, set, end, memo);
                    memo[start] = list;
                    foreach(var item in list)
                    {
                         res.Add(subs + (item.Equals("") ? "" : " ") + item);
                    }
                }
            }
            memo[start] = res;
            return res;
        }

        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var result = new List<string>();

            var set = new HashSet<string>(wordDict);

            var q = new Queue<int>();

            q.Enqueue(0);

            while(q.Count > 0)
            {
                var start = q.Dequeue();
                for(var end = start + 1; end <= s.Length; end++)
                {
                    var subs = s.Substring(start, end - start);
                    if (set.Contains(subs))
                    {
                        q.Enqueue(end);
                        result.Add(subs);
                        if(end == s.Length)
                        {
                            return result;
                        }
                    }
                }
            }
            return result;

        }
    }
}
