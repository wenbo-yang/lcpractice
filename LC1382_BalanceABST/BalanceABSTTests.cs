using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1382_BalanceABST
{
    [TestClass]
    public class BalanceABSTTests
    {
        [TestMethod]
        public void GivenABST_BalanceABST_ShouldReturnBalancedTree()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", null, "2", null, "3", null, "4", null, null });
            var result = BalanceBST(root);

            Assert.IsTrue(result.Value == 2);
            Assert.IsTrue(result.Left.Value == 1);
            Assert.IsTrue(result.Right.Value == 3);
            
        }

        private BinaryTreeNode BalanceBST(BinaryTreeNode root)
        {
            var sortedList = new List<int>();

            InorderTraversal(root, sortedList);

            var balancedTreeRoot = ParseSortedListIntoBST(sortedList, (sortedList.Count - 1) / 2, 0, sortedList.Count - 1);

            return balancedTreeRoot;
        }

        private BinaryTreeNode ParseSortedListIntoBST(List<int> sortedList, int pivot, int lower, int upper)
        {
            if (lower > upper)
            {
                return null;
            }

            return new BinaryTreeNode
            {
                Value = sortedList[pivot],
                Left = ParseSortedListIntoBST(sortedList, (pivot - 1 + lower) / 2, lower, pivot - 1),
                Right = ParseSortedListIntoBST(sortedList, (pivot + 1 + upper) / 2, pivot + 1, upper)
            };
        }

        private void InorderTraversal(BinaryTreeNode root, List<int> sortedList)
        {
            if (root == null)
            {
                return;
            }

            InorderTraversal(root.Left, sortedList);
            sortedList.Add(root.Value);
            InorderTraversal(root.Right, sortedList);
        }
    }
}
