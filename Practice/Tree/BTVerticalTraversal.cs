using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree
{
    class BTVerticalTraversal
    {
        /*
               1
             /   \
            /     \
           2       3
                 /   \
                /     \
               5       6
             /   \
            /     \
           7       8
                 /   \
                /     \
               9      10
         2 7
         1 5 9
         3 8
         6 10
         */
        public static void Test()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);

            root.InsertLeft(2);
            root.InsertRight(3);
            root.Right.InsertLeft(5);
            root.Right.InsertRight(6);
            root.Right.Left.InsertLeft(7);
            root.Right.Left.InsertRight(8);
            root.Right.Left.Right.InsertLeft(9);
            root.Right.Left.Right.InsertRight(10);
            PreOrder(root);
            Console.WriteLine("");
            VerticalTraversal(root);
        }

        private static void InsertMap(int dist, int val, SortedDictionary<int, IList<int>> dict)
        {
            if (!dict.ContainsKey(dist))
            {
                dict[dist] = new List<int>();
            }
            dict[dist].Add(val);
        }

        private static void PreOrder(BinaryTreeNode currentNode)
        {
            if(currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                PreOrder(currentNode.Left);
                PreOrder(currentNode.Right);
            }
        }

        private static void PreOrder(int dist, BinaryTreeNode node, SortedDictionary<int, IList<int>> dict)
        {
            if (node == null)
            {
                return;
            }

            InsertMap(dist, node.Value, dict);
            PreOrder(dist - 1, node.Left, dict);
            PreOrder(dist + 1, node.Right, dict);
        }


        public static void VerticalTraversal(BinaryTreeNode node)
        {
            var map = new SortedDictionary<int, IList<int>>();
            PreOrder(0, node, map);

            foreach (var list in map.Values)
            {
                Console.WriteLine(String.Join(" ", list));
            }
        }
    }
}
