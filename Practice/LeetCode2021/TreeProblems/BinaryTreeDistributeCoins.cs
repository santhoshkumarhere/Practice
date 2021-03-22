using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeDistributeCoins
    {
        int moves = 0;
        private int DistributeCoins(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            int left = DistributeCoins(root.left);
            int right = DistributeCoins(root.right);
            moves += Math.Abs(left) + Math.Abs(right);
            return root.val + left + right - 1;

        }
    }
}
