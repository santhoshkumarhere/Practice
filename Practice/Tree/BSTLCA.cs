using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BSTLCA
    {
        public static void Test()
        {
            TreeNode tree = new TreeNode(20); 
            tree.left = new TreeNode(8);
            tree.right = new TreeNode(22);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(12);
            tree.left.right.left = new TreeNode(10);
            tree.left.right.right = new TreeNode(14);
            var lc1 = FindBSTLCA(tree, 10, 14);
            var lc = lca(tree, 10, 14);
        }

        private static TreeNode FindBSTLCA(TreeNode node, int k1, int k2)
        {
            if(node == null)
            {
                return null;
            }
            if(node.val > k1 && node.val > k2)
            {
                return FindBSTLCA(node.left, k1, k2);
            }
            else if (node.val < k1 && node.val < k2)
            {
                return FindBSTLCA(node.right, k1, k2);
            }

            return node;
        }

        private static TreeNode lca(TreeNode root, int n1, int n2)
        {
            while (root != null)
            {
                // If both n1 and n2 are smaller  
                // than root, then LCA lies in left  
                if (root.val > n1 &&
                    root.val > n2)
                    root = root.left;

                // If both n1 and n2 are greater  
                // than root, then LCA lies in right  
                else if (root.val < n1 &&
                         root.val < n2)
                    root = root.right;

                else break;
            }
            return root;
        }
    }
}
