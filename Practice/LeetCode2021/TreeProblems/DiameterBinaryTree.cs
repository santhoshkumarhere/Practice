using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    class DiameterBinaryTree
    {
        private int diameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            LengthOfTree(root);
            return diameter;
        }

        private int LengthOfTree(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftTreeLength = LengthOfTree(root.left);
            int rightTreeLength = LengthOfTree(root.right);
            diameter = Math.Max(diameter, leftTreeLength + rightTreeLength); // do not add 1 + here for root. because it was already added in return statement during recursion

            return 1 + Math.Max(leftTreeLength, rightTreeLength);
            
        }
    }
}
