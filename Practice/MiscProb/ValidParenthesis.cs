using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    internal class ValidParenthesis
    {

        public bool IsValidParenthesis(string s)
        {
            //[])
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var len = s.Length;
            var stack = new Stack<char>();
            var dic = new Dictionary<char, char>
            {
                { '}', '{' },
                { ')', '(' },
                { ']', '[' },
            };
            for (var i = 0; i < len; i++)
            {
                if (i == 0 && !IsOpenChar(s[i]))
                {
                    return false;
                }

                if (IsOpenChar(s[i]))
                {
                    stack.Push(s[i]);
                }
                else if (stack.Count == 0 || stack.Pop() != dic[s[i]])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
        
        private static bool IsOpenChar(char c) => c == '(' || c == '{' || c == '[';
    }
}
