using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class ValidBST
    {
        public static void Test()
        {
            var five = new TreeNode(5);
            var four = new TreeNode(4);
            var seven = new TreeNode(7);
            var three = new TreeNode(3);
            var six = new TreeNode(6);
            var one = new TreeNode(1);
            var two = new TreeNode(2);
            five.left = four; five.right = six;
            four.left = three; four.right = two;
            three.left = one;

            var res = IsValidBST(five);
        }

        private static bool IsValidBST(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
   
            TreeNode prev = null;

            while(stack.Count > 0 || root != null)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (prev != null && root.val <= prev.val)
                    return false;
                prev = root;
                root = root.right;
            }

            return true;
        }
    }
}
