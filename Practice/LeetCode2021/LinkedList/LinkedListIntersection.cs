using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.LinkedList
{
    public class LinkedListIntersection
    {
        public static void Test()
        {
            //1 -> 2 -> 3 -> 5 -> 6 -> 7 ->8
            //1 -> 2 --------^
            //1 2 3 5 6 7 8 1 2 5
            //1 2 5 6 7 8 1 2 3 5
            //solution would be lot simpler with hashset with visited
        }

        private static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var ptrA = headA;
            var ptrB = headB;

            while(ptrA != ptrB)
            {
                ptrA = ptrA == null ? headB : ptrA.next;
                ptrB = ptrB == null ? headA : ptrB.next;
            }

            return ptrA; // null in case there is no intersection
        }
    }
}
