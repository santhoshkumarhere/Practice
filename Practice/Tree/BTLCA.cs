using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BTLCA
    {
        public static void Test()
        {
            TreeNode tree = new TreeNode(1); 
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(3);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(5);
            tree.right.left = new TreeNode(6);
            tree.right.right = new TreeNode(7);
            var lcaNode = FindLCA(tree, 2, 4);
            lcaNode = FindLCA(tree, 5, 4);
            lcaNode = FindLCA(tree, 3, 4);
        }

        private static TreeNode FindLCA(TreeNode node, int k1, int k2)
        {
            if(node == null)
            {
                return null;
            }
            if(node.val == k1 || node.val == k2)
            {
                return node;
            }

            var left = FindLCA(node.left, k1, k2);
            var right = FindLCA(node.right, k1, k2);

            if(left !=null && right !=null)
            {
                return node;
            }

            return left ?? right;
        }
    }
}
