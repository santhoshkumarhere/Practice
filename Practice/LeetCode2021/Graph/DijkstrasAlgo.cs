using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Graph
{
    internal class DijkstrasAlgo
    {

        public static void Test()
        {
            int V = 9;
            //IList<IList<AdjListNode>> graph = new List<IList<AdjListNode>>();
            
            Dictionary<int, List<AdjListNode>> graph = new Dictionary<int, List<AdjListNode>>();

            for (int i = 0; i < V; i++)
            {
                graph[i] = new List<AdjListNode>();
            }
            int source = 0;
            //graph[0].Add(new AdjListNode(1, 4));
            //graph[0].Add(new AdjListNode(7, 8));
            //graph[1].Add(new AdjListNode(2, 8));
            //graph[1].Add(new AdjListNode(7, 11));
            //graph[1].Add(new AdjListNode(0, 7));
            //graph[2].Add(new AdjListNode(1, 8));
            //graph[2].Add(new AdjListNode(3, 7));
            //graph[2].Add(new AdjListNode(8, 2));
            //graph[2].Add(new AdjListNode(5, 4));
            //graph[3].Add(new AdjListNode(2, 7));
            //graph[3].Add(new AdjListNode(4, 9));
            //graph[3].Add(new AdjListNode(5, 14));
            //graph[4].Add(new AdjListNode(3, 9));
            //graph[4].Add(new AdjListNode(5, 10));
            //graph[5].Add(new AdjListNode(4, 10));
            //graph[5].Add(new AdjListNode(6, 2));
            //graph[6].Add(new AdjListNode(5, 2));
            //graph[6].Add(new AdjListNode(7, 1));
            //graph[6].Add(new AdjListNode(8, 6));
            //graph[7].Add(new AdjListNode(0, 8));
            //graph[7].Add(new AdjListNode(1, 11));
            //graph[7].Add(new AdjListNode(6, 1));
            //graph[7].Add(new AdjListNode(8, 7));
            //graph[8].Add(new AdjListNode(2, 2));
            //graph[8].Add(new AdjListNode(6, 6));
            //graph[8].Add(new AdjListNode(7, 1));

            graph[0].Add(new AdjListNode(1, 2));
            graph[0].Add(new AdjListNode(2, 5));
            graph[0].Add(new AdjListNode(3, 10));
            graph[1].Add(new AdjListNode(2, 2));
            graph[2].Add(new AdjListNode(3, 3));

            int[] distance = Dijkstra(V, graph, source);
            // Printing the Output
           Console.WriteLine("Vertex  "
                               + "  Distance from Source");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine(i + "             "
                                   + distance[i]);
            }
        }

        public static int[] Dijkstra(int V, Dictionary<int, List<AdjListNode>> graph, int source)
        {
            int[] distance = new int[V];
            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
            }
            
            distance[source] = 0;
            
            // vertex, distance
            var pq = new PriorityQueue<AdjListNode, int>();
            pq.Enqueue(new AdjListNode(source, 0), 0);

            while (pq.Count > 0)
            {
                AdjListNode parent = pq.Dequeue();

                foreach (AdjListNode child in  graph[parent.Vertex])
                {
                    var currentDistance = distance[parent.Vertex] + child.Weight; // 0 -> (1, 4) (v, d) 0 ->  1 takes distance of 4
                    if (currentDistance < distance[child.Vertex])
                    {
                        distance[child.Vertex] = currentDistance;
                        pq.Enqueue(new AdjListNode(child.Vertex, distance[child.Vertex]), distance[child.Vertex]);
                    }
                }
            }
            // If you want to calculate distance from source to
            // a particular target, you can return
            // distance[target]
            return distance;
        }
    }

    internal class AdjListNode
    {

        public AdjListNode(int v, int w)
        {
            Vertex = v;
            Weight = w;
        }

        public readonly int Vertex;
        public readonly int Weight;
    }
}
