using CustomAlgorithms.Extensions;
using CustomAlgorithms.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.KDTree
{
    /// <summary>
    /// K-Dimensional Tree
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class KDTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Count of present elements in this tree.
        /// </summary>
        public int Count { get; private set; } = 0;

        private readonly Comparer<T>[] _comparers;

        private readonly int _numberOfDimensions;

        private KDTreeNode<T> _root;

        /// <summary>
        /// K-Dimensional Tree
        /// </summary>
        /// <param name="comparers">K <paramref name="comparers"/> for comparing input data <c>T</c>. 
        /// Number of K <paramref name="comparers"/> corresponds to K dimensions of the tree.</param>
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

        /// <summary>
        /// K-Dimensional Tree
        /// </summary>
        /// <param name="data">Input <paramref name="data"/> will be added by medians.</param>
        /// <param name="comparers">K <paramref name="comparers"/> for comparing input data <c>T</c>. 
        /// Number of K <paramref name="comparers"/> corresponds to K dimensions of the tree.</param>
        public KDTree(IEnumerable<T> data, params Comparer<T>[] comparers) : this(comparers)
        {
            AddRange(data.ToArray());
        }

        /// <summary>
        /// Adds <paramref name="data"/> into the tree.
        /// </summary>
        /// <param name="data">Input <paramref name="data"/></param>
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

        /// <summary>
        /// Adds all <paramref name="dataArray"/> into the tree by medians.
        /// </summary>
        /// <param name="dataArray">Input data array</param>
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

        /// <summary>
        /// Finds all elements that are equal with <paramref name="exactData"/>.
        /// </summary>
        /// <param name="exactData">Exact data to find</param>
        /// <returns>All found exact elements</returns>
        public ICollection<T> Find(T exactData)
        {
            return FindRange(exactData, exactData, equalsWithLowerBound: true);
        }

        /// <summary>
        /// Finds all elements that are on the sme position as <paramref name="dataPosition"/>.
        /// </summary>
        /// <param name="dataPosition">Data position</param>
        /// <returns>All elements on the position <paramref name="dataPosition"/></returns>
        public ICollection<T> FindAt(T dataPosition)
        {
            return FindRange(dataPosition, dataPosition);
        }

        /// <summary>
        /// Finds all elements between lower position <paramref name="posLowerBound"/> and upper position <paramref name="posUpperBound"/>.
        /// </summary>
        /// <param name="posLowerBound">Lower position inclusive</param>
        /// <param name="posUpperBound">Upper position inclusive</param>
        /// <returns>All elemnts that lie in bounds</returns>
        public ICollection<T> FindRange(T posLowerBound, T posUpperBound)
        {
            return FindRange(posLowerBound, posUpperBound, equalsWithLowerBound: false);
        }

        private ICollection<T> FindRange(T posLowerBound, T posUpperBound, bool equalsWithLowerBound)
        {
            return FindNodes(posLowerBound, posUpperBound, equalsWithLowerBound).Select(x => x.Node.Data).ToList();
        }

        private IEnumerable<DimensionalKDTreeNode<T>> FindNodes(T posLowerBound, T posUpperBound, bool equalsWithLowerBound)
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
                        if (!equalsWithLowerBound || Equals(node.Data, posLowerBound))
                            yield return new DimensionalKDTreeNode<T>(currDimension, node);
                    }
                }
            }
        }

        private DimensionalKDTreeNode<T> FindFirst(T posLowerBound, T posUpperBound, bool equalsWithLowerBound)
        {
            return FindNodes(posLowerBound, posUpperBound, equalsWithLowerBound).FirstOrDefault();
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

        /// <summary>
        /// Returns number of elements that are equal with <paramref name="exactData"/>.
        /// </summary>
        /// <param name="exactData">Exact data to find</param>
        /// <returns>Count of found exact elements</returns>
        public int Contains(T exactData)
        {
            return Find(exactData).Count;
        }

        /// <summary>
        /// Returns number of elements that are on the sme position as <paramref name="dataPosition"/>.
        /// </summary>
        /// <param name="dataPosition">Data position</param>
        /// <returns>Count of elements on the position <paramref name="dataPosition"/></returns>
        public int ContainsAt(T dataPosition)
        {
            return ContainsRange(dataPosition, dataPosition);
        }

        /// <summary>
        /// Returns number of elements between lower position <paramref name="posLowerBound"/> and upper position <paramref name="posUpperBound"/>.
        /// </summary>
        /// <param name="posLowerBound">Lower position inclusive</param>
        /// <param name="posUpperBound">Upper position inclusive</param>
        /// <returns>Count of elemnts that lie in bounds</returns>
        public int ContainsRange(T posLowerBound, T posUpperBound)
        {
            return FindNodes(posLowerBound, posUpperBound, equalsWithLowerBound: false).Count();
        }

        /// <summary>
        /// Removes all elements that are equal with <paramref name="exactData"/>.
        /// </summary>
        /// <param name="exactData">Exact data to remove</param>
        /// <returns>Count of removed elements</returns>
        public int Remove(T exactData)
        {
            return RemoveRange(exactData, exactData, equalsWithLowerBound: true);
        }

        /// <summary>
        /// Removes all elements that are on the sme position as <paramref name="dataPosition"/>.
        /// </summary>
        /// <param name="dataPosition">Data position on which will be removed all elements</param>
        /// <returns>Count of removed elements</returns>
        public int RemoveAt(T dataPosition)
        {
            return RemoveRange(dataPosition, dataPosition);
        }

        /// <summary>
        /// Removes all elements between lower position <paramref name="posLowerBound"/> and upper position <paramref name="posUpperBound"/>.
        /// </summary>
        /// <param name="posLowerBound">Remove elements from <paramref name="posLowerBound"/> (inclusive)</param>
        /// <param name="posUpperBound">Remove elements to <paramref name="posUpperBound"/> (inclusive)</param>
        /// <returns>Count of removed elements</returns>
        public int RemoveRange(T posLowerBound, T posUpperBound)
        {
            return RemoveRange(posLowerBound, posUpperBound, equalsWithLowerBound: false);
        }

        private int RemoveRange(T posLowerBound, T posUpperBound, bool equalsWithLowerBound)
        {
            int countRemoved = 0;
            var dimensionalNodeToRemove = FindFirst(posLowerBound, posUpperBound, equalsWithLowerBound);
            while (dimensionalNodeToRemove != null)
            {
                if (RemoveNode(dimensionalNodeToRemove))
                    countRemoved++;

                dimensionalNodeToRemove = FindFirst(posLowerBound, posUpperBound, equalsWithLowerBound);
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

        /// <summary>
        /// Deletes all elments.
        /// </summary>
        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        /// <summary>
        /// Converts the tree to list.
        /// </summary>
        /// <returns>All elements in level order traversal</returns>
        public List<T> ToList()
        {
            return ToLevelOrderTraversalList();
        }

        /// <summary>
        /// Converts the tree to array.
        /// </summary>
        /// <returns>All elements in level order traversal</returns>
        public T[] ToArray()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToArray();
        }

        /// <summary>
        /// Returns all elemnts in level order traversal.
        /// </summary>
        /// <returns>All elements in level order traversal in <c>List</c></returns>
        public List<T> ToLevelOrderTraversalList()
        {
            return LevelOrderTraversal().Select(x => x.Data).ToList();
        }

        private IEnumerable<KDTreeNode<T>> LevelOrderTraversal() // InOrderTraversal, PreOrderTraversal, PostOrderTraversal
        {
            var nodesToTraverse = new Queue<KDTreeNode<T>>();
            nodesToTraverse.Enqueue(_root);

            while (nodesToTraverse.Count != 0)
            {
                var node = nodesToTraverse.Dequeue();
                if (node != null)
                {
                    yield return node;
                    nodesToTraverse.Enqueue(node.LeftChild);
                    nodesToTraverse.Enqueue(node.RightChild);
                }
            }
        }

        /// <summary>
        /// Gets enumerator for all elements in level order traversal.
        /// </summary>
        /// <returns>Tree enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return LevelOrderTraversal().Select(x => x.Data).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Prints the tree to the console.
        /// </summary>
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
                    var nodeRepres = node != null
                        ? node.Data != null
                            ? node.Data.ToString().Length > 4
                                ? node.Data.ToString().Substring(0, 4)
                                : node.Data.ToString()
                            : "NULL"
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

            public bool IsValid() => StartIndex <= EndIndex;
        }

    }
}