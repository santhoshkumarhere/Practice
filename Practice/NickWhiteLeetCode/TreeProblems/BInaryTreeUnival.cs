using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BInaryTreeUnival
    {

        public bool IsUnivalTree(TreeNode root)
        {
            return IsUnivalTree(root, root.val);
        }

        private static bool IsUniv(TreeNode root)
        {
            bool left = root.left == null || root.val == root.left.val && IsUniv(root.left);
            bool right = root.right == null || root.val == root.right.val && IsUniv(root.right);

            return left && right;
        }
        private static bool IsUnivalTree(TreeNode root, int val)
        {
            if (root == null)
            {
                return true;
            }
            var isLeftUniv = IsUnivalTree(root.left, val);
            var isRightUnit = IsUnivalTree(root.right, val);

            return root.val == val && isLeftUniv && isRightUnit;
        }
    }
}
