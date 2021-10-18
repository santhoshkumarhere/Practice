using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeMinimumDepth
    {

        public int MinDepthRecursive(TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int min_depth = int.MaxValue;

            if (root.left != null)
            {
                min_depth = Math.Min(MinDepthRecursive(root.left), min_depth);
            }
            if (root.right != null)
            {
                min_depth = Math.Min(MinDepthRecursive(root.right), min_depth);
            }

            return 1 + min_depth;
        }
 
        
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var minDep = int.MaxValue;

            var nodeStack = new Stack<TreeNode>();
            var depthStack = new Stack<int>();

            nodeStack.Push(root);
            depthStack.Push(1);

            while (nodeStack.Count > 0)
            {
                var curr = nodeStack.Pop();
                var currDepth = depthStack.Pop();

                if (curr.left == null && curr.right == null)
                    minDep = Math.Min(minDep, currDepth);

                if (curr.right != null)
                {
                    nodeStack.Push(curr.right);
                    depthStack.Push(currDepth + 1);
                }


                if (curr.left != null)
                {
                    nodeStack.Push(curr.left);
                    depthStack.Push(currDepth + 1);
                }
            }

            return minDep;
        }
    }
}
