using System;
using System.Collections.Generic;
using System.Text;


namespace Practice.LeetCode2021.TreeProblems
{
    public class BinaryTreeZigZagTravel
    {
        public static IList<IList<int>> ZigZag(TreeNode node)
        {
            var result = new List<IList<int>>();
            if (node == null)
            {
                return result;
            }

            var q = new Queue<TreeNode>();
            q.Enqueue(node);
            var isLeft = true;

            while (q.Count > 0)
            {
                var size = q.Count;
                var list = new LinkedList<int>();
                for (var i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();

                    if (isLeft)
                    {
                        list.AddLast(curr.val);
                    }
                    else
                    {
                        list.AddFirst(curr.val);
                    }
                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);
                }
                var currentChild = new List<int>(list);
                result.Add(currentChild);
                isLeft = !isLeft;
            }

            return result;
        }
    }
}
