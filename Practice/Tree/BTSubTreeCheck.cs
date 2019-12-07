using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BTSubTreeCheck
    {

        public static void Test()
        {
            TreeNode s = new TreeNode(3);
            s.left = new TreeNode(4);
            s.right = new TreeNode(5);
            s.left.left = new TreeNode(1);
            s.left.right = new TreeNode(2);

            TreeNode t = new TreeNode(4); 
            t.left = new TreeNode(1);
            t.right = new TreeNode(2);
;
            // var node =SearchTree(s, t.val); if no duplicates
            //var res = IsTreeEqual(node, t);

            //if duplicats
            var res =  traverse(s, t);
        }
        private static bool IsTreeEqual(TreeNode n1, TreeNode n2)
        {
            if(n1 == null && n2 == null)
            {
                return true;
            }
            if (n1 == null || n2 == null)
            {
                return false;
            }

            var childEqual =  IsTreeEqual(n1.left, n2.left) && IsTreeEqual(n1.right, n2.right);

           return n1.val == n2.val  && childEqual;
        }

        //if duplicates

        public static bool traverse(TreeNode s, TreeNode t)
        {
            return s != null && (IsTreeEqual(s, t) || traverse(s.left, t) || traverse(s.right, t));
        }

        //if no duplicates
        private static TreeNode SearchTree(TreeNode node, int val)
        {
            TreeNode right = null;
            if (node == null || node.val == val) 
           {
                return node;
           }
            
            var left = SearchTree(node.left, val);
            if (left == null)
            {
              right=  SearchTree(node.right, val);
            }
            return left ?? right;
        }

    }
}
