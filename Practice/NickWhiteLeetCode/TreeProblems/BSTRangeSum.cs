using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BSTRangeSum
    {
        public static void Test()
        {

        }

        private static int RangeSumBST(TreeNode root, int low, int high)
        {
            var ans = 0;
            var stack = new Stack<TreeNode>();

            if (root == null) return ans;
            stack.Push(root);

            while(stack.Count > 0)
            {
                root = stack.Pop();
                if(root.val >= low && root.val <= high)
                {
                    ans += root.val;
                }

                if(root.val > low && root.left != null)
                {
                    stack.Push(root.left);
                }
                if(root.val < high && root.right != null)
                {
                   stack.Push(root.right);
                }
            }
            return ans;
        }
    }
}
