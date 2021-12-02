using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.LinkedList
{
    internal class LinkedListRemoveElements
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var curr = head; // can use head instead of curr

            var prev = dummy;

            while (curr != null)
            {
                if (curr.val == val)
                {
                    prev.next = curr.next;
                }
                else
                {
                    prev = curr;
                }
                curr = curr.next;
            }
            return dummy.next;

        }
    }
}
