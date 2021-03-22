using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LinkedListMergeTwoSortedList
    {
        public static void Test()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n4 = new ListNode(4);
            n1.Next = n2;
            n2.Next = n4;

            var x1 = new ListNode(1);
            var x3 = new ListNode(3);
            var x4 = new ListNode(4);
            x1.Next = x3;
            x3.Next = x4;
            var res = MergeList(n1, x1);// merge

        }

        public static ListNode MergeList(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
         
            var dummy = new ListNode(-1);
            var curr = dummy;

            while( l1 != null && l2 != null)
            {
                if(l1.Val <= l2.Val)
                {
                    curr.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    curr.Next = l2;
                    l2 = l2.Next;
                }
                curr = curr.Next;
            }
            curr.Next = l1 ?? l2;
            return dummy.Next;
         }
        public static ListNode MergeListTryListNode(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            
            ListNode temp = l2;
            var p1 = l1;
            var p2 = l2;

            while( p1 != null && temp != null)
            {
                temp = p1.Next;
                p1.Next = p2;
                p1 = p1.Next;
                p2 = temp;
            }

            return l1;
        }
    }
}
