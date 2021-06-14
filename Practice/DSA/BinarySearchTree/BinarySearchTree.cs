using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DSA.BinarySearchTree
{
    public class BinarySearchTree
    {

        public static void Test()
        {
            var bst = new BinarySearchTree();
            bst.Insert(3);
            bst.Insert(5);
            bst.Insert(2);
            bst.Insert(4);
            bst.Insert(10);
            bst.Insert(1);
            bst.PrintBST();
            Console.WriteLine();
            bst.PrintLevelOrder();
            Console.WriteLine();
            bst.Search(5);
            Console.WriteLine();
            bst.Delete(5);
        }


        private Node root;

        private class Node
        {
            public readonly int val;
            public Node left;
            public Node right;

            public Node(int val)
            {
                this.val = val;
            }
        }

        public void Insert(int val)
        {
            this.root = Insert(this.root, val);
        }

        public void Search(int val)
        {
            var node = Search(this.root, val);
            if (node != null)
            {
                Console.Write($"{node.val} {node?.left?.val} {node?.right?.val} ");
            }
        }

        public void Delete(int val)
        {
            this.Delete(this.root, val);
            this.PrintLevelOrder();
        }

        private Node Insert(Node root, int val)
        {
            if (root == null)
            {
                return new Node(val);
            }

            if (root.val > val)
            {
                root.left = Insert(root.left, val);
            } 
            else
            {
                root.right = Insert(root.right, val);
            }
            return root;
        }

        private Node Delete(Node root, int val)
        {
            if(root == null)
            {
                return root;
            }

            if(root.val > val)
            {
                root.left = Delete(root.left, val);
            }
            else if(root.val < val)
            {
                root.right = Delete(root.right, val);
            }
            else
            {
                if (root.left == null && root.right == null)
                    return null; // no child
                else if (root.left == null || root.right == null)
                    return root.left ?? root.right; //one child
                else {
                    //Two child - Replace current node with the inorder successor node and delete Inorder successor node
                    var successor = new Node(FindMinimum(root.right));
                    successor.left = root.left;
                    successor.right = Delete(root.right, successor.val);
                    root = successor;
                    return root;
                }
            }
            return root;
        }

        private int FindMinimum(Node root)
        {
            int minVal = root.val;
            while(root.left != null)
            {
                minVal = root.left.val;
                root = root.left;
            }
            return minVal;
        }

        private Node Search(Node root, int val)
        {
            if (root == null || root.val == val)
                return root;

            if(root.val > val)
                return Search(root.left, val);
            else
                return Search(root.right, val);
        }

        public void PrintBST()
        {
            var curr = this.root;
            var stack = new Stack<Node>();
            while (curr != null || stack.Count > 0)
            {
                while(curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                
                curr = stack.Pop();
                
                Console.Write($"{curr.val} ");

                curr = curr.right;
            }
        }

        public void PrintLevelOrder()
        {
            var queue = new Queue<Node>();

            var curr = this.root;

            queue.Enqueue(curr);
            while(queue.Count > 0)
            {
                curr = queue.Dequeue();
                Console.Write($"{curr.val} ");
                if (curr.left != null) 
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
        }
    }
}
