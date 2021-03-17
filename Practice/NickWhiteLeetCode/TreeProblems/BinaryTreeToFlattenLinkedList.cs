using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.TreeProblems
{
    public class BinaryTreeToFlattenLinkedList
    {
        public static void Test()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(6);
            Flatten(root);
        }

        public static void Flatten(TreeNode root)
        {
            //excellent - came with solution in 40 minutes by myself
            if (root == null) return;
            var dummy = new TreeNode(-1);
            var curr = dummy;
            var s1 = new Stack<TreeNode>();
            s1.Push(root);
            while (s1.Count > 0)
            {
                var temp = s1.Pop();
                curr.right = temp;
                curr.left = null;
                if (temp.right != null) s1.Push(temp.right);
                if (temp.left != null) s1.Push(temp.left);
                curr = curr.right;
            }
            root = dummy.right;
        }

        private void FlattenToList(TreeNode root)
        {
            if (root == null)
                return;

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                var current = stack.Pop();

                if (current.right != null)
                    stack.Push(current.right);

                if (current.left != null)
                    stack.Push(current.left);
               
                if (stack.Count > 0)
                    current.right = stack.Peek();
                current.left = null;
            }
        }
    }
}
