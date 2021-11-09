using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class IsSameTree_E_
    {

        public static void Test()
        {
            var p = new TreeNode(1);


            var q = new TreeNode(1);
            q.right = new TreeNode(3);

            var res = IsSameTreeIterative(p, q);
        }

        private static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        private static bool IsSameTreeIterative(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (!IsSame(p, q))
                return false;

            var q1 = new Queue<TreeNode>();
            var q2 = new Queue<TreeNode>();

            q1.Enqueue(p);
            q2.Enqueue(q);

            while(q1.Count > 0)
            {
                p = q1.Dequeue();
                q = q2.Dequeue();

                if (!IsSame(p, q)) return false;

                if (p.left != null || q.left != null)
                {
                    q1.Enqueue(p.left);
                    q2.Enqueue(q.left);
                }

                if (p.right != null || q.right != null)
                {
                    q1.Enqueue(p.right);
                    q2.Enqueue(q.right);
                }               
            }

            return true;
        }

        private static bool IsSame(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;
            return true;
        }
    }
}