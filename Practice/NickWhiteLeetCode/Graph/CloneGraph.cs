using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{

    public class CloneGraphs
    {
        static Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
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
            var clone = CloneGraph(node1);
        }

        private static Node CloneGraphBFS(Node node)
        {
            if (node == null) return node;

            var visited = new Dictionary<Node, Node>();
            var q = new Queue<Node>();
            q.Enqueue(node);
            visited[node] = new Node(node.val, new List<Node>());

            while(q.Count > 0)
            {
                var curr = q.Dequeue();
                foreach(var neighbor in curr.neighbors)
                {
                    if(!visited.ContainsKey(neighbor))
                    {
                        q.Enqueue(neighbor);
                        visited[neighbor] = new Node(neighbor.val, new List<Node>());
                    }
                    visited[curr].neighbors.Add(visited[neighbor]); // 2.Add(1)
                }
            }
            return visited[node];
        }

        private static Node CloneGraph(Node node)
        {
            if (node == null) return node;

            if (visited.ContainsKey(node)) return visited[node];

            Node cloneNode = new Node(node.val, new List<Node>());
            visited[node] = cloneNode;

            foreach(var n in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph(n));
            }
            return cloneNode;
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
