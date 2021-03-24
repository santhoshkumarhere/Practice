using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class TetstLRUCache
    {
        public static void Test()
        {
            var lru = new LRUCache(3);
            lru.put(1, 1);
            lru.put(2, 2);
            lru.get(1);
            lru.put(3, 3);
            lru.put(4, 4);
        }
    }
    class DLinkedNode
    {
        public int key;
        public int value;
        public DLinkedNode prev;
        public DLinkedNode next;
    }

    internal class LRUCache
    {
        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        private void addNode(DLinkedNode node)
        {
            /**
             * Always add the new node right after head.
             */
            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            /**
             * Remove an existing node from the linked list.
             */
            DLinkedNode prev = node.prev;
            DLinkedNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            /**
             * Move certain node in between to the head.
             */
            removeNode(node);
            addNode(node);
        }

        private DLinkedNode popTail()
        {
            /**
             * Pop the current tail.
             */
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }



        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;

            head = new DLinkedNode();
            // head.prev = null;

            tail = new DLinkedNode();
            // tail.next = null;

            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            DLinkedNode node = cache[key];
            if (node == null) return -1;

            // move the accessed node to the head;
            moveToHead(node);

            return node.value;
        }

        public void put(int key, int value)
        {
            DLinkedNode node = cache.ContainsKey(key) ? cache[key] : null;

            if (node == null)
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                cache.Add(key, newNode);
                addNode(newNode);

                ++size;

                if (size > capacity)
                {
                    // pop the tail
                    DLinkedNode tail = popTail();
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                // update the value.
                node.value = value;
                moveToHead(node);
            }
        }
    }
}
