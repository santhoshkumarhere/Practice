using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BinaryTreeLCA
    {
        public static void Test() {
            var one = new TreeNode(1);
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

            one.left = two;
            two.left = four;
            two.right = five;
            four.left = eight;
            four.right = nine;
            five.left = ten;
            five.right = eleven;
            var ans = LowestCommonAncestor(one, nine, eleven);
        }

        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var stack = new Stack<TreeNode>();

            var parent = new Dictionary<TreeNode, TreeNode>();

            parent[root] = null;
            stack.Push(root);

            while(!parent.ContainsKey(p) || !parent.ContainsKey(q))
            {
                var curr = stack.Pop();

                if(curr.left != null)
                {
                    stack.Push(curr.left);
                    parent[curr.left] = curr;
                }

                if(curr.right != null)
                {
                    stack.Push(curr.right);
                    parent[curr.right] = curr;
                }
            }

            var ancestor = new HashSet<TreeNode>();

            while(p != null)
            {
                ancestor.Add(p);
                p = parent[p];
            }

            while(!ancestor.Contains(q))
            {
                q = parent[q];
            }
            return q;
        }
    }
}
