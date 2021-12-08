using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeMaxPathSum_H_
    {
        int max_sum = 0; 

        public void MaxPathSum(TreeNode root)
        {
            FindMaxSum(root);
            var res =  max_sum;
        }

        private int FindMaxSum(TreeNode node)
        {
            if (node == null)
                return 0;

            var leftGain = Math.Max(FindMaxSum(node.left), 0); // we dont want to take negative gains so do max with 0
            var rightGain = Math.Max(FindMaxSum(node.right), 0);

            var newPath = node.val + leftGain + rightGain;
            max_sum = Math.Max(max_sum, newPath); // current + left + right make a max  path until now

            return node.val + Math.Max(leftGain, rightGain); // only current + Max(left, right) can participate in rest of the max calculation
        }
    }
}
