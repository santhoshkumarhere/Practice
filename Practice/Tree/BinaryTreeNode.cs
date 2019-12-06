using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    public class BinaryTreeNode
    {
        public int Value { get; }

        public BinaryTreeNode Left { get; private set; }

        public BinaryTreeNode Right { get; private set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }



        private void InsertMap(int dist, int val, SortedDictionary<int, IList<int>> dict)
        {
            if (!dict.ContainsKey(dist))
            {
                dict[dist] = new List<int>();
            }
            dict[dist].Add(val);
        }

        private void PreOrder(int dist, BinaryTreeNode node, SortedDictionary<int, IList<int>> dict)
        {
            if (node == null)
            {
                return;
            }

                InsertMap(dist, node.Value, dict);
                PreOrder(dist-1, node.Left, dict);
                PreOrder(dist+1, node.Right, dict);
        }

        public IList<IList<int>> ZigZag(BinaryTreeNode node)
        {
            var result = new List<IList<int>>();
            if(node == null)
            {
                return result;
            }
            var stack1 = new Stack<BinaryTreeNode>();
            var stack2 = new Stack<BinaryTreeNode>();

            stack1.Push(node);

            var isLeft = true;
            var runningList = new List<int>();
            while(stack1.Count > 0)
            {
                var curr = stack1.Pop();
                Console.WriteLine(curr.Value + " ");
                runningList.Add(curr.Value);
                if (isLeft)
                {
                    if (curr.Left != null)
                        stack2.Push(curr.Left);
                    
                    if(curr.Right != null)
                        stack2.Push(curr.Right);
                }
                else
                {
                    if (curr.Right != null)
                        stack2.Push(curr.Right);

                    if (curr.Left != null)
                        stack2.Push(curr.Left);
                }

                if(stack1.Count == 0)
                {
                    stack1 = stack2;
                    stack2 = new Stack<BinaryTreeNode>();
                    isLeft = !isLeft;
                    result.Add(runningList);
                    runningList = new List<int>();
                }
            }
            return result;

        }

        public void VerticalTraversal(BinaryTreeNode node)
        {
            var map = new SortedDictionary<int, IList<int>>(); 
            PreOrder(0, node, map);

            foreach (var list in map.Values)
            {
               Console.WriteLine(String.Join("",list));
            }
        }
    }

    public class CheckBinaryTreeBalance
    {
        public bool IsBalanced(BinaryTreeNode currentNode)
        {
            if (currentNode == null)
            {
                return true;
            }

            var leftHeight = GetHeight(currentNode.Left);
            var rightHeight = GetHeight(currentNode.Right);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(currentNode.Left) &&
                IsBalanced(currentNode.Right))
            {
                return true;
            }

            return false;
        }

        public int GetHeight(BinaryTreeNode currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(GetHeight(currentNode.Left), GetHeight(currentNode.Right));
            }
        }

        public int CountLeafNode(BinaryTreeNode currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            else if (currentNode.Left == null && currentNode.Right == null)
            {
                return 1;
            }
            else
            {
                return CountLeafNode(currentNode.Left) + CountLeafNode(currentNode.Right);
            }
        }
    }
}
