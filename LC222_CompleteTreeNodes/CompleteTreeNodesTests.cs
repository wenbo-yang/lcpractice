using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC222_CompleteTreeNodes
{
    [TestClass]
    public class CompleteTreeNodesTests
    {
        [TestMethod]
        public void GivenBinaryTree_CountTreeNodes_ShouldReturnTreeNodes()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", "4", "5", "6" });

            var result = CountTreeNodes(root);

            Assert.IsTrue(result == 6);
        }

        private int CountTreeNodes(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var left = GetHeightLeft(root);
            var right = GetHeightRight(root);
            var count = 0;

            if (left == right)
            {
                count = (1 << left) - 1;
            }

            return 1 + CountTreeNodes(root.Left) + CountTreeNodes(root.Right);
        }

        private int GetHeightLeft(BinaryTreeNode root)
        {
            var height = 0;

            while (root != null)
            {
                root = root.Left;
                height++;
            }
            return height;
        }

        private int GetHeightRight(BinaryTreeNode root)
        {
            var height = 0;

            while (root != null)
            {
                root = root.Right;
                height++;
            }
            return height;
        }

    }
}
