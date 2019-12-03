using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.GraphProblems
{
    class GraphNode
    {
        public Dictionary<string, IList<string>> Adj = new Dictionary<string, IList<string>>();
        public int Size => Adj.Count;
        public void AddNode(string node)
        {
            Adj.Add(node, null);           
        }

        public void AddEdge(string source, IList<string> adj)
        {
            this.Adj[source] = adj;
        }

        static void TopologicalSortUtil(Stack<string> stack, Dictionary<string, bool> visited, string key, GraphNode g)
        {
            visited[key] = true;
            if(g.Adj[key] != null)
            {
                foreach(var adj in g.Adj[key])
                {
                    if(!visited.ContainsKey(adj))
                    {
                        TopologicalSortUtil(stack, visited, adj, g);
                    }
                }

            }

            stack.Push(key);

        }

        public static void TopologicalSort(GraphNode g)
        {
            var stack = new Stack<String>();
            var visited = new Dictionary<string, bool>();
            foreach(var key in g.Adj.Keys)
            {
                if(!visited.ContainsKey(key))
                TopologicalSortUtil(stack, visited, key, g);
            }

            while (stack.Count > 0)
            {
                var x = stack.Pop();
                Console.WriteLine(x + " ");
            }
        }

        public static void Test()
        {
            var g = new GraphNode();
            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("C");
            g.AddNode("D");
            g.AddNode("E");
            g.AddNode("F");
            g.AddNode("G");
            g.AddNode("H");
            
            g.AddEdge("A", new List<string>() { "C" });
            g.AddEdge("B", new List<string>() { "C", "D" });
            g.AddEdge("C", new List<string>() { "E" });
            g.AddEdge("D", new List<string>() { "F" });
            g.AddEdge("E", new List<string>() { "F", "H" });
            g.AddEdge("F", new List<string>() { "G" }); 
            TopologicalSort(g);
        }
    }
}
