using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode75.Graph
{
    public class CloneGraph
    {
        private static Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node(int val, List<Node> neighbors)
            {
                this.val = val;
                this.neighbors = neighbors;
            }
        }
        public static Node Test()
        {
            var node1 = new Node(1, new List<Node>());
            var node2 = new Node(2, new List<Node>());
            var node3 = new Node(3, new List<Node>());
            var node4 = new Node(4, new List<Node>());
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);

            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);
            var result = Clone(node1);
            return result;
        }

        private static Node Clone(Node node)
        {
            if (node == null)
                return node;
            if (visited.ContainsKey(node))
                return visited[node];

            var clonedNode = new Node(node.val, new List<Node>());
            visited[node] = clonedNode;

            foreach(var neighbour in node.neighbors)
            {
                clonedNode.neighbors.Add(Clone(neighbour));
            }
            return clonedNode;
        }

    }
}

