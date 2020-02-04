using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class MergeSortedList_E
    {
        public static void Test()
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            var result = MergeTwoLists(l1, l2);
        }

        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(-1);
            var curr = dummy;

            while( l1 != null && l2 != null)
            {
                if(l1.val <= l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            curr.next = l1 ?? l2;
            return dummy.next;
        }

            private static ListNode MergeTwoLists_Own(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var curr = dummy;
            var p = l1; var q = l2;

            while(p != null || q != null)
            {
                var x = p != null ? p.val : int.MaxValue;
                var y = q != null ? q.val : int.MaxValue;

                if (x <= y && p != null)
                {
                    curr.next = new ListNode(x);
                    p = p.next;
                }
                else if (y <= x && q != null)
                {
                    curr.next = new ListNode(y);
                    q = q.next;
                }

                if(curr != null)
                curr = curr.next;
            }

            return dummy.next;
        }
    }
}
