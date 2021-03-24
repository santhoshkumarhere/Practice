using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BinaryTreeCompleteness
    {

        public static void Test()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            var res = IsCompleteTree(root);
        }

        private static bool IsCompleteTree(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            bool isEnd = false;

            while(q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr == null)
                {
                    isEnd = true;
                }
                else
                {
                    if (isEnd) return false;
                    q.Enqueue(curr.left);
                    q.Enqueue(curr.right);
                }
            }
            return true;
        } 
    }
}
