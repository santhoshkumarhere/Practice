using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.GraphProblems
{
    class TopologicalSorting
    {
        public class Graph
        {
            public Dictionary<string, IList<string>> Adj = new Dictionary<string, IList<string>>();
            public void AddEdge(string source, IList<string> adj)
            {
                this.Adj[source] = adj;
            }
        }

        static void TopologicalSortUtil(Stack<string> stack, Dictionary<string, bool> visited, string key, Graph g)
        {
            visited[key] = true;
            if(g.Adj.ContainsKey(key)) //some values may not be in dictionary - example 'G' in the test case
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

        public static void TopologicalSort(Graph g)
        {
            var stack = new Stack<string>();
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
            var g = new Graph();
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
