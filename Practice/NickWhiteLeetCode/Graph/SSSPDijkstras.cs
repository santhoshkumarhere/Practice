using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class SSSPDijkstras
    {

        public static void Test()
        {
            // M * N
            int[,] graph = new int[,] { { 0, 4, 0, 25},
                                        { 0, 0, 8, 0},
                                        { 0, 0, 0, 7}};
            FindShortestPath(graph, 0);

            graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            							{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            							{ 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            FindShortestPath(graph, 0);
        }

        private static void FindShortestPath(int[,] graph, int src)
        {
            var row = graph.GetLength(0);
            var col = graph.GetLength(1);

            var list = new List<Tracker>();
            for(var i = 0; i < col; i++)
            {
                list.Add(new Tracker(i, i == 0 ? src : int.MaxValue, false)); //only starting vertex should have minimum distance, rest should be infinity
            }

            for(var k = 0; k < row; k++)
            {
                // find unvisited vertex with minimum distance from list
                var u = list.Where(x => x.Visited == false).Aggregate((i1, i2) => i1.Distance < i2.Distance ? i1 : i2).Vertex;
                list[u].Visited = true;

                for(var v = 0; v < col && u < row; v++)
                {
                    if(graph[u, v] != 0) //valid path must exists
                    {
                        list[v].Distance = Math.Min(list[v].Distance, list[u].Distance + graph[u, v]); //Current GraphValue + SourceValue from List
                    }
                }
            }
            Print(list);
        }

        static void Print(IList<Tracker> list)
        {
            Console.WriteLine("Vertex\t\tDistance");
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].Vertex}\t\t{list[i].Distance}");
            }
        }

        class Tracker
        {
            public int Distance { get; set; }
            public int Vertex { get; set; }
            public bool Visited { get; set; }

            public Tracker(int vertex, int distance, bool visited)
            {
                this.Vertex = vertex;
                this.Visited = visited;
                this.Distance = distance;
            }
        }
    }
}
