using CommonUtilities;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC98_ValidateBinarySearchTree
{
    [TestClass]
    public class ValidateBSTTests
    {
        [TestMethod]
        public void GivenBST_Validate_ShouldReturnCorrectResult()
        {
            var validBst = new string[] { "2", "1", "3" };

            var root = BinaryTree.CreateBinaryTree(validBst);

            bool result = ValidateBST(root);

            Assert.IsTrue(result);
        }

        private bool ValidateBST(BinaryTreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return ValidateBSTHelper(root.Left, int.MinValue, root.Value) && ValidateBSTHelper(root.Right, root.Value, int.MaxValue);
        }

        private bool ValidateBSTHelper(BinaryTreeNode currentRoot, int lowerBound, int upperBound)
        {
            if (currentRoot == null)
            {
                return true;
            }

            if (currentRoot.Value <= lowerBound && currentRoot.Value > upperBound)
            {
                return false;
            }

            return ValidateBSTHelper(currentRoot.Left, int.MinValue, currentRoot.Value) && ValidateBSTHelper(currentRoot.Right, currentRoot.Value, int.MaxValue);
        }
    }
}
