using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.BasicCalculator
{
    internal class BasicCalculatorI
    {
        public static void Test()
        {
            var res = Calculate("7-(8+9)");
        }

        private static int Calculate(string s)
        {
            var result = 0;
            var sign = 1;
            var stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    var sum = 0;
                    sum += s[i] - '0';
                    while (i + 1 < s.Length && Char.IsDigit(s[i + 1]))
                    {
                        sum = sum * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    result += sum * sign;
                }

                else if (s[i] == '+')
                    sign = 1;
                else if (s[i] == '-')
                    sign = -1;
                else if (s[i] == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    sign = 1;
                    result = 0;
                }
                else if (s[i] == ')')
                {
                    result *= stack.Pop(); //sign
                    result += stack.Pop();
                }
            }

            return result;
        }
    }
 }
