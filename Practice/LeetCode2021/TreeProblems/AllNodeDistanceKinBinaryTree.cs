using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    public class AllNodeDistanceKinBinaryTree
    {
        public static void Test()
        {
            var root = new TreeNode(3);
            var target = new TreeNode(5);

            root.left = target;
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);

            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);

            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);
            var res = DistanceK(root, target, 2);
        }

        private static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var list = new List<int>();
            var ancestor = new Dictionary<TreeNode, TreeNode>();
            
            DFS(ancestor, root, null);

            var queue = new Queue<TreeNode>();
            var seen = new HashSet<int>();

            queue.Enqueue(target);
            seen.Add(target.val);
            int distance = 0;
            
            while(queue.Count > 0)
            {
                var size = queue.Count();

                if (distance == k)
                {
                    while (queue.Count > 0)
                    {
                        list.Add(queue.Dequeue().val);
                    }
                    return list;
                }

                for(int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    if(!seen.Contains(curr.left.val))
                    {
                        queue.Enqueue(curr.left);
                        seen.Add(curr.left.val);
                    }
                    if(!seen.Contains(curr.right.val))
                    {
                        queue.Enqueue(curr.right);
                        seen.Add(curr.right.val);
                    }
                    var parent = ancestor[curr];
                    if (parent != null && !seen.Contains(parent.val))
                    {
                        queue.Enqueue(parent);
                        seen.Add(parent.val);
                    }
                }
                distance++;
            }

            return list;
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