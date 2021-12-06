using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    public class HouseRobberIII
    {
        public static void Test()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(1);
            var ans = Rob(root);
            var res = Math.Max(ans.CurrentRob, ans.PrevRob);
        }

        private static int[] RobV1(TreeNode node)
        {
            if (node == null)
                return new int[] { 0, 0 };

            var left = RobV1(node.left);    //// 3
            var right = RobV1(node.right);   //2   1

            var rob = node.val + left[1] + right[1];
            var norob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new int[] { rob, norob };
        }

        private static RobHelper Rob(TreeNode node)
        {
            var stack = new Stack<(TreeNode, int[])>();
            stack.Push((node, new[] { node.val, 0 }));
            var c = stack.Pop();
            var x = c.Item1;
            var y = c.Item2;

            if (node == null)
                return new RobHelper(0, 0);

            var left = Rob(node.left);
            var right = Rob(node.right);

            //if robbing current node then cannot rob its children
            var rob = node.val + left.PrevRob + right.PrevRob;

            // if decided not to rob current node, then take sum of Max(left rob/norob) and Max(right rob/norob)
            var noRob = Math.Max(left.PrevRob, left.CurrentRob) + Math.Max(right.PrevRob, right.CurrentRob);

            return new RobHelper(rob, noRob);
        }
    }

    internal class RobHelper
    {
        public readonly int CurrentRob;
        public readonly int PrevRob;

        public RobHelper(int currentRob, int prevRob)
        {
            this.CurrentRob = currentRob;
            this.PrevRob = prevRob;
        }
    }
}
