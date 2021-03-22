using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        //see nick white for recursive
    }

    public class TreeMaxValueInRow
    {
        public static void Test()
        {
            var root = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            var four = new TreeNode(4);
            var five = new TreeNode(5);
            var six = new TreeNode(6);
            var seven = new TreeNode(7);

            var eight = new TreeNode(8);
            var nine = new TreeNode(9);
            var ten = new TreeNode(10);
            var eleven = new TreeNode(11);
            var twelve = new TreeNode(12);
            var thirteen = new TreeNode(13);
            var fourteen = new TreeNode(14);
            var fifteen = new TreeNode(15);
            root.left = two; root.right = three;
            two.left = four; two.right = five;
            three.left = six; three.right = seven;
            four.left = eight; four.right = nine; five.left = ten; five.right = eleven;
            six.left = twelve; six.right = thirteen; seven.left = fourteen; seven.right = fifteen;
            var res = LargestValues(root);
        }        

        public static IList<int> LargestValues(TreeNode root)
        {
            var result = new List<int>();

            if (root == null)
            {
                return result;
            }
            var s1 = new Stack<TreeNode>();
            var s2 = new Stack<TreeNode>();

            s1.Push(root);
            var temp = new List<int>();
            while (s1.Count > 0)
            {

                var curr = s1.Pop();
                temp.Add(curr.val);
                
                if(curr.left != null)
                    s2.Push(curr.left);
                if (curr.right != null)
                    s2.Push(curr.right);

                if(s1.Count == 0)
                {
                    s1 = s2;
                    s2 = new Stack<TreeNode>();
                    var maxValue = temp.Max();
                    result.Add(maxValue);
                    temp = new List<int>();
                }
            }

            return result;
        }
    }
}
