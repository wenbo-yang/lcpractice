using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC230_KthSmallestInABinaryTree
{
    [TestClass]
    public class KthSmallestInABinaryTreeTests
    {
        [TestMethod]
        public void GivenBST_FindKthSmallest_ShouldReturnCorrectResult()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] {"3", "1", "4", null, "2" });

            int result = FindKthSmallest(root, 1);

            Assert.IsTrue(result == 1);
        }

        private int FindKthSmallest(BinaryTreeNode root, int k)
        {
            var result = int.MaxValue;
            InOrder(root, ref k, ref result);

            return result;
        }

        private void InOrder(BinaryTreeNode root, ref int k, ref int result)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.Left, ref k, ref result);

            if (--k == 0)
            {
                result = root.Value;
                return;
            }

            InOrder(root.Right, ref k, ref result);
        }
    }
}
