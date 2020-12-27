using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class LinkedListPartitionList
    {
        public static void Test()
        {
            var one_1 = new ListNode(1);
            var two_1 = new ListNode(2);
            var two_2 = new ListNode(2);
            var three_1 = new ListNode(3);
            var four_1 = new ListNode(4);
            var five_1 = new ListNode(5);

            one_1.Next = four_1;
            four_1.Next = three_1;
            three_1.Next = two_1;
            two_1.Next = five_1;
            five_1.Next = two_2;
            var res = Partition(one_1, 3);
        }

        private static ListNode Partition(ListNode head, int x)
        {
            //excellent job - similar to MergetTwoLinkedList - Draw array like boxes with pointers and solve this on paper
            if (head == null) return head;
            var dummy = new ListNode(-1);
            var curr = dummy;

            var g = new ListNode(-1);
            g.Next = head;
            var ptr = g;

            while(ptr != null && ptr.Next != null)
            {
                if(ptr.Next.Val < x)
                {
                    curr.Next = ptr.Next;
                    curr = curr.Next;
                    ptr.Next = ptr.Next?.Next; // or curr.Next;
                }
                else
                {
                    ptr = ptr.Next;
                }
            }
            curr.Next = g.Next;
            return dummy.Next;
        }
    }
}
