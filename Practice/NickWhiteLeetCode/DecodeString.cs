using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode
{
    public class DecodeString
    {
       public static void Test()
        {
            var res = DecodeStrings("3[z]2[2[y]pq4[2[jk]e1[f]]]ef"); // ("2[abc]3[cd]ef");
            //var res2 = DecodeStrings("abc3[cd]xyz");
            //var res1 = DecodeStrings("3[a2[c]]");//  ("3[a2[c]]");
        }

        private static string DecodeStrings(string s)
        {
            var stack1 = new Stack<char>();
            var stb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] != ']')
                {
                    stack1.Push(s[i]);
                }
                else
                {
                   Process(stack1);
                }
            }
            
            while (stack1.Count > 0)
            {
                stb.Insert(0, stack1.Pop());
            }
            return stb.ToString();
        }
        
        
        /// <summary>
        /// 1. Pop all the alphabets from stack and insert into a temp variable until you hit '['
        /// 2. Pop '['
        /// 3. Calculate times and run the loop and insert the char back to stack
        /// </summary>
        /// <param name="stack1"></param>
        private static void Process(Stack<char> stack1)
        {
            var curr = new StringBuilder();
            while (stack1.Count > 0 && char.IsLetter(stack1.Peek()))
                curr.Insert(0, stack1.Pop());

            stack1.Pop(); // pop '['
            
            int baseValue = 1;
            int times = 0;
            while (stack1.Count > 0 && char.IsDigit(stack1.Peek()))
            {
                times = times + (stack1.Pop() - '0') * baseValue; //ASCII 0 = 48
                baseValue *= 10;
            }           
                
            for (var i = 0; i < times; i++)
            {
                foreach (var c in curr.ToString())
                {
                    stack1.Push(c);
                }
            } 
        }
    }
}
