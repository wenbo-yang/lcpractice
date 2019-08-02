using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC101_SymetricTree
{
    [TestClass]
    public class SymetricTreeTest
    {
        [TestMethod]
        public void GivenInputArray_CreateTreeBFS_CreateTree()
        {
            var treeRoot = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "2", "3", "4", "4", "3" });

            Assert.IsTrue(treeRoot.Value == 1);
            Assert.IsTrue(treeRoot.Left.Value == 2);
            Assert.IsTrue(treeRoot.Right.Value == 2);
            Assert.IsTrue(treeRoot.Left.Left.Value == 3);
            Assert.IsTrue(treeRoot.Left.Right.Value == 4);
            Assert.IsTrue(treeRoot.Right.Left.Value == 4);
            Assert.IsTrue(treeRoot.Right.Right.Value == 3);
        }

        [TestMethod]
        public void GivenSymetricTree_ValidateSymetricTree_ShouldReturnTree()
        {
            var treeRoot = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "2", "3", "4", "4", "3" });

            bool result = ValidateSymetricTree(treeRoot);

            Assert.IsTrue(result);
        }

        private bool ValidateSymetricTree(BinaryTreeNode treeRoot)
        {
            if (treeRoot == null)
            {
                return true;
            }

            return ValidateSymetricTreeHelper(treeRoot.Left, treeRoot.Right);
        }

        private bool ValidateSymetricTreeHelper(BinaryTreeNode left, BinaryTreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            return left.Value == right.Value && ValidateSymetricTreeHelper(left.Left, right.Right) && ValidateSymetricTreeHelper(left.Right, right.Left);
        }
    }
}
