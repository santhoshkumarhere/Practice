using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class ReverseOnlyLettersProblem
    {
        public static void Test()
        {
            var res = ReverseOnlyLettersStack("a-bC-dEf-ghIj"); //"j-Ih-gfE-dCba"
            var res2 = ReverseOnlyLettersStack("Test1ng-Leet=code-Q!"); //"Qedo1ct-eeLg=ntse-T!"
            var res3 = ReverseOnlyLettersStack("?6C40E"); //6E40C
        }

        private static string ReverseOnlyLettersStack(string S)
        {
            var stack = new Stack<char>();
            var res = new StringBuilder();
            foreach(var c in S)
            {
                if(char.IsLetter(c))
                {
                    stack.Push(c);
                }
            }

            for(var i = 0; i < S.Length; i++)
            {
                if (char.IsLetter(S[i]))
                    res.Append(stack.Pop());
                else
                    res.Append(S[i]);                
            }

            return res.ToString();
        }
        private static string ReverseOnlyLettersMySolution(string S)
        {
            var l = 0;
            var r = S.Length - 1;
            var ch = S.ToCharArray();
            while (l < r)
            {
                while (!char.IsLetter(ch[l]) && l < r)
                {
                    l++;
                }
                while (!char.IsLetter(ch[r]) && l < r)
                {
                    r--;
                }
                if(char.IsLetter(ch[l]) && char.IsLetter(ch[r]))
                {
                    var temp = ch[r];
                    ch[r] = ch[l];
                    ch[l] = temp;
                    l++;
                    r--;
                }
            }
            return new String(ch);
        }
    }
}
