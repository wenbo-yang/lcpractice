using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC270_ClosestValueInBST
{
    [TestClass]
    public class ClosestValueInBSTTests
    {
        /// <summary>
        ///       4
        ///    2    6
        ///  1  3  5  7
        /// </summary>

        [TestMethod]
        public void GivenBinarySearchTree_FindClosestValue_ShouldReturnCorrectValue()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "4", "2", "6", "1", "3", "5", "7" });
            var target = 8;

            var result = FindClosestValue(root, target);

            Assert.IsTrue(result == 7);
        }

        private int FindClosestValue(BinaryTreeNode root, int target)
        {
            if (root == null)
            {
                throw new ArgumentException();
            }

            var result = 0;

            FindClosestValueHelper(root, target, ref result);

            return result;
        }

        private void FindClosestValueHelper(BinaryTreeNode root, int target, ref int result)
        {
            if (root == null)
            {
                return;
            }

            if (target < root.Value)
            {
                FindClosestValueHelper(root.Left, target, ref result);
            }
            else
            {
                FindClosestValueHelper(root.Right, target, ref result);
            }

            var diff = Math.Abs(root.Value - target);

            result = Math.Abs(target - result) > diff ? root.Value : result; 
        }
    }
}
