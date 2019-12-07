using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BTZigZag
    {

        public static void Test()
        {
            BinaryTreeNode tree = new BinaryTreeNode(1);
            tree.InsertLeft(2);
            tree.InsertRight(3);
            tree.Left.InsertLeft(7);
            tree.Left.InsertRight(6);
            tree.Right.InsertLeft(5);
            tree.Right.InsertRight(4);
            ZigZag(tree);
        }

        public static IList<IList<int>> ZigZag(BinaryTreeNode node)
        {
            var result = new List<IList<int>>();
            if (node == null)
            {
                return result;
            }
            var stack1 = new Stack<BinaryTreeNode>();
            var stack2 = new Stack<BinaryTreeNode>();

            stack1.Push(node);

            var isLeft = true;
            var runningList = new List<int>();
            while (stack1.Count > 0)
            {
                var curr = stack1.Pop();
                Console.WriteLine(curr.Value + " ");
                runningList.Add(curr.Value);
                if (isLeft)
                {
                    if (curr.Left != null)
                        stack2.Push(curr.Left);

                    if (curr.Right != null)
                        stack2.Push(curr.Right);
                }
                else
                {
                    if (curr.Right != null)
                        stack2.Push(curr.Right);

                    if (curr.Left != null)
                        stack2.Push(curr.Left);
                }

                if (stack1.Count == 0)
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
    }
}
