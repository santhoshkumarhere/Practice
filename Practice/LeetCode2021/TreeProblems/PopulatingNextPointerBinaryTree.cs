using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class PopulatingNextPointerBinaryTree
    {

        public static void Test()
        {

        }

        public TreeNode Connect(TreeNode root)
        {
            if (root == null)
                return root;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {

                var size = q.Count;
                TreeNode prev = null;
                for (int i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();
                    if (curr.right != null)
                    {
                        curr.right.next = prev;
                        prev = curr.right;
                        q.Enqueue(curr.right);
                    }
                    if (curr.left != null)
                    {
                        curr.left.next = prev;
                        prev = curr.left;
                        q.Enqueue(curr.left);
                    }
                }
            }
            return root;
        }
    }
}
