using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.LinkedList
{
    public class LinkedListConvertBinaryToInteger
    {
        public static void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(0);
            list.next.next = new ListNode(1);

            var res = GetDecimalValue(list);
        }

        private static int GetDecimalValue(ListNode head)
        {
            var stack = new Stack<int>();

            var curr = head;

            while (curr != null)
            {
                stack.Push(curr.val);
                curr = curr.next;
            }

            double result = 0;
            var position = 0;
            while (stack.Count > 0)
            {
                var stackValue = stack.Pop();
                result = result + (stackValue * Math.Pow(2, position));
                position++;
            }
            return Convert.ToInt32(result);
        }
    }
}
