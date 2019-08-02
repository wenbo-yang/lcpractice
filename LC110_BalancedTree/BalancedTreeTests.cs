using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC110_BalancedTree
{
    [TestClass]
    public class BalancedTreeTests
    {
        [TestMethod]
        public void GivenBalancedTree_IsBalancedTree_ShouldReturnTrue()
        {
            var array = new string[] { "3", "9", "20", null, null, "15", "7" };
            var root = BinaryTree.CreateBinaryTreeBFS(array);

            bool result = IsBalancedTree(root);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenUnbalancedTree_IsBalancedTree_ShouldReturnFalse()
        {
            var array = new string[] { "1", "2", "2", "3", "3", null, null, "4", "4" };
            var root = BinaryTree.CreateBinaryTreeBFS(array);

            bool result = IsBalancedTree(root);

            Assert.IsFalse(result);
        }

        private bool IsBalancedTree(BinaryTreeNode root)
        {
            var result = true;
            IsBalancedTreeHelper(root, ref result);

            return result;
        }

        private int IsBalancedTreeHelper(BinaryTreeNode root, ref bool result)
        {
            if (root == null)
            {
                result = true; 
                return 0;
            }

            var leftHeight = IsBalancedTreeHelper(root.Left, ref result) + 1;
            var rightHeight = IsBalancedTreeHelper(root.Right, ref result) + 1;

            result &= Math.Abs(leftHeight - rightHeight) <= 1;

            return Math.Max(leftHeight, rightHeight);
        }
    }
}
