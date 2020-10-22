using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class KDTree<TKey, TValue> where TKey : notnull, IComparable<TKey>
    {
        public int NumberOfDimensions { get; }

        private KDTreeNode<TKey, TValue> _root;

        public KDTree(int numberOfDimensions)
        {
            NumberOfDimensions = numberOfDimensions;
        }

        //public KDTree(Dictionary<TKey[], TValue> values)
        //{
        //    if (values == null)
        //        throw new ArgumentNullException(nameof(values));

        //    if (values.Count <= 0)
        //        throw new ArgumentException("Empty dictionary - cannot initialize NumberOfDimensions.", nameof(values));

        //    NumberOfDimensions = values.First().Key.Length;

        //    for (int i = 0; i < NumberOfDimensions; i++)
        //    {
        //        //var median = GetMedian(values.ToList(), i);
        //        //-----
        //        //var sortedByIthDimen = values.OrderBy(x => x.Key[i]).ToList();
        //        //var medianIndex = values.Count / 2;

        //        //Add(sortedByIthDimen[medianIndex].Value, sortedByIthDimen[medianIndex].Key);
        //    }
        //}

        //private KeyValuePair<TKey[], TValue> GetMedian(List<KeyValuePair<TKey[], TValue>> values, int byDimension)
        //{
        //    var medianPos = values.Count / 2;
        //    Sort(ref values, medianPos, byDimension);
        //    return values[medianPos];
        //}

        //private void Sort(ref List<KeyValuePair<TKey[], TValue>> values, int upTo, int byDimension)
        //{
        //    if (values.Count <= 1)
        //        return;

        //    int i = 1;
        //    while (true)
        //    {
        //        if (i > upTo)
        //        {

        //        }
        //    }
        //}

        public void AddRecursively(TValue data, params TKey[] position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position));

            if (position.Length != NumberOfDimensions)
                throw new ArgumentException(nameof(position), $"Wrong number of dimensions in parameter {nameof(position)}.");

            var newNode = new KDTreeNode<TKey, TValue>(position, data);
            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                _root.AddRecursively(newNode, 0);
            }
        }

        public void Add(TValue data, params TKey[] position)
        {
            CheckPosition(position);

            var newNode = new KDTreeNode<TKey, TValue>(position, data);

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            int byDimension = 0;
            var node = _root;

            while (true)
            {
                if (byDimension >= node.Position.Length)
                {
                    byDimension = 0;
                }
                if (newNode.Position[byDimension].CompareTo(node.Position[byDimension]) <= 0)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = newNode;
                        newNode.Parent = node;
                        return;
                    }
                    else node = node.LeftNode;
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = newNode;
                        newNode.Parent = node;
                        return;
                    }
                    else node = node.RightNode;
                }
                byDimension++;
            }
        }

        public TValue this[params TKey[] position]
        {
            get
            {
                var node = GetNode(position);
                if (node != null)
                {
                    return node.Data;
                }
                throw new KeyNotFoundException($"Key '[{string.Join(",", position)}]' was not present in the KDTree.");
            }
            set
            {
                var node = GetNode(position);
                if (node != null)
                {
                    node.Data = value;
                }
                throw new KeyNotFoundException($"Key '[{string.Join(",", position)}]' was not present in the KDTree.");
            }
        }

        private KDTreeNode<TKey, TValue> GetNode(TKey[] position)
        {
            CheckPosition(position);

            var node = _root;
            int byDimension = 0;

            while (true)
            {
                if (node == null) break;

                if (position.SequenceEqual(node.Position))
                {
                    return node;
                }
                if (byDimension >= node.Position.Length)
                {
                    byDimension = 0;
                }
                if (position[byDimension].CompareTo(node.Position[byDimension]) <= 0)
                {
                    node = node.LeftNode;
                }
                else
                {
                    node = node.RightNode;
                }
                byDimension++;
            }
            return null;
        }

        public TValue[] this[TKey[] posLowerBound, TKey[] posUpperBound]
        {
            get
            {
                CheckPosition(posLowerBound);
                CheckPosition(posUpperBound);

                var foundNodes = new List<KDTreeNode<TKey, TValue>>();

                if (_root != null)
                {
                    var nodeStack = new Stack<KDTreeNode<TKey, TValue>>();
                    var nodeDimensionStack = new Stack<int>();
                    nodeStack.Push(_root);
                    nodeDimensionStack.Push(0);

                    while (nodeStack.Count > 0)
                    {
                        var node = nodeStack.Pop();
                        int currDimension = nodeDimensionStack.Pop();

                        if (currDimension >= node.Position.Length)
                            currDimension = 0;
                        else if (currDimension < 0)
                            currDimension = node.Position.Length - 1;

                        bool higherThanLowerBound = node.Position[currDimension].CompareTo(posLowerBound[currDimension]) >= 0;
                        if (higherThanLowerBound && node.LeftNode != null)
                        {
                            nodeStack.Push(node.LeftNode);
                            nodeDimensionStack.Push(currDimension + 1);
                        }
                        bool lowerThanUpperBound = node.Position[currDimension].CompareTo(posUpperBound[currDimension]) < 0;
                        if (lowerThanUpperBound && node.RightNode != null)
                        {
                            nodeStack.Push(node.RightNode);
                            nodeDimensionStack.Push(currDimension + 1);
                        }

                        if (IsInBounds(node.Position, posLowerBound, posUpperBound))
                        {
                            foundNodes.Add(node);
                        }
                    }
                }
                return foundNodes.Select(x => x.Data).ToArray();
            }
        }

        private bool IsInBounds(TKey[] position, TKey[] posLowerBound, TKey[] posUpperBound)
        {
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i].CompareTo(posLowerBound[i]) < 0 || position[i].CompareTo(posUpperBound[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Remove(params TKey[] position)
        {
            CheckPosition(position);

            var node = GetNode(position);

            if (node == null)
                return false;

            if (node.IsLeaf())
            {
                var parent = node.Parent;
                if (parent.LeftNode == node)
                {
                    parent.LeftNode = null;
                }
                else if (parent.RightNode == node)
                {
                    parent.RightNode = null;
                }
                else throw new Exception("Remove - you should not get here.");
            }
            // TODO if its not a leaf
            return true;
        }

        public List<KDTreeNode<TKey, TValue>> LevelOrderTraversal()
        {
            var ret = new List<KDTreeNode<TKey, TValue>>();
            var nodesToTraverse = new Queue<KDTreeNode<TKey, TValue>>();
            nodesToTraverse.Enqueue(_root);

            while (nodesToTraverse.Count != 0)
            {
                var node = nodesToTraverse.Dequeue();
                if (node != null)
                {
                    ret.Add(node);
                    nodesToTraverse.Enqueue(node.LeftNode);
                    nodesToTraverse.Enqueue(node.RightNode);
                }
            }
            return ret;
        }

        public void PrintTree()
        {
            var height = GetHeight();
            var indentations = GetIndentations(height);

            var nodesToTraverse = new Queue<KDTreeNode<TKey, TValue>>();
            nodesToTraverse.Enqueue(_root);

            for (int h = 0; h < height; h++)
            {
                bool firstTime = true;
                Console.Write("    ".Repeat(indentations[h]));

                foreach (var node in nodesToTraverse)
                {
                    var nodeRepres = node != null ? node.Data.ToString().Substring(0, 4) : " -- ";
                    if (firstTime)
                    {
                        Console.Write(nodeRepres);
                        firstTime = false;
                    }
                    else
                    {
                        Console.Write("    ".Repeat(indentations[h - 1]) + nodeRepres);
                    }
                }

                int nodesToDequeue = nodesToTraverse.Count;
                for (int i = 0; i < nodesToDequeue; i++)
                {
                    var node = nodesToTraverse.Dequeue();
                    if (node != null)
                    {
                        nodesToTraverse.Enqueue(node.LeftNode);
                        nodesToTraverse.Enqueue(node.RightNode);
                    }
                    else
                    {
                        nodesToTraverse.Enqueue(null);
                        nodesToTraverse.Enqueue(null);
                    }

                }
                Console.WriteLine('\n');
            }
        }

        private void CheckPosition(TKey[] position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            if (position.Length != NumberOfDimensions)
            {
                throw new ArgumentException(nameof(position), $"Wrong number of dimensions in parameter {nameof(position)}.");
            }
        }

        private int GetHeight() => GetHeight(_root);

        private int GetHeight(KDTreeNode<TKey, TValue> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = GetHeight(node.LeftNode); // Rekurzia
                int rightHeight = GetHeight(node.RightNode); // Rekurzia

                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }
            }
        }

        private int[] GetIndentations(int treeHeight)
        {
            if (treeHeight <= 1)
            {
                return new int[] { 0 };
            }
            int[] indentations = new int[treeHeight];

            int levelIndent = 0;
            for (int level = treeHeight - 1; level >= 0; level--)
            {
                indentations[level] = levelIndent;
                levelIndent = levelIndent * 2 + 1;
            }
            return indentations;
        }

    }
}