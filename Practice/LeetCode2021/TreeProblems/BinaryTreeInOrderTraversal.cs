using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeInOrderTraversal
    {
        public static void Test()
        {
            var tree = new TreeNode(1);
            tree.right = new TreeNode(2);
            tree.right.left = new TreeNode(3);

            var res = InorderTraversal(tree);
        }

        private static IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>();
            var curr = root;

            var stack = new Stack<TreeNode>();
            var result = new List<int>();
            while(curr != null || stack.Count > 0)
            {
                while(curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                var top = stack.Pop();

                result.Add(top.val);

                if (top.right != null)
                    curr = top.right;
            }

            return result;
        }
    }
}
