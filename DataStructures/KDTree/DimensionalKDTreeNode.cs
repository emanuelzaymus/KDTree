namespace DataStructures.KDTree
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

        public override string ToString()
        {
            return $"Dimension:{Dimension}, Node:({Node})";
        }

    }
}
