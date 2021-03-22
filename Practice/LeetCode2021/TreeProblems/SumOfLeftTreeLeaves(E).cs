using Practice.LeetCode2021.TreeProblems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class SumOfLeftTreeLeaves_E_
    {
        public static void Test()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var result = SumOfLeftLeavesIterative(root);
        }

        private static int SumOfLeftLeavesIterative(TreeNode root)
        {
            if (root == null)
                return 0;

            var sumOfLeftLeaves = 0;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                if(node.left != null)
                {
                    if(node.left.left == null && node.left.right == null)
                    {
                        sumOfLeftLeaves += node.left.val;
                    }
                    else
                    {
                        stack.Push(node.left);
                    }
                }
                if(node.right != null)
                {
                    if(node.right.left != null || node.right.right != null)
                    {
                        stack.Push(node.right);
                    }
                }
            }
            return sumOfLeftLeaves;

        }

        private static int SumOfLeftLeaves(TreeNode root) // write down the input for easy visualization of solution
        {
            if (root == null)
                return 0;

            var sumOfLeftLeaves = 0;

            if(root.left != null)
            {
                if(root.left.left ==null && root.left.right ==null)
                {
                    sumOfLeftLeaves += root.left.val;
                }
                else
                {
                    sumOfLeftLeaves += SumOfLeftLeaves(root.left);
                }
            }
            if(root.right != null)
            {
                if(root.right.left != null || root.right.right != null)
                {
                    sumOfLeftLeaves += SumOfLeftLeaves(root.right);
                }
            }
            return sumOfLeftLeaves;
        }
    }
}
