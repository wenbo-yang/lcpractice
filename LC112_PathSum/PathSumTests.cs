using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC112_PathSum
{
    // 113 is also here
    [TestClass]
    public class PathSumTests
    {
        [TestMethod]
        public void GivenTree_HasRootToLeafPathSum_ShouldReturnTrue()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "5", "4", "8", "11", null, "13", "4", "7", "2", null, null, null, "1" });
            var target = 22;

            bool result = HasRootToLeafPathSum(root, target);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTree_PathSum_ShouldReturnListOfResults()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "5", "4", "8", "11", null, "13", "4", "7", "2", null, null, "5", "1" });
            var target = 22;

            List<List<int>> result = PathSum(root, target);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].SequenceEqual(new List<int>() { 5, 4, 11, 2}));
            Assert.IsTrue(result[1].SequenceEqual(new List<int>() { 5, 8, 4, 5 }));
        }

        private List<List<int>> PathSum(BinaryTreeNode root, int target)
        {
            var results = new List<List<int>>();

            PathSumHelper(root, target, new List<int>(), results);

            return results;
        }

        private void PathSumHelper(BinaryTreeNode currentRoot, int target, List<int> currentResult, List<List<int>> results)
        {
            currentResult.Add(currentRoot.Value);

            if (IsLeaf(currentRoot))
            {
                if (currentRoot.Value == target)
                {
                    results.Add(new List<int>(currentResult));
                }

                currentResult.RemoveAt(currentResult.Count - 1);
                return;
            }

            if (currentRoot.Left != null) PathSumHelper(currentRoot.Left, target - currentRoot.Value, currentResult, results);
            if (currentRoot.Right != null) PathSumHelper(currentRoot.Right, target - currentRoot.Value, currentResult, results);
            
            currentResult.RemoveAt(currentResult.Count - 1);
        }

        private bool IsLeaf(BinaryTreeNode currentRoot)
        {
            return currentRoot.Left == null && currentRoot.Right == null;
        }

        private bool HasRootToLeafPathSum(BinaryTreeNode currentRoot, int target)
        {
            if (currentRoot == null)
            {
                return target == 0;
            }

            return HasRootToLeafPathSum(currentRoot.Left, target - currentRoot.Value) || HasRootToLeafPathSum(currentRoot.Right, target - currentRoot.Value);
        }
    }
}
