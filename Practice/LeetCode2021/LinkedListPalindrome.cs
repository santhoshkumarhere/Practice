using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    
   public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
   }

    public class LinkedListPalindrome
    {

        public static void Test()
        {

            var list12 = new ListNode(1);
            var list22 = new ListNode(2, list12);
            var list32 = new ListNode(3, list22);
            var list31 = new ListNode(3, list32);
            var list21 = new ListNode(2, list31);
            var list11 = new ListNode(1, list21);
            var result = IsPalindrome(list11);
        }
        private static  bool IsPalindrome(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            slow = Reversed(slow);
            fast = head;

            while (slow != null)
            {
                if (slow.val != fast.val)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next;
            }
            return true;
        }

        private static ListNode Reversed(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }
}
