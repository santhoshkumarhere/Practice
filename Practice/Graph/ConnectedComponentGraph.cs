using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    class ConnectedComponentGraph
    {
        int V;
        List<int>[] adjListArray;

        ConnectedComponentGraph(int v)
        {
            this.V = v;
            adjListArray = new List<int>[v];

            for (int i = 0; i < v; i++)
            {
                adjListArray[i] = new List<int>();
            }
        }

        void addEdge(int src, int dest)
        {
            adjListArray[src].Add(dest);
            adjListArray[dest].Add(src);
        }

        void connectedComponents()
        {
            bool[] visited = new bool[V];
            for (int v = 0; v < V; v++)
            {
                if (!visited[v])
                {
                   DFSUtil(v, visited);  // DFS(v, visited);
                   Console.WriteLine();
                }
            }
        }

        void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");
            foreach (int x in adjListArray[v])
            {
                if (!visited[x])
                    DFSUtil(x, visited);
            }
        }
        
        public static void Test()
        {
            var g = new ConnectedComponentGraph(5); // 5 vertices numbered from 0 to 4  
            g.addEdge(1, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 4);
            Console.WriteLine("Following are connected components");
            g.connectedComponents();            
        }
        
        public void DFS(int s, bool[] visited)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(s);

            visited[s] = true;
            while (stack.Count > 0)
            {
                s = stack.Peek();
                stack.Pop();
                Console.Write(s + " ");

                foreach (var l in adjListArray[s])
                {
                    if (!visited[l])
                    {
                        visited[l] = true;
                        stack.Push(l);
                    }
                }
            }
        }
    }
}
