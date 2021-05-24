using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class Result
    {
        public int fdepth { get; set; }
        public int result { get; set; }
    }
    public class FindBottomLeftValueInTree
    {
        //private static int fdepth = 0;
        //private static int result = 0;
        public static void Test()
        {
            var root = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            var four = new TreeNode(4);
            var five = new TreeNode(5);
            var six = new TreeNode(6);
            var seven = new TreeNode(7);


            //three.left = four;
            //root.left = two;
            //root.right = three;

            root.left = two; root.right = three;
            two.left = four;
            three.left = five; three.right = six;
            five.left = seven;

            var zero = new TreeNode(0);
            zero.left = new TreeNode(-1);

            var x = new TreeNode(1);
            x.right = new TreeNode(2);
            var res = FindBottomLeftValue(x);
            var ers1 = FindBottomLeftValue(zero);
            var ers2 = FindBottomLeftValue(root);
        }

        private static int FindBottomLeftValue(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                root = queue.Dequeue();

                if(root.right != null)
                {
                    queue.Enqueue(root.right);
                }

                if(root.left != null)
                {
                    queue.Enqueue(root.left);
                }
            }
            return root.val;
        }
    }
}
