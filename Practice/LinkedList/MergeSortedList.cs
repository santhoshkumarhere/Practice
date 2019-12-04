using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LinkedList
{
    class MergeSortedList
    {
        public static void Test()
        {
            var list1 = new ListNode(1);
            list1.next = new ListNode(5);
            list1.next.next = new ListNode(4);

            var list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);
            MergeTwoLists(list1, list2);
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }

                prev = prev.next;
            }

            prev.next = l1 ?? l2;
            return prehead.next;
            }
        }
    }

