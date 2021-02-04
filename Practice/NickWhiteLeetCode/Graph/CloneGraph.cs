using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{

    public class CloneGraph
    {
        public static void Test()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            node1.neighbors.Add(node2); node1.neighbors.Add(node4);
            node2.neighbors.Add(node1); node2.neighbors.Add(node3);
            node3.neighbors.Add(node2); node3.neighbors.Add(node4);
            node4.neighbors.Add(node1); node4.neighbors.Add(node3);
            var clone = CloneGraphs(node1);
        }

        private static Node CloneGraphs(Node node)
        {
            if (node == null) return node;

            var node2 = new Node(node.val);
            var list = new List<int>();

            var q1 = new Queue<Node>();
            var q2 = new Queue<Node>();
            var temp = new Dictionary<int, Node>();
            q1.Enqueue(node);
            q2.Enqueue(node2);

            while(q1.Count > 0)
            {                
                var c1 = q1.Dequeue();
                var c2 = q2.Dequeue();

                list.Add(c1.val);
                foreach (var n in c1.neighbors)
                {
                    if (!list.Contains(n.val))
                    {
                        q1.Enqueue(n);
                    }
                    Node newNode = null;
                    if(temp.ContainsKey(n.val))
                    {
                        newNode = temp[n.val];
                    }
                    else
                    {
                        newNode = new Node(n.val);
                        temp[n.val] = newNode;
                    }
                    c2.neighbors.Add(newNode);
                    q2.Enqueue(newNode);                    
                }
            }

            return node2;
        }
    }

    internal class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
