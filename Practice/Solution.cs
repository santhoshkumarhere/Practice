using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Solution
    {
        public void CalculateSum()
        {
            ListNode one = new ListNode(5);
            ListNode two = new ListNode(5);
            ListNode three = new ListNode(5);
            one.next = two;
            two.next = three;

            ListNode ll1 = new ListNode(5);
            ListNode ll2 = new ListNode(5);
            ListNode ll3 = new ListNode(5);
            ll1.next = ll2;
            ll2.next = ll3;

            ListNode temp1 = new ListNode(0);
            //while (temp != null)
            //{
            //    Console.WriteLine(temp.val);
            //    temp = temp.next;
            //}
            //Console.ReadLine();
            int balance = 0;
            var result = this.ReverseList(one, ll1, out balance, temp1);
            ListNode temp = result.next;
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
            Console.ReadLine();
        }

        private ListNode ReverseList(ListNode l1, ListNode l2, out int balance, ListNode result)
        {
            if (l1 == null)
            {
                balance = 0;
                return null;
            }

            ReverseList(l1.next, l2.next, out balance, result);
            var remainder = (l1.val + l2.val + balance) - 10;


            var newNode = remainder >= 10 || remainder == 0 ? new ListNode(remainder) : new ListNode(l1.val + l2.val + balance);
            balance = remainder == 0 || remainder >= 10 ? 1 : 0;
            var temp = result;

            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
            return result;
        }

        private string solveSum(int one, int two, int remainder)
        {
            var result = one + two + remainder;
            if (result > 10)
            {
                return "1 - " + (result - 10);
            }
            else
            {
                return "0-0";
            }
        }

        private ListNode AddNumbers(ListNode l1, ListNode l2)
        {
            return l2;
        }
    }

    class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val)
        {
            this.val = val;
            this.next = null;
        }
    }
}
