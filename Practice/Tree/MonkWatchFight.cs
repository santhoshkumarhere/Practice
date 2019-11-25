using System;

namespace Practice.Tree
{
    class MonkWatchFight
    {
        private Node root;

        private Node AddRecursively(Node currentNode, int value)
        {
            if (currentNode == null)
            {
                return new Node(value);
            }

            if (value <= currentNode.data)
            {
                currentNode.Left = AddRecursively(currentNode.Left, value);
            }
            else if (value > currentNode.data)
            {
                currentNode.Right = AddRecursively(currentNode.Right, value);
            }

            return currentNode;
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

        public int FindHeight()
        {
            return GetHeight(this.root);
        }

        public void Add(int value)
        {
            this.root = this.AddRecursively(this.root, value);
        }

        static void Main(string[] args)
        {
            var arrayLength = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[arrayLength];

            var input = Console.ReadLine();
            var inputArray = input?.Split(' ');

            if (input != null && arrayLength > 0 && inputArray.Length == arrayLength)
            {
                for (int i = 0; i < arrayLength; i++)
                {
                    arr[i] = Convert.ToInt32(inputArray[i]);
                }
            }

            // Console.Write(string.Join(" ", arr));

            var bst = new MonkWatchFight();

            foreach (var i in arr)
            {
                bst.Add(i);
            }

            Console.WriteLine(bst.FindHeight());
            Console.ReadLine();
        }

        private class Node
        {
            public readonly int data;
            public Node Left { get; set; }
            public Node Right { get; set; }

            internal Node(int data)
            {
                this.data = data;
            }
        }

    }
}
