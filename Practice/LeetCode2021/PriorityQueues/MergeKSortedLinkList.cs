using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueues
{
    internal class MergeKSortedLinkList  //Hard problem
    {
        public static void Test()
        {
            //[[1,4,5],[1,3,4],[2,6]]
            var list1 = CreateList(new int[] { 1, 4, 5 });
            var list2 = CreateList(new int[] { 1, 3, 4 });
            var list3 = CreateList(new int[] { 2, 6 });
            var res = MergeKLists(new ListNode[] { list1, list2, list3 });
        }

        private static ListNode MergeKLists(ListNode[] lists)
        {
            var pq = new PriorityQueue<ListNode, int>();
            var dummy = new ListNode(-1);
            var curr = dummy;
            foreach (var list in lists)
            {
               pq.Enqueue(list, list.Val); // insret only the first values from lists to PQ
            }
            
            while (pq.Count > 0)
            {
                curr.Next = pq.Dequeue();
                curr = curr.Next;

                if (curr.Next != null)
                    pq.Enqueue(curr.Next, curr.Next.Val); //make sure here you pull next.val
            }

            return dummy.Next;
        }

        private static ListNode CreateList(int[] nums)
        {
            var dummy = new ListNode(-1);
            var curr = dummy;

            foreach(int num in nums)
            {
                curr.Next = new ListNode(num);
                curr = curr.Next;
            }
            return dummy.Next;
        }
    }
}
