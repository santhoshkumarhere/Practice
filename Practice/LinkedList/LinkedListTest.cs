using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Practice.LinkedList
{
    class LinkedListTest
    {
        public static void Test()
        {
            var list = new LinkNode(1);
            list.Next = new LinkNode(2);
            list.Next.Next = new LinkNode(3);
            list.Next.Next.Next = new LinkNode(4);
           // list.Next.Next.Next.Next = list.Next;
            var prev = Reverse(list);//ReverseList(list);
            //Print(prev);
            Console.WriteLine($"Cyclical: {IsCyclical(list)}");
        }

        public static void Print(LinkNode list)
        {
            while (list != null)
            {
                Console.WriteLine(list.Value);
                list = list.Next;
            }
        }

        public static bool IsCyclical(LinkNode head)
        {
            var fastPointer = head;
            var slowPointer = head;
            Console.WriteLine(slowPointer.Value);
            while (fastPointer?.Next != null)
            {

                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
                Console.WriteLine(slowPointer.Value);
                if (fastPointer == slowPointer)
                {
                    return true;
                }

            }

            return false;
        }

        private static LinkNode Reverse(LinkNode head)
        {
            LinkNode prev = null;
            var curr = head;
            while (curr != null)
            {
                var next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        public static LinkNode ReverseList(LinkNode list)
        {
            LinkNode curr = list;
            LinkNode prev = null;
            LinkNode next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }

    class LinkNode
    {
        public int Value { get; set; }
        public LinkNode Next { get; set; }

        public LinkNode(int val)
        {
            this.Value = val;
        }
    }
}
