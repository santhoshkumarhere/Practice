using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.DP
{
    internal class WildCardMatching_Hard
    {
        public static void Test()
        {
            string str = "aa";
            string pattern = "*";
            var result = IsMatch(str, pattern, 0, 0);
        }
        private static bool IsMatch(string s, string p, int i, int j)
        {
            // TL Exceeded
            if (i >= s.Length && j >= p.Length)
                return true;
            if (j >= p.Length)
                return false;

            if(i >= s.Length) // if i ended then check remaing patterns are *
            {
                for(int k = j; k < p.Length;k++)
                {
                    if (p[k] != '*')
                        return false;
                }
                return true;
            }


            if (p[j] == '*')
            {
                // the * could match 0+ chars in s
                return IsMatch(s, p, i + 1, j) || IsMatch(s, p, i, j + 1);
            }
            else
            {
                if (p[j] == '?' || s[i] == p[j])
                {
                    return IsMatch(s, p, i + 1, j + 1);
                }
                return false;
            }

            //var match = i < s.Length && (s[i] == p[j] || p[j] == '?');

            //if (j + 1 < p.Length && p[j + 1] == '*')
            //{
            //    return (IsMatch(s, p, i + 1, j) || IsMatch(s, p, i, j + 1)); //ignore char move I or ignore * and move j
            //}

            //if (match)
            //    return IsMatch(s, p, i + 1, j + 1);

            //return false;
        }
    }
}

/*
 * 
 

Fristly, the recursive solution is pretty easy:

class Solution 
{
    public boolean isMatch(String s, String p) 
    {
        return match(s, 0, p, 0);
    }
    
    boolean match(String s, int i, String p, int j)
    {
        if (i == s.length() && j == p.length()) return true;
        if (j == p.length()) return false;
        if (i == s.length())
        {
            // the remaining in p are *
            for (int k = j; k < p.length(); ++k) if (p.charAt(k) != '*') return false;
            return true;
        }
        
        if (p.charAt(j) == '*')
        {
            // the * could match 0+ chars in s
            return match(s, i + 1, p, j) || match(s, i, p, j + 1);
        }
        else
        {
            if (p.charAt(j) == '?' || s.charAt(i) == p.charAt(j))
            {
                return match(s, i + 1, p, j + 1);
            }
            return false;
        }
    }
}
After that, rewrite it to DP:

class Solution 
{
    public boolean isMatch(String s, String p) 
    {   
        // init base cases
        int m = s.length(), n = p.length();
        boolean[][] f = new boolean[m + 1][n + 1];
        f[m][n] = true;
        for (int j = n - 1; j >= 0; --j) if (p.charAt(j) == '*') f[m][j] = true; else break;
        
        // DP
        for (int i = m - 1; i >= 0; --i)
        {
            for (int j = n - 1; j >= 0; --j)
            {
                if (p.charAt(j) == '*') f[i][j] = f[i][j + 1] || f[i + 1][j];
                else if (p.charAt(j) == '?' || s.charAt(i) == p.charAt(j)) f[i][j] = f[i + 1][j + 1];
            }
        }
        
        return f[0][0];
    }
}

*/