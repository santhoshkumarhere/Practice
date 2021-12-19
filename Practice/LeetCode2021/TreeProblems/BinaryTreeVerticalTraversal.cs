using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    internal class BinaryTreeVerticalTraversal
    {
        public static void Test()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var res = VerticalTraversal(root);
        }

        private static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var q = new Queue<(TreeNode, int)>();

            var map = new SortedDictionary<int, IList<int>>();

            q.Enqueue((root, 0));
            AddToList(map, 0, root.val);

            while(q.Count > 0)
            {
                var curr = q.Dequeue();

                if (curr.Item1.left != null)
                {
                    q.Enqueue((curr.Item1.left, curr.Item2 - 1));
                    AddToList(map, curr.Item2 - 1, curr.Item1.left.val);
                }

                if (curr.Item1.right != null)
                {
                    q.Enqueue((curr.Item1.right, curr.Item2 + 1));
                    AddToList(map, curr.Item2 + 1, curr.Item1.right.val);
                }
            }
            return map.Values.ToList();
        }

        private static void AddToList(SortedDictionary<int, IList<int>> result, int index, int value)
        {
            if (!result.ContainsKey(index))
            {
                result[index] = new List<int>();
            }
            result[index].Add(value);            
        }
    }
}
