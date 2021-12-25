using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    internal class ReOrderList
    {

        public static void ReOrderListTest()
        {
            var list = new ListNode(1);
            list.next = new ListNode(2);
            list.next.next = new ListNode(3);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(5);
            ReOrderListUtil(list);
        }

        private static void ReOrderListUtil(ListNode head)
        {
            var dict = new Dictionary<int, ListNode>();
            var curr = head;
            var counter = 0;
            while(curr != null)
            {
                dict[counter++] = curr;
                curr = curr.next;
            }

            curr = head;
            for (int i = 1; i <= counter && curr != null; i++, curr = curr.next)
            {
                var next = curr.next;
                curr.next = dict[counter - i];
                curr.next.next = next;
                if(i == (counter/2) + 1)
                {
                    curr.next = null;
                    break;
                }
                if(i != counter - 1)
                    curr = curr.next;
            }
        }
    }
}
