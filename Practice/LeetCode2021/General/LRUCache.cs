using System.Collections.Generic;

namespace Practice.LeetCode2021
{
    public class TestLRUCache
    {
        public static void Test()
        {
            var lru = new LRUCache(3);
            lru.Put(1, 1);
            lru.Put(2, 2);
            lru.Get(1);
            lru.Put(3, 3);
            lru.Put(4, 4);
        }
    }
    class DLinkedNode
    {
        public int Key;
        public int Value;
        public DLinkedNode Prev;
        public DLinkedNode Next;
    }

    internal class LRUCache
    {
        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        private void AddNode(DLinkedNode node)
        {
            // add new one, next to head
            node.Prev = head;
            node.Next = head.Next;

            head.Next.Prev = node;
            head.Next = node;
        }

        private static void RemoveNode(DLinkedNode node)
        {
            DLinkedNode prev = node.Prev;
            DLinkedNode next = node.Next;

            prev.Next = next;
            next.Prev = prev;
        }

        private void MoveToHead(DLinkedNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        private DLinkedNode PopTail()
        {
            DLinkedNode res = tail.Prev;
            RemoveNode(res);
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

            head.Next = tail;
            tail.Prev = head;
        }

        public int Get(int key)
        {
            DLinkedNode node = cache[key];
            if (node == null) return -1;

            // move the accessed node to the head;
            MoveToHead(node);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            DLinkedNode node = cache.ContainsKey(key) ? cache[key] : null;

            if (node == null)
            {
                var newNode = new DLinkedNode
                {
                    Key = key,
                    Value = value
                };

                cache.Add(key, newNode);
                AddNode(newNode);

                ++size;

                if (size <= capacity) return;

                // pop the tail
                var popTail = PopTail();
                cache.Remove(popTail.Key);
                --size;
            }
            else
            {
                // update the value.
                node.Value = value;
                MoveToHead(node);
            }
        }
    }
}
