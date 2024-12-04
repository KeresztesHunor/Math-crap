namespace MathCrap
{
    internal class BinaryTreeNode<T>(T value)
    {
        public T value { get; set; } = value;

        public BinaryTreeNode<T>? node1 { get; set; }
        public BinaryTreeNode<T>? node2 { get; set; }
    }
}
