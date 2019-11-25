using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    class ConnectedComponentGraph
    {
      // A user define class to represent a graph. 
        // A graph is an array of adjacency lists. 
        // Size of array will be V (number of vertices 
        // in graph) 
        int V;
        List<int>[] adjListArray;

        // constructor 
        ConnectedComponentGraph(int v)
        {
            this.V = v;

            // define the size of array as 
            // number of vertices 
            adjListArray = new List<int>[v];

            // Create a new list for each vertex 
            // such that adjacent nodes can be stored 

            for (int i = 0; i < v; i++)
            {
                adjListArray[i] = new List<int>();
            }
        }

        // Adds an edge to an undirected graph 
        void addEdge(int src, int dest)
        {
            // Add an edge from src to dest. 
            adjListArray[src].Add(dest);

            // Since graph is undirected, add an edge from dest 
            // to src also 
            adjListArray[dest].Add(src);
        }

        void connectedComponents()
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[V];
            for (int v = 0; v < V; v++)
            {
                if (!visited[v])
                {
                    // print all reachable vertices 
                    // from v 
                    DFS(v, visited);
                    Console.WriteLine();
                }
            }
        }

        public void DFS(int s, bool[] visited)
        {
            //var visited = new bool[V];
            Stack<int> stack = new Stack<int>();
            stack.Push(s);

            visited[s] = true;
            while (stack.Count > 0)
            {
                // Pop a vertex from stack and print it 
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

        // Driver code 
        public static void Test()
        {
            // Create a graph given in the above diagram  
            ConnectedComponentGraph g = new ConnectedComponentGraph(5); // 5 vertices numbered from 0 to 4  

            g.addEdge(1, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 4);
            Console.WriteLine("Following are connected components");
            g.connectedComponents();
            //.DFS(2);
        }


        void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited and print it 
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices 
            // adjacent to this vertex 
            foreach (int x in adjListArray[v])
            {
                if (!visited[x])
                    DFSUtil(x, visited);
            }

        }

    }
}
