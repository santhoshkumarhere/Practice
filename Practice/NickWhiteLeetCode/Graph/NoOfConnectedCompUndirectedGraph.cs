using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class NoOfConnectedCompUndirectedGraph
    {

        public static void Test()
        {
            var edges = new int[][]
            {
                new int[]{0, 1},
                new int[]{1, 2},
                new int[]{3, 4},
            };
            var res = CountComponents(5, edges);
        }

        private static int CountComponents(int n, int[][] edges)
        {
            int count = 0;

            int row = edges.Length;
            int col = edges[0].Length;
            var created = new Dictionary<int, Node>();
            var src = 0;
            for(int i = 0; i < row; i++)
            {
                src = 0;
                for(int j = 0; j < col; j++)
                {
                    var currVal = edges[i][j];
                    if(((i==0 & j == 0) || (i != 0 && j == 0)) )
                    {
                        src = currVal;
                        if (!created.ContainsKey(src))
                            created[src] = null;
                    }
                    else
                    {
                        if(created.ContainsKey(currVal))
                        {
                            created[src].neighbors.Add(created[currVal]);
                            created[currVal].neighbors.Add(created[src]);
                        }
                        else
                        {
                            var child = new Node(currVal, new List<Node>());
                            child.neighbors.Add(created[src]);
                            created[currVal] = child;
                            created[src].neighbors.Add(child);
                        }
                    } 
                }
            }

            return count;
        }
    }

}
