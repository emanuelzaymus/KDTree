namespace DataStructures
{
    public class KDTreeNode<T>
    {
        public T Data { get; set; }

        public KDTreeNode<T> Parent { get; set; }

        public KDTreeNode<T> LeftChild { get; set; }

        public KDTreeNode<T> RightChild { get; set; }

        public KDTreeNode(T data)
        {
            Data = data;
        }

        public bool IsLeaf() => !HasLeftChild() && !HasRightChild();

        public bool HasLeftChild() => LeftChild != null;

        public bool HasRightChild() => RightChild != null;

        public bool HasOneChild() =>
            HasLeftChild() && !HasRightChild() ||
            !HasLeftChild() && HasRightChild();

        public bool HasBothChildren() => HasLeftChild() && HasRightChild();

        public bool IsLeftChild()
        {
            if (Parent == null)
            {
                return false;
            }
            return Parent.LeftChild == this;
        }

        public bool IsRigthChild()
        {
            if (Parent == null)
            {
                return false;
            }
            return Parent.RightChild == this;
        }

        public bool IsRoot() => Parent == null;

        public override string ToString()
        {
            string parent = Parent != null ? Parent.Data.ToString() : "null";
            string left = LeftChild != null ? LeftChild.Data.ToString() : "null";
            string right = RightChild != null ? RightChild.Data.ToString() : "null";
            return $"Data:{Data}, Parent:{parent}, Left:{left}, Right:{right}";
        }

    }
}