using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LinkedListSwapNodesInPair
    {
        public static void Test()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
           var res = SwapPairs(n1);
        }

        private static ListNode SwapPairs(ListNode head)
        {
            var dummy = new ListNode(0);
            dummy.Next = head;
            var current = dummy;

            while (current.Next != null && current.Next.Next != null)
            {
                var first = current.Next;
                var second = current.Next.Next;

                first.Next = second.Next;
                current.Next = second;
                current.Next.Next = first;
                current = current.Next.Next;
            }
            return dummy.Next;
        }
    }
}
