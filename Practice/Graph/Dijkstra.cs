using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    internal class Node
    {
        public string Label;
        public int Distance { get; set; }
        public LinkedList<Edge> Edges;

        public Node(string label)
        {
            Label = label;
        }

        public void AddEdge(Edge e)
        {
            if (this.Edges == null)
            {
                this.Edges = new LinkedList<Edge>();
            }

            this.Edges.AddLast(e);
        }
    }

    internal class Edge
    {
        public int Weight;
        public Node Destination;

        public Edge(int weight)
        {
            Weight = weight;
        }

        public void AddDestination(Node n)
        {
            this.Destination = n;
        }
    }
    internal class Dijkstra
    {

        public static void BFS(Node a, Dictionary<string, int> dict)
        {
            var q = new Queue<Node>();
            var parent = new Dictionary<Node, bool>(); 

            q.Enqueue(a);
          
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr.Edges == null)
                {
                    break;
                }

                foreach (var e in curr.Edges)
                {
                    if (!parent.ContainsKey(e.Destination))
                    {
                        if (dict.ContainsKey(e.Destination.Label))
                        {
                            var temp = dict[e.Destination.Label];
                            dict.Remove(e.Destination.Label);
                            dict.Add(e.Destination.Label, Math.Min(temp, dict[curr.Label] + e.Weight));
                        }
                        else
                        {
                            dict.Add(e.Destination.Label, Math.Min(dict[e.Destination.Label], dict[curr.Label] + e.Weight));
                        }
                        q.Enqueue(e.Destination);
                    }
                }

                parent.Add(curr, true);
            }
        }

        public static void Test()
        {
            var a = new Node("a");
            var b = new Node("b");
            var c = new Node("c");
            var d = new Node("d");

            var ab = new Edge(2);
            ab.AddDestination(b);
            a.AddEdge(ab);

            var ac = new Edge(7);
            ac.AddDestination(c);
            a.AddEdge(ac);

            var bc = new Edge(1);
            bc.AddDestination(c);
            b.AddEdge(bc);

            var cd = new Edge(1);
            cd.AddDestination(d);
            c.AddEdge(cd);

            var ad = new Edge(1);
            ad.AddDestination(d);
            a.AddEdge(ad);

            var dict = new Dictionary<string, int>();
            dict.Add(a.Label, 0);
            dict.Add(b.Label, int.MaxValue);
            dict.Add(c.Label, int.MaxValue);
            dict.Add(d.Label, int.MaxValue);
            BFS(a, dict);
        }
    }

}
