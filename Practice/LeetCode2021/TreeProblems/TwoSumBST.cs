using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class TwoSumBST
    {
        public static void Test()
        {
            var root1 = new TreeNode(5);
            root1.left = new TreeNode(3);
            root1.right = new TreeNode(7);
            root1.right.left = new TreeNode(6);
            root1.right.right = new TreeNode(9);

            var root2= new TreeNode(5);
            root2.left = new TreeNode(0);
            root2.right = new TreeNode(6);
            root2.right.right = new TreeNode(7);

            var res = TwoSumBSTs(root1, root2, 10);
        }

        private static bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
        {
            var stack = new Stack<TreeNode>();
            var set = new HashSet<int>();
            // First inorder traversal and compute complement
            // Second inorder traversal and find if  complement exists
            while(stack.Count > 0 || root1 != null)
            {
                while(root1 != null)
                {
                    stack.Push(root1);
                    root1 = root1.left;
                }

                root1 = stack.Pop();
                set.Add(target - root1.val);

                root1 = root1.right;
            }

            while(stack.Count > 0 || root2 != null)
            {
                while(root2 != null)
                {
                    stack.Push(root2);
                    root2 = root2.left;
                }

                root2 = stack.Pop();
                if (set.Contains(root2.val))
                    return true;
                root2 = root2.right;
            }
            return false;
        }

    }
}
