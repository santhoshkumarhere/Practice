using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }

    class AddTwoNumbers_M
    {

        public static void Test() {
            var l1 = new ListNode(2);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);

            var l2 = new ListNode(2);
            l2.next = new ListNode(9);

            var result = AddTwoNumbers(l1, l2);
        }


        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var p = l1; var q = l2; 
            var curr = dummy;
            
            var carry = 0;

            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                var sum = x + y + carry;
                curr.next = new ListNode(sum % 10);
                carry = sum / 10;
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if(carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return dummy.next;
        }


    }
}
