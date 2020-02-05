using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    class ValidParenthesis_E_
    {
        public static void Test()
        {
            var res = IsValid("{[}");
        }

        private static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var dict = new Dictionary<char, char> {
                {'}', '{'},
                {']', '['},
                {')', '('}
            };
            var stack = new Stack<char>();
            foreach(var c in s)
            {
                if(IsClose(c))
                {
                    if (stack.Count == 0 || stack.Pop() != dict[c])
                    {
                        return false;                        
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }

        private static bool IsClose(char c)
        {
            return c == '}' || c == ']' || c == ')';
        }
    }
}
