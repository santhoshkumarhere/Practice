using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Practice.Tree
{
    class BinarySearchTree
    {
        public Node root;

        private Node AddRecursively(Node currentNode, int data)
        {
            if (currentNode == null)
            {
                return new Node(data);
            }
            else if (data < currentNode.data)
            {
                currentNode.Left = AddRecursively(currentNode.Left, data);
            }
            else
            {
                currentNode.Right = AddRecursively(currentNode.Right, data);
            }

            return currentNode;
        }


        public void Add(int data)
        {
            this.root = AddRecursively(this.root, data);
        }

        public Node Max()
        {
            return FindMaximum(this.root);
        }

        public Node Min()
        {
            return this.FindMinimum(this.root);
        }

        public Node GetNode(int value)
        {
            return this.Search(this.root, value);
        }

        public Node Predecessor(int value)
        {
            return this.FindPredecessor(this.root, null, value);
        }

        public Node Successor(int value)
        {
            return this.FindSuccessor(this.root, null, value);
        }

        public void DeleteNode(int value)
        {
            this.root = this.DeleteNode(this.root, value);
        }
        
        private Node Search(Node node, int value)
        {
            if (node == null || node.data == value)
            {
                return node;
            }
            else if (value < node.data)
            {
                return Search(node.Left, value);
            }
            else
            {
                return Search(node.Right, value);
            }
        }

        private Node FindMinimum(Node currentNode)
        {
            if (currentNode == null || currentNode.Left == null)
            {
                return currentNode;
            }
            else
            {
                return FindMinimum(currentNode.Left);
            }
        }

        private Node FindMaximum(Node currentNode)
        {
            if (currentNode == null || currentNode.Right == null)
            {
                return currentNode;
            }
            else
            {
                return FindMaximum(currentNode.Right);
            }
        }

        public void PreOrderTraverse(Node currentNode)
        {
            if (currentNode != null)
            {
                Console.Write(" " + currentNode.data);
                PreOrderTraverse(currentNode.Left);
                PreOrderTraverse(currentNode.Right);
            }
        }

        public void InOrderTraverse(Node currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraverse(currentNode.Left);
                Console.Write(" " + currentNode.data);
                InOrderTraverse(currentNode.Right);
            }
        }

        public void PostOrderTraverse(Node currentNode)
        {
            if (currentNode != null)
            {
                PostOrderTraverse(currentNode.Left);
                PostOrderTraverse(currentNode.Right);
                Console.Write(" " + currentNode.data);
            }
        }

        public void LevelOrder()
        {
            this.LevelOrder(this.root);
        }

        private void LevelOrder(Node rootNode)
        {
            if (rootNode != null)
            {
                var queue = new Queue<Node>();
                Node currentNode = rootNode;
                queue.Enqueue(rootNode);

                while (queue.Count > 0)
                {
                    currentNode = queue.Dequeue();
                    Console.Write(" " + currentNode.data);
                    if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)  queue.Enqueue(currentNode.Right);
                }
            }
        }

        private Node FindSuccessor(Node currentNode, Node successor, int value)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.data ==  value)
            {
                if (currentNode.Right != null)
                {
                    return this.FindMinimum(currentNode.Right);

                }
            }
            else if(value < currentNode.data)
            {
                successor = currentNode;
                return this.FindSuccessor(currentNode.Left, successor, value);
            }
            else if(value > currentNode.data)
            {
                return this.FindSuccessor(currentNode.Right, successor, value);
            }

            return successor;
        }

        private Node FindPredecessor(Node currentNode, Node predecessor, int value)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.data == value)
            {
                if (currentNode.Left != null)
                {
                    return this.FindMaximum(currentNode.Left);
                }
            }
            else if(value < currentNode.data)
            {
                return FindPredecessor(currentNode.Left, predecessor, value);
            }
            else if(value > currentNode.data)
            {
                predecessor = currentNode;
                return FindPredecessor(currentNode.Right, predecessor, value);
            }
            
            return predecessor;
        }

        private int GetHeight(Node currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            int leftHeight = GetHeight(currentNode.Left);
            int rightHeight = GetHeight(currentNode.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int Height()
        {
            return this.GetHeight(this.root);
        }

        private Node DeleteNode(Node currentNode, int data)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (data < currentNode.data)
            {
                currentNode.Left = DeleteNode(currentNode.Left, data);
            }
            else if (data > currentNode.data)
            {
                currentNode.Right = DeleteNode(currentNode.Right, data);
            }
            else
            {
                if (currentNode.Left == null && currentNode.Right == null)
                {
                    return null;
                }
                else if (currentNode.Left == null || currentNode.Right == null)
                {
                    var newNode = currentNode.Left ?? currentNode.Right;
                    currentNode = newNode;
                    return currentNode;
                }
                else
                {
                    var successor = new Node(FindMinimum(currentNode.Right).data); //new Node is very important
                    successor.Left = currentNode.Left;
                    successor.Right = DeleteNode(currentNode.Right, successor.data);
                    currentNode = successor;
                    return currentNode;
                }
            }

            return currentNode;
        }
    }
}
