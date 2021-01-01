using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BinaryTreeMaximumWidth
    {
        public static void Test()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(5);
            root.left.left.left = new TreeNode(1);
            root.right.right = new TreeNode(6);
            root.right.right.right = new TreeNode(7);
            var res = WidthOfBinaryTree(root);
        }

        private static int WidthOfBinaryTree(TreeNode root)
        {
            var ans = 0;
            if (root == null)
                return ans;

            var q = new Queue<TreeNode>();
            root.val = 1;
            ans = 1;
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var size = q.Count;

                ans = Math.Max(ans, q.Last().val + 1 - q.Peek().val);
                for(var i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();

                    if (curr.left != null)
                    {
                        curr.left.val = curr.val * 2;
                        q.Enqueue(curr.left);
                    }

                    if(curr.right != null)
                    {
                        curr.right.val = curr.val * 2 + 1;
                        q.Enqueue(curr.right);
                    }
                }
            }
            return ans;
        }

    }
}
