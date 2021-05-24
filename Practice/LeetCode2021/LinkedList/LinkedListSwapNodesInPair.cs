using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LinkedListSwapNodesInPair
    {
        public static void Test()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
          // var res = SwapPairs(n1);
            var ress = SwapPairs2(n1);
        }

        private static ListNode SwapPairs2(ListNode head)
        {
            var dummy = new ListNode(0);

            dummy.Next = head;
            var prevNode = dummy;
            while(head != null && head.Next != null)
            {
                var firstNode = head;
                var secondNode = head.Next;

                // Swapping              
                firstNode.Next = secondNode.Next; // 1->3->4->5
                secondNode.Next = firstNode; // 2-> 1-> 3-> 4-> 5 
                prevNode.Next = secondNode; // 0 => 2-> 1-> 3-> 4-> 5 look dummy gets modified

                // Reinitializing the head and prevNode for next swap
                prevNode = firstNode;
                head = prevNode.Next;
            }

            return dummy.Next;
        }

        private static ListNode SwapPairs(ListNode head)
        {
            var dummy = new ListNode(0);
            dummy.Next = head;
            var current = dummy;

            while (current.Next != null && current.Next.Next != null)
            {
                var first = current.Next;
                var second = current.Next.Next;

                first.Next = second.Next;
                current.Next = second;
                current.Next.Next = first;
                current = current.Next.Next;
            }
            return dummy.Next;
        }
    }
}
