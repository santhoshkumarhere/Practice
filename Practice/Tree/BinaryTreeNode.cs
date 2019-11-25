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
