using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LinkedList
{
    class RemoveKthFromLinkedList
    {
        public static void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);
            RemoveNthFromEnd(list, 1); 
        }
         

        public static  ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;
            // Advances first pointer so that the gap between first and second is n nodes apart
            for (int i = 1; i <= n + 1; i++)
            {
                first = first.next;
            }
            // Move first to the end, maintaining the gap
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return dummy.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x) { val = x; }
     } 
}
