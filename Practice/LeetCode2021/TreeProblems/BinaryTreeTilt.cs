using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
   public class BinaryTreeTilt
    {
        private int tilt = 0;
        public int FindTilt(TreeNode root)
        {
            this.GetSum(root);
            return tilt;
        }

        private int GetSum(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftSum = GetSum(node.left);
            int rightSum = GetSum(node.right);
            tilt += Math.Abs(leftSum - rightSum);

            return node.val + leftSum + rightSum;
        }
    }
}
