using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Practice.Graph
{
    public class GraphNode
    {
        public string Label { get; }
        public ISet<GraphNode> Neighbors { get; }
        public string Color { get; set; }
        public bool HasColor { get { return Color != null; } }

        public GraphNode(string label)
        {
            Label = label;
            Neighbors = new HashSet<GraphNode>();
        }

        public void AddNeighbor(GraphNode neighbor)
        {
            Neighbors.Add(neighbor);
        }
    }

    public class TestGraphColor
    {
        public void Test()
        {
            var a = new GraphNode("a");
            var b = new GraphNode("b");
            var c = new GraphNode("c");

            a.AddNeighbor(b);
            b.AddNeighbor(a);
            b.AddNeighbor(c);
            c.AddNeighbor(b);
            var graph = new[]
            {
                a,
                b,
                c
            };
        }

        public static void ColorGraph(GraphNode[] graph, string[] colors)
        {
            foreach (var g in graph)
            {
                var illegalColors = g.Neighbors.Select(x => x.Color).ToImmutableHashSet();
                g.Color = colors.First(c => !illegalColors.Contains(c));
                
            }
        }
    }
}
