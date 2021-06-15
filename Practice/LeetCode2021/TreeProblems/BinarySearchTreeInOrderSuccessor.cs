using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.TreeProblems
{
    public class BinarySearchTreeInOrderSuccessor
    {
        public static void Test()
        {
            var root = new TreeNode(2);
            var one = new TreeNode(1);
            var three = new TreeNode(3);
            root.left = one;
            root.right = three;

            var result = InorderSuccessor(root, one);
        }

        private static TreeNode InorderSuccessorII(TreeNode root, TreeNode p)
        {
            TreeNode successor = null;
            while(root != null)
            {
                if(p.val >= root.val)
                    root = root.right;
                else
                {
                    successor = root;
                    root = root.left;
                }
            }
            return successor;
        }

            private static TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            var stack = new Stack<TreeNode>();
            var map = new Dictionary<TreeNode, TreeNode>();
            TreeNode prevAdded = null;
            var curr = root; 
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                curr = stack.Pop();
                
                if (prevAdded != null)
                {
                    map[prevAdded] = curr;
                }
               
                prevAdded = curr;
                curr = curr.right;
            }

            return map.ContainsKey(p) ? map[p] : null;
        }
    }
}
