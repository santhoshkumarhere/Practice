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
            list1.next = new ListNode(4);
            list1.next.next = new ListNode(5);

            var list2 = new ListNode(1);
            list2.next = new ListNode(3);
           // list2.next.next = new ListNode(4);
            MergeTwoLists(list1, list2);
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(-1);

            ListNode curr = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }

                curr = curr.next;
            }

            curr.next = l1 ?? l2;
                return dummy.next;
            }
        }
    }

