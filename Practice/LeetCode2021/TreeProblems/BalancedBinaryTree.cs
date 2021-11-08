using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BalancedBinaryTree
    {

        public bool IsBalanced(TreeNode root)
        {
            return FindDepth(root) != -1;
        }

        private int FindDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = FindDepth(root.left);
            int rightDepth = FindDepth(root.right);

            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1)
                return -1;
            return 1 + Math.Max(leftDepth, rightDepth);
        }

    }
}
