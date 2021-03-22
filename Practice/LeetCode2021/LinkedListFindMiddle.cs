using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LinkedListFindMiddle
    {
        public static void Test()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            var n6 = new ListNode(6);
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
            var result1 = FindMiddle(n1);
            n5.Next = n6;
            var result2 = FindMiddle(n1);
        }

        private static ListNode FindMiddle(ListNode head)
        {
            if (head == null) return head;
            var slow = head;
            var fast = head;
            ListNode middle;

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            middle = slow;
            return middle;
        }
    }
}
