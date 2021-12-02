using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.BasicCalculator
{
    class BasicCalculatorExpression
    {
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

                    // Forming operand, since it could be more than one digit
                    operand = 10 * operand + (int)(ch - '0');

                }
                else if (ch == '+')
                {

                    // Evaluate the expression to the left,
                    // with result, sign, operand
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

                    // Push the result and sign on to the stack, for later
                    // We push the result first, then sign
                    stack.Push(result);
                    stack.Push(sign);

                    // Reset operand and result, as if new evaluation begins for the new sub-expression
                    sign = 1;
                    result = 0;

                }
                else if (ch == ')')
                {

                    // Evaluate the expression to the left
                    // with result, sign and operand
                    result += sign * operand;

                    // ')' marks end of expression within a set of parenthesis
                    // Its result is multiplied with sign on top of stack
                    // as stack.pop() is the sign before the parenthesis
                    result *= stack.Pop();

                    // Then add to the next operand on the top.
                    // as stack.pop() is the result calculated before this parenthesis
                    // (operand on stack) + (sign on stack * (result from parenthesis))
                    result += stack.Pop();

                    // Reset the operand
                    operand = 0;
                }
            }
            return result + (sign * operand);
        }
    }
}
