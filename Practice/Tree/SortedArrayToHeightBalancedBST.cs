using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class SortedArrayToHeightBalancedBST
    {

        public static void Test()
        {
            var result = SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
        }

        private static TreeNode SortedArrayToBST(int[] nums)
        {
            return Helper(0, nums.Length - 1, nums);
        }

        private static TreeNode Helper(int left, int right, int[] nums)
        {
            if (left > right)
                return null;

            var p = (left + right) / 2;

            var tree = new TreeNode(nums[p]);
            tree.left = Helper(left, p - 1, nums);
            tree.right = Helper(p + 1, right, nums);
            return tree;
        }
    }
}
