using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class GenerateParanthesis_MH_
    {
        public static void Test()
        {
            var res = GenerateParenthesis(3);
        }

        public static List<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            Backtrack(ans, "", 0, 0, n);
            return ans;
        }

        public static void Backtrack(List<string> ans, string cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if (open < max)
                Backtrack(ans, cur + "(", open + 1, close, max);
            if (close < open)
                Backtrack(ans, cur + ")", open, close + 1, max);
        }
    }
}
