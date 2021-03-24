using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.LinkedList
{
    public class ListNode
    {
      public int val;
      public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
         }
    }

    public class LinkedListCycle
    {
        public static void Test()
        {

        }

        private static bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            var slow = head;
            var fast = head;

            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
