using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1325_DeleteLeavesWithAGivenValue
{
    [TestClass]
    public class DeleteLeavesWithAGivenValueTests
    {
        [TestMethod]
        public void GivenBinaryTreeAndValue_DeleteLeavesWithGivenValueShouldDeleteTheLeaves()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", "2", null, "2", "4" });
            var value = 2;
            
            root = DeleteLeavesWithGivenValue(root, value);
            Assert.IsTrue(root.Left == null);
        }

        [TestMethod]
        public void GivenAnotherBinaryTreeAndValue_DeleteLeavesWithGivenValueShouldDeleteTheLeaves()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "1", "1"});
            var value = 1;

            root = DeleteLeavesWithGivenValue(root, value);
            Assert.IsTrue(root == null);
        }

        private BinaryTreeNode DeleteLeavesWithGivenValue(BinaryTreeNode root, int value)
        {
            if(DeleteLeavesWithGivenValueHelper(root, value))
            {
                root = null;
            }

            return root;
        }

        private bool DeleteLeavesWithGivenValueHelper(BinaryTreeNode root, int value)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Left != null && DeleteLeavesWithGivenValueHelper(root.Left, value))
            {
                root.Left = null;
            }

            if (root.Right != null && DeleteLeavesWithGivenValueHelper(root.Right, value))
            {
                root.Right = null;
            }

            if (root.Left == null && root.Right == null)
            {
                return root.Value == value;
            }

            return false;
        }
    }
}
