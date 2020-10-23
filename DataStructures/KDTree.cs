using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class KDTree<T>
    {
        public int Count { get; private set; } = 0;

        private readonly Comparer<T>[] _comparers;

        private readonly int _numberOfDimensions;

        private KDTreeNode<T> _root;

        /// <summary>
        /// TODO: Add comments to every public method
        /// </summary>
        /// <param name="comparers"></param>
        public KDTree(params Comparer<T>[] comparers)
        {
            if (comparers == null)
            {
                throw new ArgumentNullException(nameof(comparers));
            }
            if (comparers.Length == 0)
            {
                throw new ArgumentException(nameof(comparers), $"Empty parameter {nameof(comparers)}.");
            }
            _comparers = comparers;
            _numberOfDimensions = comparers.Length;
        }

        public KDTree(IEnumerable<T> data, params Comparer<T>[] comparers) : this(comparers)
        {
            AddRange(data);
        }

        public void Add(T data)
        {
            var newNode = new KDTreeNode<T>(data);

            if (_root == null)
            {
                _root = newNode;
                Count++;
                return;
            }

            int currDimension = 0;
            var node = _root;

            while (true)
            {
                currDimension %= _numberOfDimensions;

                if (_comparers[currDimension].Compare(newNode.Data, node.Data) <= 0)
                {
                    if (!node.HasLeftChild())
                    {
                        node.LeftChild = newNode;
                        break;
                    }
                    else node = node.LeftChild;
                }
                else
                {
                    if (!node.HasRightChild())
                    {
                        node.RightChild = newNode;
                        break;
                    }
                    else node = node.RightChild;
                }
                currDimension++;
            }
            newNode.Parent = node;
            Count++;
        }

        private void AddRange(IEnumerable<T> dataCollection)
        {
            // TODO: Add by Medians !
            throw new NotImplementedException();
        }

        public ICollection<T> Find(T exactData)
        {
            var exactMatches = new List<T>();
            foreach (var data in FindAt(exactData))
            {
                if (data.Equals(exactData))
                {
                    exactMatches.Add(data);
                }
            }
            return exactMatches;
        }

        public ICollection<T> FindAt(T dataPosition)
        {
            return FindInRange(dataPosition, dataPosition);
        }

        public ICollection<T> FindInRange(T posLowerBound, T posUpperBound)
        {
            return FindNodes(posLowerBound, posUpperBound).Select(x => x.Data).ToList();
        }

        private ICollection<KDTreeNode<T>> FindNodes(T posLowerBound, T posUpperBound)
        {
            var foundNodes = new List<KDTreeNode<T>>();

            if (_root != null)
            {
                var nodeStack = new Stack<KDTreeNode<T>>();
                var nodeDimensionStack = new Stack<int>();
                nodeStack.Push(_root);
                nodeDimensionStack.Push(0);

                while (nodeStack.Count > 0)
                {
                    var node = nodeStack.Pop();
                    int currDimension = nodeDimensionStack.Pop();

                    currDimension %= _numberOfDimensions;

                    bool higherThanLowerBound = _comparers[currDimension].Compare(node.Data, posLowerBound) >= 0;
                    if (higherThanLowerBound && node.HasLeftChild())
                    {
                        nodeStack.Push(node.LeftChild);
                        nodeDimensionStack.Push(currDimension + 1);
                    }
                    bool lowerThanUpperBound = _comparers[currDimension].Compare(node.Data, posUpperBound) < 0;
                    if (lowerThanUpperBound && node.HasRightChild())
                    {
                        nodeStack.Push(node.RightChild);
                        nodeDimensionStack.Push(currDimension + 1);
                    }

                    if (IsInBounds(node.Data, posLowerBound, posUpperBound))
                    {
                        foundNodes.Add(node);
                    }
                }
            }
            return foundNodes;
        }

        private bool IsInBounds(T nodeData, T posLowerBound, T posUpperBound)
        {
            for (int i = 0; i < _comparers.Length; i++)
            {
                if (_comparers[i].Compare(nodeData, posLowerBound) < 0 || _comparers[i].Compare(nodeData, posUpperBound) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int Contains(T exactData)
        {
            return Find(exactData).Count;
        }

        public int ContainsAt(T dataPosition)
        {
            return ContainsInRange(dataPosition, dataPosition);
        }

        public int ContainsInRange(T posLowerBound, T posUpperBound)
        {
            return FindNodes(posLowerBound, posUpperBound).Count;
        }

        public int Remove(T exactData)
        {
            int removedCount = 0;
            foreach (var node in FindNodes(exactData, exactData))
            {
                if (node.Equals(exactData))
                {
                    RemoveNode(node);
                    removedCount++;
                }
            }
            Count -= removedCount;
            return removedCount;
        }

        public int RemoveAt(T dataPosition)
        {
            return RemoveRange(dataPosition, dataPosition);
        }

        public int RemoveRange(T posLowerBound, T posUpperBound)
        {
            var nodesToRemove = FindNodes(posLowerBound, posUpperBound);
            foreach (var node in nodesToRemove)
            {
                RemoveNode(node);
            }
            Count -= nodesToRemove.Count;
            return nodesToRemove.Count;
        }

        private void RemoveNode(KDTreeNode<T> node)
        {
            if (node == _root)
            {
                if (_root.IsLeaf())
                {
                    _root = null;
                }
                else if (_root.HasOneChild()) // wrong
                {
                    var child = _root.LeftChild ?? _root.RightChild;
                    child.Parent = null;
                    _root = child;
                }
                else
                {
                    // TODO: ...
                }
            }
            else if (node.IsLeaf())
            {
                if (node.IsLeftChild())
                {
                    node.Parent.LeftChild = null;
                }
                else if (node.IsRigthChild())
                {
                    node.Parent.RightChild = null;
                }
                else throw new Exception("You should not get here - node is probably the root.");
            }
            else if (node.HasOneChild()) // wrong
            {
                var parent = node.Parent;
                var child = node.LeftChild ?? node.RightChild;
                if (node.IsLeftChild())
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
                child.Parent = parent;
            }
            else
            {
                // TODO: implement removing
                // ????
                // FindClosestGap(node) ??
                if (node.LeftChild.IsLeaf() || node.LeftChild.HasOneChild())
                {

                }
                else if (node.RightChild.IsLeaf() || node.RightChild.HasOneChild())
                {

                }
            }
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        public IList<T> ToList()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToList();
        }

        public T[] ToArray()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToArray();
        }

        private IList<KDTreeNode<T>> LevelOrderTraversal() // InOrderTraversal, PreOrderTraversal, PostOrderTraversal
        {
            var ret = new List<KDTreeNode<T>>(Count);
            var nodesToTraverse = new Queue<KDTreeNode<T>>();
            nodesToTraverse.Enqueue(_root);

            while (nodesToTraverse.Count != 0)
            {
                var node = nodesToTraverse.Dequeue();
                if (node != null)
                {
                    ret.Add(node);
                    nodesToTraverse.Enqueue(node.LeftChild);
                    nodesToTraverse.Enqueue(node.RightChild);
                }
            }
            return ret;
        }

        public void PrintTree()
        {
            var height = GetHeight();
            var indentations = GetIndentations(height);

            var nodesToTraverse = new Queue<KDTreeNode<T>>();
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
                        nodesToTraverse.Enqueue(node.LeftChild);
                        nodesToTraverse.Enqueue(node.RightChild);
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

        private int GetHeight() => GetHeight(_root);

        private int GetHeight(KDTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = GetHeight(node.LeftChild); // TODO: REMAKE Recursion
                int rightHeight = GetHeight(node.RightChild); // Recursion

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