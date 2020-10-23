namespace DataStructures
{
    class DimensionalKDTreeNode<T>
    {
        public int Dimension { get; }

        public KDTreeNode<T> Node { get; }

        public DimensionalKDTreeNode(int dimension, KDTreeNode<T> node)
        {
            Dimension = dimension;
            Node = node;
        }

    }
}
