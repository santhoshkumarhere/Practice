using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Practice.Graph
{

    public class Graph
    {
        private readonly int v;
        private readonly LinkedList<int>[] list;

        public Graph(int ver)
        {
            list = new LinkedList<int>[ver];
            this.v = ver;
            for (var i = 0; i < v; i++)
            {
                list[i] = new LinkedList<int>();
            }
        }

        public void Add(int src, int des)
        {
            this.list[src].AddLast(des);
           // this.list[des].AddLast(src);
        }

        public void Print()
        {
            for (var i = 0; i < this.v; i++)
            {

                Console.WriteLine("Adjacency list of vertex " + i);
                Console.Write("head"); 
                foreach(var l in this.list[i])
                {
                    Console.Write(" -> " + l);
                }
                Console.WriteLine("\n");
            }
        }

        public void BFS(int s)
        { 
            var q = new Queue<int>();
            var visited = new bool[v];
            if (list != null)
            { 
                q.Enqueue(s);
                visited[s] = true;
                while (q.Count > 0)
                {
                    s = q.Dequeue();
                    Console.WriteLine(s);
                    foreach (var l in list[s])
                    {
                        if (!visited[l])
                        {
                           visited[l] = true;
                            q.Enqueue(l);
                        }
                    }
                }
            }
        }

        public void TT(int value)
        {
            var visited = new bool[v];
            var q = new Queue<int>();

            q.Enqueue(value);

            while (q.Count > 0)
            {
                var x = q.Dequeue();
                Console.WriteLine(x);

                foreach (var l in list[x])
                {
                    if (!visited[l])
                    {
                        visited[l] = true;
                        q.Enqueue(l);
                    }
                }

            }
        }

        public void DFS(int s)
        {
            var visited = new bool[v];
            Stack<int> stack = new Stack<int>();
            stack.Push(s);

            visited[s] = true;
            while (stack.Count > 0)
            {
                // Pop a vertex from stack and print it 
                s = stack.Peek();
                stack.Pop();
                Console.WriteLine(s);

                foreach (var l in list[s])
                {
                    if (!visited[l])
                    {
                        visited[l] = true;
                        stack.Push(l);
                    }
                }
            }
        }


        //static void TestGraph()
        //{

        //    Graph.Graph graph = new Graph.Graph(4);
        //    graph.Add(0, 1);
        //    graph.Add(0, 2);
        //    graph.Add(1, 2);
        //    graph.Add(2, 0);
        //    graph.Add(2, 3);
        //    graph.Add(3, 3);
        //    graph.BFS(2);
        //    graph.DFS(2);
        //}
    }
}
