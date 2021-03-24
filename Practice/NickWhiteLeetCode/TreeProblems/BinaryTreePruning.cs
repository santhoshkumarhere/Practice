using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.TreeProblems
{
    public class BinaryTreePruning
    {
        public static void Test()
        {
            var root = new TreeNode(1);
            var two = new TreeNode(0);
            var three = new TreeNode(1); 

            root.left = two;
            root.right = three;

            two.left = new TreeNode(0);
            two.right = new TreeNode(0);

            three.left = new TreeNode(0);
            three.right = new TreeNode(1);

            var res = PruneTree(root);
        }

        private static TreeNode PruneTree(TreeNode root)
        {
            if (root == null) return null;
            if (!ContainsOne(root)) root = null; //important
            return root;
        }

        private static bool ContainsOne(TreeNode root)
        {
            if(root == null)
            {
                return false;
            }

            var leftContainsOne = ContainsOne(root.left);
            var rightContainsOne = ContainsOne(root.right);

            if (!leftContainsOne) root.left = null;
            if (!rightContainsOne) root.right = null;

            return root.val == 1 || leftContainsOne || rightContainsOne;
        }
    }

}
