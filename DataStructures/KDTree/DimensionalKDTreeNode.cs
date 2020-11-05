namespace DataStructures.KDTree
{
    /// <summary>
    /// Wraps the <c>KDTreeNode</c> into an object with it's dimension.
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    class DimensionalKDTreeNode<T>
    {
        public int Dimension { get; }

        public KDTreeNode<T> Node { get; }

        /// <summary>
        /// Wraps the <paramref name="node"/> into new object with it's <paramref name="dimension"/>.
        /// </summary>
        /// <param name="dimension">Dimension of the <paramref name="node"/></param>
        /// <param name="node">Node with <paramref name="dimension"/></param>
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
