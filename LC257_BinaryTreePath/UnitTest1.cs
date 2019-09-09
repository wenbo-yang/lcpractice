using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC257_BinaryTreePath
{
    [TestClass]
    public class BinaryTreePathTests
    {
        [TestMethod]
        public void GivenBinaryTree_GetBinaryTreePaths_ShouldReturnCorrectPath()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", null, "5" });

            List<List<int>> paths = GetBinaryTreePaths(root);

            Assert.IsTrue(paths.Count == 2);
            Assert.IsTrue(paths[0].SequenceEqual(new List<int>() { 1, 2, 5 }));
            Assert.IsTrue(paths[1].SequenceEqual(new List<int>() { 1, 3 }));
        }

        private List<List<int>> GetBinaryTreePaths(BinaryTreeNode root)
        {
            var results = new List<List<int>>();
            GetBinaryTreePathsHelper(root, new List<int>(), results);

            return results;
        }

        private void GetBinaryTreePathsHelper(BinaryTreeNode root, List<int> currentResult, List<List<int>> results)
        {
            if (root.Left == null && root.Right == null)
            {
                currentResult.Add(root.Value);
                results.Add(new List<int>(currentResult));
                currentResult.RemoveAt(currentResult.Count - 1);
            }


            currentResult.Add(root.Value);
            if (root.Left != null) GetBinaryTreePathsHelper(root.Left, currentResult, results);
            if (root.Right != null) GetBinaryTreePathsHelper(root.Right, currentResult, results);

            currentResult.RemoveAt(currentResult.Count - 1);
        }
    }
}
