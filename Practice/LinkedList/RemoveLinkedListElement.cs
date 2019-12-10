using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LinkedList
{
    class RemoveLinkedListElement
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        //Input:  1->2->6->3->4->5->6, val = 6
        //Output: 1->2->3->4->5

        public static void Test()
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(6);
            list.next.next.next = new ListNode(3);
            list.next.next.next.next = new ListNode(4);
            list.next.next.next.next.next = new ListNode(5);
            list.next.next.next.next.next.next = new ListNode(6);
            RemoveElements(list, 6);
        }
        
        public static ListNode RemoveElements(ListNode head, int val)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var prev = dummy;

            while (head != null)
            {
                if (head.val != val)
                {
                    prev = head;
                }
                else
                {
                    prev.next = head.next;
                }
                head = head.next;
            }

            return dummy.next;
        } 
    }
}
