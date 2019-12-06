using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LinkedList
{
    class MergeKSortedList
    {
        public static ListNode  Test()
        {
            var list1 = new ListNode(1);
            list1.next = new ListNode(4);
            list1.next.next = new ListNode(5);

            var list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);

            var list3 = new ListNode(2);
            list3.next = new ListNode(6);

            var input = new ListNode[] { list1, list2, list3 };

            if(input.Length == 0)
            {
                return null;
            }
            if(input.Length <=1)
            {
                return input[0];
            }

            var count = 0;
            var result = input[0];
            while (count < input.Length-1)
            {               
                result = MergeKList(result, input[count+1]);
                count++;
            }
            return result;
        }

        static ListNode MergeKList(ListNode l1, ListNode l2)
        {
            var preHead = new ListNode(-1);
            var prev = preHead;

            while(l1 != null && l2 != null)
            {
                if(l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }
            prev.next = l1 ?? l2;

            return preHead.next;
        }
    }
}
