using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.LinkedList
{
    public class LinkedListSortONLogN
    {
        public static void Test()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            node4.next = node2;
            node2.next = node1;
            node1.next = node3;
            var result = SortList(node4);
        }

        private static  ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode mid = SplitList(head);
            ListNode left = SortList(head); //head will have second half and mid will have right half
            ListNode right = SortList(mid);
            return Merge(left, right);
        }

        private static ListNode Merge(ListNode list1, ListNode list2)
        {
            //Merge two sorted list
            var dummy = new ListNode(-1);
            var curr = dummy;

            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    curr.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    curr.next = list2;
                    list2 = list2.next;
                }
                curr = curr.next;
            }

            curr.next = list1 ?? list2;
            return dummy.next;
        }

        private static ListNode SplitList(ListNode head)
        {
            var fast = head;
            var slow = head;
            ListNode prev = null;
            while(fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            prev.next = null; // it will split the head into left half
            return slow;
        }
    }
}
