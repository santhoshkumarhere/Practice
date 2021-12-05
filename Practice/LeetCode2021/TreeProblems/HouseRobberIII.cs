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

        private static RobHelper Rob(TreeNode node)
        {
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
