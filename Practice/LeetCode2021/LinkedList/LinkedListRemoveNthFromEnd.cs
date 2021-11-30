using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.LinkedList
{
    internal class LinkedListRemoveNthFromEnd
    {
        public static void Test()
        {                                   //*     5 - 3 + 1
            // 2 pass algo idea L - n + 1                1 2 3 4 5
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            var res = RemoveNthFromEnd(head, 2);
        }

        private static ListNode RemoveNthFromEndOnePass(ListNode head, int n)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var first = head;
            var second = dummy; // idea is first and second pointers are n node apart
            var len = 0;
            while (len < n) // L = 5 then move it twice so that ptr goes to node 3
            {
                len++;
                first = first.next; // first at node 3
            }

            while(first != null)
            {
                first = first.next;
                second = second.next; //second starts from node dummy 0
            }

            second.next = second.next.next;
            
            return dummy.next;
        }

        private static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var curr = head;

            var len = 0;

            while (curr != null)
            {
                len++;
                curr = curr.next;
            }

            len -= n;
            curr = dummy;

            while (len > 0) // move until node 3
            {
                len--;
                curr = curr.next;
            }

            curr.next = curr.next.next;

            return dummy.next;
        }
    }
}
