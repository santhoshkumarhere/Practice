using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Practice.Tree.AVL
{
    class AVLTree
    {
        private Node root;

        private int Height(Node currentNode)
        {
            return currentNode?.Height ?? 0;
        }

        private int GetHeight(Node currentNode)
        {
            if (currentNode.Left == null && currentNode.Right == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(currentNode?.Left), Height(currentNode?.Right));
        }

        private int GetBalance(Node currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            var leftHeight = currentNode.Left?.Height ?? -1;
            var rightHeight = currentNode.Right?.Height ?? -1;
            return leftHeight - rightHeight;
        }

        private Node Insert(Node currentNode, int data)
        {
            if (currentNode == null)
            {
                return new Node(data);
            }
            else if (data < currentNode.data)
            {
                currentNode.Left = Insert(currentNode.Left, data);
            }
            else if(data > currentNode.data)
            {
                currentNode.Right = Insert(currentNode.Right, data);
            }

            currentNode.Height = GetHeight(currentNode);
            return BalanceTree(currentNode, data);
        }

        private Node BalanceTree(Node currentNode, int data)
        {
            int balance = GetBalance(currentNode);
            if (balance > 1 && data < currentNode.Left.data)
            {
                return RightRotate(currentNode);
            }

            if (balance > 1 && data > currentNode.Left.data)
            {
                currentNode.Left = LeftRotate(currentNode.Left);
                return RightRotate(currentNode);
            }

            if (balance < -1 && data > currentNode.Right.data)
            {
                return LeftRotate(currentNode);
            }

            if (balance < -1 && data < currentNode.Right.data)
            {
                currentNode.Right = RightRotate(currentNode.Right);
                return LeftRotate(currentNode);
            }
            return currentNode;
        }

        private Node FindMinimum(Node currentNode)
        {
            if (currentNode?.Left == null)
            {
                return currentNode;
            }
            else
            {
                return FindMinimum(currentNode.Left);
            }
        }

        private Node Successor(Node currentNode, Node successor, int data)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.data == data && currentNode.Right != null)
            {
                return this.FindMinimum(currentNode.Right);
            }
            else if(data < currentNode.data)
            {
                successor = currentNode;
                return this.Successor(currentNode.Left, successor, data);
            }
            else
            {
                return this.Successor(currentNode.Right, successor, data);
            }
        }

        public void DeleteNode(int data)
        {
            this.root = DeleteNode(this.root, data);
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
            else if(data > currentNode.data)
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
                    var successor = this.Successor(currentNode, null, data);
                    successor.Left = currentNode.Left;
                    successor.Right = DeleteNode(currentNode.Right, successor.data);
                    currentNode = successor;
                    return currentNode;
                }

            }

            currentNode.Height = GetHeight(currentNode);

            int balance = GetBalance(currentNode);

            //Left Left case
            if (balance > 1 && GetBalance(currentNode.Left) >= 0)
                return RightRotate(currentNode);

            // Left Right Case  
            if (balance > 1 && GetBalance(currentNode.Left) < 0)
            {
                currentNode.Left = LeftRotate(currentNode.Left);
                return RightRotate(currentNode);
            }

            // Right Right Case  
            if (balance < -1 && GetBalance(currentNode.Right) <= 0)
                return LeftRotate(currentNode);

            // Right Left Case  
            if (balance < -1 && GetBalance(currentNode.Right) > 0)
            {
                currentNode.Right = RightRotate(currentNode.Right);
                return LeftRotate(currentNode);
            }

            return currentNode;
        }
        

        private Node RightRotate(Node currentNode)
        {
            Node newRoot = currentNode.Left;
            currentNode.Left = newRoot.Right;
            newRoot.Right = currentNode;
            currentNode.Height = GetHeight(currentNode);
            newRoot.Height = GetHeight(newRoot);
            return newRoot;
        }

        private Node LeftRotate(Node currentNode)
        {
            Node newRoot = currentNode.Right;
            currentNode.Right = newRoot.Left;
            newRoot.Left = currentNode;

            currentNode.Height = GetHeight(currentNode);
            newRoot.Height = GetHeight(newRoot);
            return newRoot;
        }


        public void Add(int data)
        {
            this.root = this.Insert(this.root, data);
        }

        private void PreOrder(Node currentNode)
        {
            if (currentNode != null)
            {
                Console.Write(currentNode.data + $"({currentNode.Height}) ");
                PreOrder(currentNode.Left);
                PreOrder(currentNode.Right);
            }
        }

        public void PreOrder()
        {
            this.PreOrder(this.root);
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
                    if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                }
            }
        }

    }

    class Node
    {
        public readonly int data;

        public Node(int data)
        {
            this.data = data;
        }

        public int Height { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
