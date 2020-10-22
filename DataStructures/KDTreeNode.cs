using System;

namespace DataStructures
{
    public class KDTreeNode<TKey, TValue> where TKey : notnull, IComparable<TKey>
    {
        internal TKey[] Position { get; }

        public TValue Data { get; set; }

        public KDTreeNode<TKey, TValue> Parent { get; set; }

        public KDTreeNode<TKey, TValue> LeftNode { get; set; }

        public KDTreeNode<TKey, TValue> RightNode { get; set; }

        public KDTreeNode(TKey[] position, TValue data)
        {
            Position = position;
            Data = data;
        }

        public bool IsLeaf() => LeftNode == null && RightNode == null;

        internal void AddRecursively(KDTreeNode<TKey, TValue> newNode, int byDimension)
        {
            if (byDimension >= Position.Length)
            {
                byDimension = 0;
            }
            if (newNode.Position[byDimension].CompareTo(Position[byDimension]) <= 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = newNode;
                    newNode.Parent = this;
                }
                else
                {
                    LeftNode.AddRecursively(newNode, ++byDimension);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = newNode;
                    newNode.Parent = this;
                }
                else
                {
                    RightNode.AddRecursively(newNode, ++byDimension);
                }
            }
        }

        public override string ToString()
        {
            string parent = Parent != null ? Parent.Data.ToString() : "null";
            string left = LeftNode != null ? LeftNode.Data.ToString() : "null";
            string right = RightNode != null ? RightNode.Data.ToString() : "null";
            return $"Pos:[{string.Join(",", Position)}], Data:{Data}, Parent:{parent}, Left:{left}, Right:{right}";
        }

    }
}