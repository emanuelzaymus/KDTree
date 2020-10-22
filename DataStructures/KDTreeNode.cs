namespace DataStructures
{
    public class KDTreeNode<T>
    {
        public T Data { get; set; }

        public KDTreeNode<T> Parent { get; set; }

        public KDTreeNode<T> LeftNode { get; set; } // LeftChild

        public KDTreeNode<T> RightNode { get; set; } // RightChild

        public KDTreeNode(T data)
        {
            Data = data;
        }

        public bool IsLeaf() => LeftNode == null && RightNode == null;

        public bool HasOneChild() =>
            LeftNode != null && RightNode == null ||
            LeftNode == null && RightNode != null;

        //public bool HasBothChildren() => LeftNode != null && RightNode != null;

        //public bool IsLeftChild()
        //{
        //}

        //public bool IsRigthChild()
        //{
        //}

        public override string ToString()
        {
            string parent = Parent != null ? Parent.Data.ToString() : "null";
            string left = LeftNode != null ? LeftNode.Data.ToString() : "null";
            string right = RightNode != null ? RightNode.Data.ToString() : "null";
            return $"Data:{Data}, Parent:{parent}, Left:{left}, Right:{right}";
        }

    }
}