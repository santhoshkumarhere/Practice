using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.GraphProblems
{
    class ShortestPathWeightedMatrixDijkstras
	{ 
		static void printSolution(List<DistanceTracker> dist)
		{
			Console.Write("Vertex \t\t Distance from Source\n");
			foreach(var d in dist)
			{
				Console.WriteLine($"{d.Vertex} \t\t {d.Distance}");
			}
		}

		static void dijkstra(int[,] graph, int src)
		{
			int row = graph.GetLength(0);
			int col = graph.GetLength(1);

			List<DistanceTracker> dict = new List<DistanceTracker>();

			for (int i = 0; i < col; i++)
			{
				dict.Add(new DistanceTracker(i, false, i == 0 ? src : int.MaxValue));
			}

			for (int count = 0; count < row; count++)
			{
				int u = dict.Where(x => x.Processed == false).Aggregate((i1, i2) => i1.Distance < i2.Distance ? i1 : i2).Vertex;
				dict[u].Processed = true;

				for (int v = 0; v < col; v++)
				{
					if (u < row && graph[u, v] != 0) //make sure it works for M*N matrix, it always works for M*M
					{
						dict[v].Distance = Math.Min(dict[v].Distance, dict[u].Distance + graph[u, v]);
					}
				}
			}
			printSolution(dict);
		}

		public static void Test()
		{
			// M * N
			int[,] graph = new int[,] { { 0, 4, 0, 25},
										{ 0, 0, 8, 0},
										{ 0, 0, 0, 7}};
			  dijkstra(graph, 0);
            // M * M
             graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
										{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
										{ 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            dijkstra(graph, 0);
		}

		class DistanceTracker
		{
			public int Vertex;
			public bool Processed { get; set; }
			public int Distance { get; set; }

			public DistanceTracker(int vertex, bool processed, int distance)
			{
				Vertex = vertex;
				Processed = processed;
				Distance = distance;					 
			}
		}
	} 
}



//if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
//	dist[v] = dist[u] + graph[u, v];