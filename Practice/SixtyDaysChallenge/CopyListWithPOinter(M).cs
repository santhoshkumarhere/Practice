using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class CopyListWithPOinter_M_
    {
        public static Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        public static void Test()
        {
            var node = new Node(7);
            var node13 = new Node(13);
            var node11 = new Node(11);
            var node10 = new Node(10);
            var node1 = new Node(1);

            node.next = node13;
            node13.next = node11; node13.random = node;
            node11.next = node10;node11.random = node1;
            node10.next = node1;node10.random = node11;
           var res = CopyRandomList(node);
        }

        private static Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            var curr = head;
            var clone = new Node(curr.val);
            visited[curr] = clone;
            while (curr != null)
            {
                clone.next = GetClonedNode(curr.next);
                clone.random = GetClonedNode(curr.random);

                curr = curr.next;
                clone = clone.next;
            }

            return visited[head];
         }

        private static Node GetClonedNode(Node oldNode)
        {
            if(oldNode != null)
            {
                if(visited.ContainsKey(oldNode))
                {
                    return visited[oldNode];
                }
                else
                {
                    visited[oldNode] = new Node(oldNode.val);
                    return visited[oldNode];
                }
            }
            return null;
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

}
