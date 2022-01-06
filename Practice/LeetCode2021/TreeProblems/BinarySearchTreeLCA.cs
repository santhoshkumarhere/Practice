using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    internal class BinarySearchTreeLCA
    {

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return root;

            var pVal = p.val;
            var qVal = q.val;
            var parent = root.val;

            if (pVal < parent && qVal < parent)
                return LowestCommonAncestor(root.left, p, q);
            else if (pVal > parent && qVal > parent)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;
        }
    }
}
