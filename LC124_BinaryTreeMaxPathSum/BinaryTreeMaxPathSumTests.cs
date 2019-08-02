using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC124_BinaryTreeMaxPathSum
{
    [TestClass]
    public class BinaryTreeMaxPathSumTests
    {
        [TestMethod]
        public void GivenBinaryTree_MaxSumPath_ShouldReturnMaxPathSum()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", });

            int max = MaxSumPath(root);

            Assert.IsTrue(max == 6);
        }

        [TestMethod]
        public void GivenBinaryTreeWithNegativeValues_MaxSumPath_ShouldReturnMaxPathSum()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "-10", "9", "20", null, null, "15", "7"});

            int max = MaxSumPath(root);

            Assert.IsTrue(max == 42);
        }


        private int MaxSumPath(BinaryTreeNode root)
        {
            if (root == null)
            {
                return int.MinValue;
            }

            var currentMax = int.MinValue;
            MaxSumPathHelper(root, ref currentMax);

            return currentMax;
        }

        private int MaxSumPathHelper(BinaryTreeNode currentRoot, ref int currentMax)
        {
            if (currentRoot == null)
            {
                return 0;
            }

            var left = MaxSumPathHelper(currentRoot.Left, ref currentMax);
            var right = MaxSumPathHelper(currentRoot.Right, ref currentMax);

            var currentPathSum = currentRoot.Value + left + right;

            currentMax = currentMax < currentPathSum ? currentPathSum : currentMax;

            return Math.Max(0, Math.Max(currentRoot.Value + left, currentRoot.Value + right));
        }
    }
}
