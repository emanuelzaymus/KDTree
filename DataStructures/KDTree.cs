using CustomCalculations;
using CustomExtensions;
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
            AddRange(data.ToArray());
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
                currDimension = ToDimension(currDimension);

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

        public void AddRange(T[] dataArray)
        {
            var rangesQueue = new Queue<MedianRange>();
            rangesQueue.Enqueue(new MedianRange(0, dataArray.Length - 1, byDimension: 0)); // The whole range

            while (rangesQueue.Count > 0)
            {
                var range = rangesQueue.Dequeue();
                if (range.IsValid())
                {
                    int startIndex = range.StartIndex;
                    int endIndex = range.EndIndex;
                    int medianIndex = range.MedianIndex;
                    int byDimension = range.ByDimension;

                    T median = Medians.QuickSelect(dataArray, startIndex, endIndex, medianIndex, _comparers[byDimension].Compare);
                    Add(median);

                    rangesQueue.Enqueue(new MedianRange(startIndex, medianIndex - 1, ToDimension(byDimension + 1)));
                    rangesQueue.Enqueue(new MedianRange(medianIndex + 1, endIndex, ToDimension(byDimension + 1)));
                }
            }
        }

        public ICollection<T> Find(T exactData)
        {
            var exactMatches = new List<T>();
            foreach (var data in FindAt(exactData))
            {
                if (data != null && data.Equals(exactData) || data == null && exactData == null)
                {
                    exactMatches.Add(data);
                }
            }
            return exactMatches;
        }

        public ICollection<T> FindAt(T dataPosition)
        {
            return FindRange(dataPosition, dataPosition);
        }

        public ICollection<T> FindRange(T posLowerBound, T posUpperBound)
        {
            return FindNodes(posLowerBound, posUpperBound).Select(x => x.Node.Data).ToList();
        }

        private ICollection<DimensionalKDTreeNode<T>> FindNodes(T posLowerBound, T posUpperBound)
        {
            var foundNodes = new List<DimensionalKDTreeNode<T>>();

            if (_root != null)
            {
                var nodeStack = new Stack<KDTreeNode<T>>();
                nodeStack.Push(_root);
                var nodeDimensionStack = new Stack<int>();
                nodeDimensionStack.Push(0);

                while (nodeStack.Count > 0)
                {
                    var node = nodeStack.Pop();
                    int currDimension = nodeDimensionStack.Pop();

                    currDimension = ToDimension(currDimension);

                    bool higherOrEqualThanLowerBound = _comparers[currDimension].Compare(node.Data, posLowerBound) >= 0;
                    if (higherOrEqualThanLowerBound && node.HasLeftChild())
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
                        foundNodes.Add(new DimensionalKDTreeNode<T>(currDimension, node));
                    }
                }
            }
            return foundNodes;
        }

        private DimensionalKDTreeNode<T> FindFirst(T posLowerBound, T posUpperBound)
        {
            if (_root != null)
            {
                var nodeStack = new Stack<KDTreeNode<T>>();
                nodeStack.Push(_root);
                var nodeDimensionStack = new Stack<int>();
                nodeDimensionStack.Push(0);

                while (nodeStack.Count > 0)
                {
                    var node = nodeStack.Pop();
                    int currDimension = nodeDimensionStack.Pop();

                    currDimension = ToDimension(currDimension);

                    bool higherOrEqualThanLowerBound = _comparers[currDimension].Compare(node.Data, posLowerBound) >= 0;
                    if (higherOrEqualThanLowerBound && node.HasLeftChild())
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
                        return new DimensionalKDTreeNode<T>(currDimension, node);
                    }
                }
            }
            return null;
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
            return ContainsRange(dataPosition, dataPosition);
        }

        public int ContainsRange(T posLowerBound, T posUpperBound)
        {
            return FindNodes(posLowerBound, posUpperBound).Count;
        }

        public int Remove(T exactData)
        {
            int countRemoved = 0;
            var dimensionalNodeToRemove = FindFirst(exactData, exactData);
            while (dimensionalNodeToRemove != null && DataEqual(dimensionalNodeToRemove.Node.Data, exactData))
            {
                if (RemoveNode(dimensionalNodeToRemove))
                    countRemoved++;

                dimensionalNodeToRemove = FindFirst(exactData, exactData);
            }
            Count -= countRemoved;
            return countRemoved;

            bool DataEqual(T foundData, T exactData) =>
                foundData != null && foundData.Equals(exactData) || foundData == null && exactData == null;
        }

        public int RemoveAt(T dataPosition)
        {
            return RemoveRange(dataPosition, dataPosition);
        }

        public int RemoveRange(T posLowerBound, T posUpperBound)
        {
            int countRemoved = 0;
            var dimensionalNodeToRemove = FindFirst(posLowerBound, posUpperBound);
            while (dimensionalNodeToRemove != null)
            {
                if (RemoveNode(dimensionalNodeToRemove))
                    countRemoved++;

                dimensionalNodeToRemove = FindFirst(posLowerBound, posUpperBound);
            }
            Count -= countRemoved;
            return countRemoved;
        }

        private bool RemoveNode(DimensionalKDTreeNode<T> dimensionalNodeToRemove)
        {
            while (true)
            {
                var nodeToRemove = dimensionalNodeToRemove.Node;
                int nodeDimension = dimensionalNodeToRemove.Dimension;

                if (nodeToRemove.IsLeaf())
                {
                    if (nodeToRemove == _root)
                    {
                        _root = null;
                    }
                    else
                    {
                        if (nodeToRemove.IsLeftChild())
                        {
                            nodeToRemove.Parent.LeftChild = null;
                        }
                        else if (nodeToRemove.IsRigthChild())
                        {
                            nodeToRemove.Parent.RightChild = null;
                        }
                        else return false;
                    }
                    return true;
                }
                else // nodeToRemove has at least one child 
                {
                    DimensionalKDTreeNode<T> foundDimensionalNode = nodeToRemove.HasLeftChild()
                        ? FindMaxDimensionNode(nodeToRemove.LeftChild, nodeDimension) // Find maximal-dimension node in the left subtree
                        : FindMaxDimensionNode(nodeToRemove.RightChild, nodeDimension); // Find maximal-dimension node in the right subtree

                    var replacementNode = foundDimensionalNode.Node;

                    // Replace modeToRemove with found node (replacementNode)
                    nodeToRemove.Data = replacementNode.Data;

                    // If was nodeToRemove.Data replaced with maximal-dimension node Data from the right subtree -> 
                    // -> make from right subtree left subtree in the node (nodeToRemove)
                    if (!nodeToRemove.HasLeftChild())
                    {
                        nodeToRemove.LeftChild = nodeToRemove.RightChild;
                        nodeToRemove.RightChild = null;
                    }

                    // Remove found node (foundDimensionalNode)
                    dimensionalNodeToRemove = foundDimensionalNode;
                }
            }
        }

        private DimensionalKDTreeNode<T> FindMaxDimensionNode(KDTreeNode<T> subtreeRoot, int byDimension)
        {
            var maxDimensionNode = subtreeRoot;
            int maxDimenNodeDimension = ToDimension(byDimension + 1);

            var nodesToSearch = new Queue<KDTreeNode<T>>();
            nodesToSearch.Enqueue(maxDimensionNode);
            var nodeDimensions = new Queue<int>();
            nodeDimensions.Enqueue(maxDimenNodeDimension);

            while (nodesToSearch.Count > 0)
            {
                var currNode = nodesToSearch.Dequeue();
                var currDimension = ToDimension(nodeDimensions.Dequeue());

                if (_comparers[byDimension].Compare(currNode.Data, maxDimensionNode.Data) >= 0)
                {
                    maxDimensionNode = currNode;
                    maxDimenNodeDimension = currDimension;
                }
                if (currDimension != byDimension && currNode.HasLeftChild())
                {
                    nodesToSearch.Enqueue(currNode.LeftChild);
                    nodeDimensions.Enqueue(currDimension + 1);
                }
                if (currNode.HasRightChild())
                {
                    nodesToSearch.Enqueue(currNode.RightChild);
                    nodeDimensions.Enqueue(currDimension + 1);
                }
            }
            return new DimensionalKDTreeNode<T>(maxDimenNodeDimension, maxDimensionNode);
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        public List<T> ToList()
        {
            return ToLevelOrderTraversalList();
        }

        public T[] ToArray()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToArray();
        }

        public List<T> ToLevelOrderTraversalList()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToList();
        }

        private List<KDTreeNode<T>> LevelOrderTraversal() // InOrderTraversal, PreOrderTraversal, PostOrderTraversal
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
                    var nodeRepres = (node != null)
                        ? ((node.Data != null)
                            ? ((node.Data.ToString().Length > 4)
                                ? node.Data.ToString().Substring(0, 4)
                                : node.Data.ToString())
                            : "NULL")
                        : " -- ";
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

        private int ToDimension(int possibleDimension) => possibleDimension % _numberOfDimensions;

        private int GetHeight() => GetHeight(_root, 1);

        private int GetHeight(KDTreeNode<T> subtreeRootNode, int nodeHeight)
        {
            int maxHeight = 0;

            var nodeQueue = new Queue<KDTreeNode<T>>();
            nodeQueue.Enqueue(subtreeRootNode);
            var heightQueue = new Queue<int>();
            heightQueue.Enqueue(nodeHeight);

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                int height = heightQueue.Dequeue();

                if (node != null)
                {
                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                    nodeQueue.Enqueue(node.LeftChild);
                    heightQueue.Enqueue(height + 1);

                    nodeQueue.Enqueue(node.RightChild);
                    heightQueue.Enqueue(height + 1);
                }
            }
            return maxHeight;
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

        private struct MedianRange
        {
            public int StartIndex { get; }
            public int EndIndex { get; }
            public int ByDimension { get; }
            public int MedianIndex => StartIndex + (EndIndex - StartIndex + 1) / 2;

            public MedianRange(int startIndex, int endIndex, int byDimension)
            {
                StartIndex = startIndex;
                EndIndex = endIndex;
                ByDimension = byDimension;
            }

            public bool IsValid() => (StartIndex <= EndIndex);
        }

    }
}