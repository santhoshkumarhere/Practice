using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.TreeProblems
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
   }

    public class InvertBinaryTree
    {

        public static void Test()
        {
            var tree = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)), 
                new TreeNode(7, new TreeNode(6), new TreeNode(9)));
            var result = InvertTree(tree);
        }
        
        private static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;
        }
    }
}
