using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    public class AllNodesDistanceK
    {

        public static void Test ()
        {
            var root = new TreeNode(0);
            var target = new TreeNode(3);
            root.left = new TreeNode(1);
            root.left.left = new TreeNode(2);
            root.left.left.left = target;
            target.left = new TreeNode(4);

            var res = DistanceK(root, target, 0);
        }

        private static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var distanceKList = new List<int>();

            var ancestor = new Dictionary<TreeNode, TreeNode>();
            DFS(ancestor, root, null);

            var queue = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();

            queue.Enqueue(target);
            visited.Add(target);
            visited.Add(null);

            var distance = 0;
            while (queue.Count > 0)
            {
                var size = queue.Count();

                if (distance == k) // to handle k = 0 we have this if condition here
                {
                    while (queue.Count > 0)
                    {
                        var node = queue.Dequeue();
                        if (node != null)
                            distanceKList.Add(node.val);
                    }
                    return distanceKList;
                }

                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();

                    if (!visited.Contains(curr.left))
                    {
                        queue.Enqueue(curr.left);
                        visited.Add(curr.left);
                    }
                    if (!visited.Contains(curr.right))
                    {
                        queue.Enqueue(curr.right);
                        visited.Add(curr.right);
                    }
                    var parent = ancestor[curr];
                    if (!visited.Contains(parent))
                    {
                        queue.Enqueue(parent);
                        visited.Add(parent);
                    }
                }
                distance++;

            }
            return distanceKList;

        }

        private static void DFS(Dictionary<TreeNode, TreeNode> ancestor, TreeNode node, TreeNode parent)
        {
            if (node == null)
                return;
            ancestor[node] = parent;
            DFS(ancestor, node.left, node);
            DFS(ancestor, node.right, node);
        }
    }
}
