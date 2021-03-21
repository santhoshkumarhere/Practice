using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.BackTracking
{
    public class GenerateParenthesis
    {
        public static void Test()
        {
            var res = GenerateParentheses(3);
        }

        private static IList<string> GenerateParentheses(int n)
        {
            var result = new List<string>();
            BackTracking(result, string.Empty, 0, 0, n);
            return result;
        }
        

        private static void BackTracking(IList<string> result, string track, int open, int close, int n)
        {
            if(track.Length == n * 2)
            {
                result.Add(track);
                return;
            }

            if (open < n)
                BackTracking(result, track + '(', open + 1, close, n);
            if (close < open)
                BackTracking(result, track + ')', open, close + 1, n);
        }
    }
}
