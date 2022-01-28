using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.DP
{
    internal class RegularExpressionMatch_HardTabulation
    {
        public static void Test()
        {
            //take smaller examples and work through it aa a*
            // Difference between Regular and WildCard is, Regualar wont start with * so we can do j+1, but  WildCard can start with *, so we cannot do j+1
            var result = DFS("aab", "c*a*b", 0, 0, new Dictionary<(int, int), bool>());
        }

        private static bool DFS(string s, string p, int i, int j, Dictionary<(int, int), bool> cache)
        {
            if (cache.ContainsKey((i, j)))
                return cache[(i, j)];

            if (i >= s.Length && j >= p.Length)
                return true;
            if (j >= p.Length)
                return false;

            var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                return cache[(i, j)] = (DFS(s, p, i, j + 2, cache) ||
                    match && DFS(s, p, i + 1, j, cache));
            }

            if (match)
            {
               return cache[(i, j)] = DFS(s, p, i + 1, j + 1, cache);                
            }

            return cache[(i, j)] = false;
        }

        private static bool DFS(string s, string p, int i, int j)
        {
            if (i >= s.Length && j >= p.Length)
                return true;
            if (j >= p.Length)
                return false;

            var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

            if(j + 1 < p.Length && p[j+1] == '*')
            {
                return ( match && DFS(s, p, i + 1, j) ) || DFS(s, p, i, j + 2); // aa a* a[i] == a[j] && a[i+1] == a[j] && a[i+2] == a[j]   || skip * i.e., j+2
            }

            if(match)
                return DFS(s, p, i + 1, j + 1);
            return false;
        }
    }
}
