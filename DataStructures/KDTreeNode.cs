using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace DataStructures
{
    class KDTreeNode<T>
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

        public override string ToString()
        {
            return $"Data:{DataToStr(this)}, Parent:{DataToStr(Parent)}, Left:{DataToStr(LeftChild)}, Right:{DataToStr(RightChild)}";

            string DataToStr(KDTreeNode<T> node)
            {
                return node != null
                    ? (node.Data != null ? node.Data.ToString() : "NULL")
                    : "null";
            }
        }

    }
}