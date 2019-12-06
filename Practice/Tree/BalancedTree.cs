using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    public class BalancedTree
    {
        public static void Test()
        {
            var tree = new TreeNode(3);
            tree.left = new TreeNode(9);
            tree.right = new TreeNode(20);
            tree.right.left = new TreeNode(15);
            tree.right.right = new TreeNode(7);
            tree.right.right.right = new TreeNode(17);
            var isBalanced = IsBalanced(tree);
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

        private static bool IsBalanced(TreeNode node)
        {
            if (node == null)
            {
                return true;
            }

            var leftHeight = GetHeight(node.left);
            var rightHeight = GetHeight(node.right);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(node.left) && IsBalanced(node.right))
            {
                return true;
            }

            return false;
        }
    }
     
}
