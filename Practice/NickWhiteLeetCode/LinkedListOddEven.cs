using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class ListNode
    {
        public int Val;

        public ListNode Next;
        
        public ListNode(int x) => this.Val = x;
    }

    public class LinkedListOddEven
    {
        public static void Test()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            var n6 = new ListNode(6);
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
            OddEvenList(n1);
        }

        private static ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;

            //1->2->3->4->5->

            var odd = head; //(odd head)
            var even = head.Next;
            var evenHead = even; //(even head )

            while(even != null && even.Next != null)
            {
                odd.Next = even.Next; 
                odd = odd.Next;  
                even.Next = odd.Next;
                even = even.Next;
                even.Next = null;
            }

            odd.Next = evenHead;
            return head;
        }
    }
}
