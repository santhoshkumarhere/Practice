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
            var list = new SinglyLinkedListNode(1);
            list.Next = new SinglyLinkedListNode(2);
            list.Next.Next = new SinglyLinkedListNode(3);
            list.Next.Next.Next = new SinglyLinkedListNode(4);
            list.Next.Next.Next.Next = list.Next;
            //Print(list);
            //var prev =  ReverseList(list);
            //Print(prev);
            Console.WriteLine($"Cyclical: {IsCyclical(list)}");
        }

        public static void Print(SinglyLinkedListNode list)
        {
            while (list != null)
            {
                Console.WriteLine(list.Value);
                list = list.Next;
            }
        }

        public static bool IsCyclical(SinglyLinkedListNode head)
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

        public static SinglyLinkedListNode ReverseList(SinglyLinkedListNode list)
        {
            SinglyLinkedListNode curr = list;
            SinglyLinkedListNode prev = null;
            SinglyLinkedListNode next = null;

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

    class SinglyLinkedListNode
    {
        public int Value { get; set; }
        public SinglyLinkedListNode Next { get; set; }

        public SinglyLinkedListNode(int val)
        {
            this.Value = val;
        }
    }
}
