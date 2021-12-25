using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.BasicCalculator
{
    class BasicCalculatorExpression
    {

        public static void Test()
        {
            var res = EvaluateExpression("7-(8+9)");
        }

        private static int EvaluateExpression(string s)
        {
            Stack<int> stack = new Stack<int>();
            int operand = 0;
            int result = 0;
            int sign = 1;
            foreach(var c in s)
            {
                if(Char.IsDigit(c))
                {
                    operand = operand * 10 + (c - '0');
                }
                else if(c == '+' || c == '-')
                {
                    result += operand * sign;
                    sign = c == '-' ? -1 : 1;
                    operand = 0;
                }
                else if(c == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if( c == ')')
                {
                    result += operand * sign;
                    result *= stack.Pop(); // multiply with sign
                    result += stack.Pop();
                    operand = 0;
                }
            }
            return result + (operand * sign);

        }

        public int Calculate(string s)
        {

            Stack<int> stack = new Stack<int>();
            int operand = 0;
            int result = 0; // For the on-going result
            int sign = 1;  // 1 means positive, -1 means negative

            for (int i = 0; i < s.Length; i++)
            {

                char ch = s[i];
                if (Char.IsDigit(ch))
                {
                    operand = 10 * operand + (int)(ch - '0');
                }
                else if (ch == '+')
                {
                    result += sign * operand;

                    // Save the recently encountered '+' sign
                    sign = 1;

                    // Reset operand
                    operand = 0;

                }
                else if (ch == '-')
                {

                    result += sign * operand;
                    sign = -1;
                    operand = 0;

                }
                else if (ch == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);

                    // Reset operand and result, as if new evaluation begins for the new sub-expression
                    sign = 1;
                    result = 0;

                }
                else if (ch == ')')
                {
                    result += sign * operand;
                    result *= stack.Pop();

                    result += stack.Pop();

                    // Reset the operand
                    operand = 0;
                }
            }
            return result + (sign * operand);
        }
    }
}
