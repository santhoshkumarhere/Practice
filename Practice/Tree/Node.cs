namespace Practice.Tree
{
    internal class Node
    {
        public readonly int data;
        public Node Left { get; set; }
        public Node Right { get; set; }

        internal Node(int data) => this.data = data;
    }
}
