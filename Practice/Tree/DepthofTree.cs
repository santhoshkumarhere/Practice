using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    public class DepthofTree
    {
        public static void Test()
        {
            var tree = new TreeNode(3);
            tree.left = new TreeNode(9);
            tree.right = new TreeNode(20);
            tree.right.left = new TreeNode(15);
            tree.right.right = new TreeNode(7);
            var dict = new Dictionary<TreeNode, int>();
            int depth = GetHeight(tree, dict);

        }

        private static int GetHeight(TreeNode node, Dictionary<TreeNode, int> dict)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                if (dict.ContainsKey(node))
                {
                    return dict[node];
                }
                else
                {
                    dict[node] = 1 + Math.Max(GetHeight(node.left, dict), GetHeight(node.right, dict));
                    return dict[node];
                }
            }
        }

        private static int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            }
        }
    }
     
}
