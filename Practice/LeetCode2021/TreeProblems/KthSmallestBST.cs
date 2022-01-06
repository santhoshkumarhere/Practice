using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class KthSmallestBST
    {
        public static void Test()
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right = new TreeNode(6);
            root.right.right = new TreeNode(7);
            var res = InOrder(root, 5);
        }

        public static int InOrder(TreeNode root, int k)
        {
            var curr = root;

            var stack = new Stack<TreeNode>();
    
            while(true)
            {
                while(curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                var top = stack.Pop();
                
                if (--k == 0)
                    return top.val;

                // if (top.right != null)
                    curr = top.right;
            } 
        }
    }
}
