using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BSTSearch_E_
    {
        public static void Test()
        {
            var root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right = new TreeNode(7);
                           

            var res = SearchBSTIterative(root, 2);
        }

        private static TreeNode SearchBSTIterative(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr.val == val) 
                    return curr;

                if (val < curr.val && curr.left != null)
                {
                    q.Enqueue(curr.left);
                }
                else if(curr.right != null)
                {
                    q.Enqueue(curr.right);
                }
            }
            return null;
        }

        private static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)  return root;
            
            if (val < root.val)
               return  SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }
    }
}
