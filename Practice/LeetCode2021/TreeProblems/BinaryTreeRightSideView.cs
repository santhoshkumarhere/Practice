using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeRightSideView
    {
        public static void Test()
        {
            var root1 = new TreeNode(1);
            root1.left = new TreeNode(2);
            root1.right = new TreeNode(3);
            root1.right.left = new TreeNode(4);
            root1.right.left.right = new TreeNode(5);

            var res = RightSideView(root1);

            var root2 = new TreeNode(1);
            root2.left = new TreeNode(2);
            root2.left.right = new TreeNode(3);
            root2.left.right.left = new TreeNode(4);
            var res2 = RightSideView(root2);


            var root3 = new TreeNode(1);
            root3.left = new TreeNode(2);
            root3.right = new TreeNode(3);
            root3.left.left = new TreeNode(4);
            var res3 = RightSideView(root3);
        }

        private static IList<int> RightSideViewNick(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                var size = q.Count;

                for( int i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();
                    if (i == 0) result.Add(curr.val);
                    if (curr.right != null) q.Enqueue(curr.right);
                    if (curr.left != null) q.Enqueue(curr.left);
                }
            }

            return result;
        }
        
        private static IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            result.Add(root.val);
            while (q.Count > 0)
            {
                var size = q.Count;
                var isAdded = false;
                for(var i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();
                    if (curr.right != null)
                    {
                        q.Enqueue(curr.right);
                        if (!isAdded)
                        {
                            result.Add(curr.right.val);
                            isAdded = true;
                        }
                    }
                    if(curr.left != null)
                    {
                        q.Enqueue(curr.left);
                        if (!isAdded)
                        {
                            result.Add(curr.left.val);
                            isAdded = true;
                        }
                    }
                }
               
            }
            return result;
        }

        public IList<int> RightSideViewMyCode(TreeNode root)
        {
            var result = new List<int>();

            if (root == null) return result;

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            result.Add(root.val);
            while (queue.Count > 0)
            {
                var size = queue.Count;

                for (var i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();

                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                }

                if (queue.Count > 0)
                    result.Add(queue.Last().val);
            }

            return result;
        }
    }
}
