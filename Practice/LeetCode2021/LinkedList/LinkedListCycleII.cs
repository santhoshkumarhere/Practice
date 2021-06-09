using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.LinkedList
{
    public class LinkedListCycleII
    {
        public static void Test()
        {
            var list = new ListNode(3);
            var list2 = new ListNode(2);
            var list0 = new ListNode(0);
            var list4 = new ListNode(4);
            list.next = list2;
            list2.next = list0;
            list0.next = list4;
            list4.next = list2;
            var res = DetectCycle(list);
        }

        private static ListNode DetectCycle(ListNode head)
        {
            var slowPointer = head;
            var fastPointer = head;
            var start = head;
            
            while(fastPointer != null && fastPointer.next != null)
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;
                if(slowPointer == fastPointer)
                {
                    while(slowPointer != start)
                    {
                        slowPointer = slowPointer.next;
                        start = start.next;
                    }
                    return start;
                }
            }

            return new ListNode(-1);
        }
    }
}
