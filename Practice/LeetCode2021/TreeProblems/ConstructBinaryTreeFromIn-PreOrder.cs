using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class ConstructBinaryTreeFromIn_PreOrder
    {
        static int preOrderIndex = 0;
        public static void Test()
        {
            var preOrder = new int[] { 3, 9, 20, 15, 7};
            var inOrder = new int[] { 9, 3, 15, 20, 7}; //inorder root splits right and left - see value 3

            var result = BuildTree(preOrder, inOrder);
        }

        private static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < inorder.Length; i++)
            {
                map[inorder[i]] = i;
            }
            return BuildTree(preorder, inorder, map, 0, preorder.Length - 1);
        }

        private static TreeNode BuildTree(int[] preorder, int[] inorder, Dictionary<int, int> map, int left, int right)
        {
            if (left > right)
                return null;

            var rootValues = preorder[preOrderIndex++]; // increment preOrder array pointer
            var rootInOrderIndex = map[rootValues]; // index of root

            TreeNode root = new TreeNode(rootValues);
            root.left = BuildTree(preorder, inorder, map, left, rootInOrderIndex - 1); //see construct BT from an array geeks
            root.right = BuildTree(preorder, inorder, map, rootInOrderIndex + 1, right);

            return root;
        }
    }
}


