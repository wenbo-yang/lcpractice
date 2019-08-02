using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC102_BinaryTreeLevelOrderTraversal
{
    [TestClass]
    public class BinaryTreeLevelOrderTraversalTests
    {
        [TestMethod]
        public void GivenBinaryTree_LevelOrderTraversal_ShouldReturnListOfOutputs()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "9", "20", null, null, "15", "7" });

            List<List<int>> result = LevelOrderTraversal(root);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].SequenceEqual(new List<int>() { 3 }));
            Assert.IsTrue(result[1].SequenceEqual(new List<int>() { 9, 20 }));
            Assert.IsTrue(result[2].SequenceEqual(new List<int>() { 15, 7 }));
        }

        private List<List<int>> LevelOrderTraversal(BinaryTreeNode root)
        {
            var results = new List<List<int>>() { new List<int>() };
            var queue = new Queue<Tuple<int, BinaryTreeNode>>();
            queue.Enqueue(new Tuple<int, BinaryTreeNode>(0, root));
            

            var currentLevel = 0;
            while (queue.Count != 0)
            {
                var currentItem = queue.Peek();

                if (currentItem.Item1 == currentLevel)
                {
                    results[currentLevel].Add(currentItem.Item2.Value);

                    if (currentItem.Item2.Left != null)
                    {
                        queue.Enqueue(new Tuple<int, BinaryTreeNode>(currentLevel + 1, currentItem.Item2.Left));
                    }

                    if (currentItem.Item2.Right != null)
                    {
                        queue.Enqueue(new Tuple<int, BinaryTreeNode>(currentLevel + 1, currentItem.Item2.Right));
                    }

                    queue.Dequeue();
                }
                else
                {
                    currentLevel++;
                    results.Add(new List<int>());
                }
            }

            return results;
        }
    }
}
