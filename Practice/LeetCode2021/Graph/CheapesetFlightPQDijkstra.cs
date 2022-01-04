using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Graph
{
    internal class CheapesetFlightPQDijkstra
    {

        public void Test()
        {
           var result = findCheapestPrice(3, new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } },
                 0, 2, 1);
        }

        public int findCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {

            // Build the adjacency matrix
            int[][] adjMatrix = new int[n][];

            for(int i = 0; i < n; i++)
            {
                adjMatrix[i] = new int[n];
            }

            foreach (int[] flight in  flights)
            { 
                adjMatrix[flight[0]][flight[1]] = flight[2]; 
            }

            // Shortest distances array
            int[] distances = new int[n];

            // Shortest steps array
            int[] currentStops = new int[n];
            Array.Fill(distances, int.MaxValue);
            Array.Fill(currentStops, int.MaxValue);
            distances[src] = 0;
            currentStops[src] = 0;

            // The priority queue would contain (node, cost, stops), cost

            var minHeap = new PriorityQueue<int[], int>();
            minHeap.Enqueue(new int[] { src, 0, 0 }, 0);

            while (minHeap.Count > 0)
            {

                int[] info = minHeap.Dequeue();
                int node = info[0], cost = info[1], stops = info[2];

                // If destination is reached, return the cost to get here
                if (node == dst)
                {
                    return cost;
                }

                // If there are no more steps left, continue 
                if (stops == K + 1)
                {
                    continue;
                }

                // Examine and relax all neighboring edges if possible 
                for (int nei = 0; nei < n; nei++)
                {
                    if (adjMatrix[node][nei] > 0)
                    {
                        int dU = cost, dV = distances[nei], wUV = adjMatrix[node][nei];

                        // Better cost?
                        if (dU + wUV < dV)
                        {
                            minHeap.Enqueue(new int[] { nei, dU + wUV, stops + 1 }, dU + wUV);
                            distances[nei] = dU + wUV;
                        }
                        else if (stops < currentStops[nei])
                        {
                            // Better steps?
                            minHeap.Enqueue(new int[] { nei, dU + wUV, stops + 1 }, dU + wUV);
                        }
                        currentStops[nei] = stops;
                    }
                }
            }

            return distances[dst] == int.MaxValue ? -1 : distances[dst];
        }

        private class DecreaseKey<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
