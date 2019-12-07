using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BTBoundary
    {
        public static void Test()
        {
            var tree = new TreeNode(20);
            tree.left = new TreeNode(8);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(12);
            tree.left.right.left = new TreeNode(10);
            tree.left.right.right = new TreeNode(14);
            tree.right = new TreeNode(22);
            tree.right.right = new TreeNode(25);
            BoundaryOfBinaryTree(tree);
        }
        private static IList<int> BoundaryOfBinaryTree(TreeNode tree)
        {
            var list = new List<int>();
            if(tree == null)
            {
                return list;
            }
            Console.WriteLine(tree.val);
            list.Add(tree.val);
            PrintLeftBoundary(tree.left, list);
            PrintLeaves(tree.left, list);
            PrintLeaves(tree.right, list);
            PrintRightBoundary(tree.right, list);
            return list;
        }

        private static void PrintLeaves(TreeNode node, IList<int> list)
        {
            if(node == null)
            {
                return;
            }
            if(node.left == null && node.right == null)
            {
                list.Add(node.val);
                Console.WriteLine(node.val);
            }
            PrintLeaves(node.left, list);
            PrintLeaves(node.right, list);
        }

        private static void PrintRightBoundary(TreeNode node, IList<int> list)
        {
            if(node == null)
            {
                return;
            }
            if(node.right!=null)
            {
                PrintRightBoundary(node.right, list);
                Console.WriteLine(node.val);
                list.Add(node.val);
            }
            else if(node.left != null)
            {
                PrintRightBoundary(node.left, list);
                Console.WriteLine(node.val);
                list.Add(node.val);
            }
        }

        private static void PrintLeftBoundary(TreeNode node, IList<int> list)
        {
            if(node == null)
            {
                return;
            }
            if(node.left != null)
            {
                Console.WriteLine(node.val);
                list.Add(node.val);
                PrintLeftBoundary(node.left, list);
            }
            else if(node.right != null)
            {
                Console.WriteLine(node.val);
                list.Add(node.val);
                PrintLeftBoundary(node.right, list);
            }
        }
    }
  
  public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
}
