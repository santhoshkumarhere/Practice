
using System.Collections.Generic;

namespace Practice.Tree.TreeProblems
{
    public class BinaryTreePathSum
    {
        // this problem is similar to depth of a tree

        private bool CheckHasPathSum(TreeNode root, int sum)
        {
            return HasPathSum(root, sum);
        }

        private bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return root.val == sum;
            }

            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        private bool HasPathSumIterative(TreeNode root, int sum)
        {
            if (root == null) return false;

            var sumStack = new Stack<int>();
            var nodeStack = new Stack<TreeNode>();

            nodeStack.Push(root);
            sumStack.Push(sum - root.val);

            // This is nothing but a pre-order travesal
            while(nodeStack.Count > 0)
            {
                var curr = nodeStack.Pop();
                var currSum = sumStack.Pop();

                if (curr.left == null && curr.right == null && currSum == 0) return true;

                if (curr.right != null)
                {
                    nodeStack.Push(curr.right);
                    sumStack.Push(currSum - curr.right.val);
                }

                if (curr.left != null)
                {
                    nodeStack.Push(curr.left);
                    sumStack.Push(currSum - curr.left.val);
                }
            }
            return false;
        }
    }
}
