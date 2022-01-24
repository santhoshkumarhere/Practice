using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LRUImpl
    {
        public static void Test() {
            var lru = new LRU(3);
            lru.Put(1, 1);
            lru.Put(2, 2);
            lru.Get(1);
            lru.Put(3, 3);
            lru.Put(4, 4);
         }
    }

    internal class DLinkNode
    {
        public int Key;
        public int Value;
        public DLinkNode Prev;
        public DLinkNode Next;
    }

    internal class LRU
    {
        private int _capacity;

        private int _size;

        private DLinkNode _head;

        private DLinkNode _tail;

        private Dictionary<int, DLinkNode> _cache = new Dictionary<int, DLinkNode>();

        public LRU(int capacity)
        {
            this._capacity = capacity;
            _head = new DLinkNode();
            _tail = new DLinkNode();
            _head.Next = _tail;
        }

        private void AddNode(DLinkNode newNode)
        {
            newNode.Prev = _head;
            newNode.Next = _head.Next;
            _head.Next.Prev = newNode;
            _head.Next = newNode;
        }

        private void RemoveNode(DLinkNode node)
        {
            DLinkNode prev = node.Prev;
            DLinkNode next = node.Next;

            prev.Next = next;
            next.Prev = prev;
        }

        private void MoveToHead(DLinkNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
                return -1;
            else
            {
                var node = _cache[key];
                MoveToHead(node);
                return node.Value;
            }
        }


        public void Put(int key, int value)
        {
            DLinkNode node = null;

            if (_cache.ContainsKey(key))
                node = _cache[key];

            if (node == null)
            {
                var newNode = new DLinkNode { Key = key, Value = value };
                _cache[key] = newNode;
                AddNode(newNode);
                _size++;

                if(_size > _capacity)
                {
                    var lastNode = _tail.Prev;
                    RemoveNode(lastNode);
                    _cache.Remove(lastNode.Key);
                    _size--;
                }
            }
            else
            {
                node.Value = value;
                MoveToHead(node);
            }
        }
    }
}
