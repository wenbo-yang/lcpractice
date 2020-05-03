using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1373_MaximumBSTInBinaryTree
{
    [TestClass]
    public class MaximumBSTInBinaryTreeTests
    {
        [TestMethod]
        public void GivenBinaryTreeWithBSTSubtree_GetMaximumBSTSum_ShouldReturnMaximumBSTSum()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "4", "3", "2", "4", "2", "5", null, null, null, null, null, null, "4", "6" });

            var result = GetMaximumBSTSum(root);

            Assert.IsTrue(result == 20);
        }

        private int GetMaximumBSTSum(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var result = GetMaximumBSTSumHelper(root);

            return result.sum < 0 ? 0 : result.sum;
        }

        private (bool isBST, int sum, int min, int max) GetMaximumBSTSumHelper(BinaryTreeNode root)
        {
            if (root.Left == null && root.Right == null)
            {
                return (true, root.Value, root.Value, root.Value);
            }

            (bool isBST, int sum, int min, int max) left;
            (bool isBST, int sum, int min, int max) right;

            if (root.Left == null)
            {
                right = GetMaximumBSTSumHelper(root.Right);

                if (right.isBST && root.Value < right.min)
                {
                    return (true, right.sum + root.Value, root.Value, right.max);
                }

                return (false, right.sum, int.MaxValue, int.MinValue);
            }

            if(root.Right == null)
            {
                left = GetMaximumBSTSumHelper(root.Left);

                if (left.isBST && root.Value > left.max)
                {
                    return (true, left.sum + root.Value, left.min, root.Value);
                }

                return (false, left.sum, int.MaxValue, int.MinValue);
            }

            left = GetMaximumBSTSumHelper(root.Left);
            right = GetMaximumBSTSumHelper(root.Right);


            if (right.isBST && left.isBST && root.Value > left.max && root.Value < right.min)
            {
                return (true, right.sum + left.sum + root.Value, left.min, right.max);
            }

            return (false, right.sum > left.sum ? right.sum : left.sum, int.MaxValue, int.MinValue);
        }
    }
}
