using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class BackSpaceString
    {
        public static void Test()
        {
            BackSpaceCompare("a##c", "#a#c");
        }

        public static bool BackSpaceCompare(string S, string T)
        {
            int i = S.Length - 1;
            int j = T.Length - 1;

            while(i >= 0 || j >= 0)
            {
                var c1 = 0;
                while(i >=0 && (c1 > 0 || S[i] =='#'))
                {
                    if(S[i] == '#')
                    {
                        c1++;
                    }
                    else
                    {
                        c1--;
                    }
                    i--;
                }

                var c2 = 0;
                while (j >= 0 && (c2 > 0 || T[j] == '#'))
                {
                    if (T[j] == '#')
                    {
                        c2++;
                    }
                    else
                    {
                        c2--;
                    }
                    j--;
                }

                if (i >= 0 && j >= 0 && S[i] != T[j])
                    return false;
                // If expecting to compare char vs nothing
                if ((i >= 0) != (j >= 0))
                    return false;
                i--; j--;
            }
            return true;
        }
    }
}
