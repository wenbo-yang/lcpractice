using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1301_DeepestLeavesSum
{
    [TestClass]
    public class DeepestLeavesSumTests
    {
        [TestMethod]
        public void GivenBinaryTree_DeepestLeavesSum_ShouldReturnCorrectSum()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", "4", "5", null, "6", "7", null, null, null, null, "8" });

            var sum = DeepestLeavesSum(root);

            Assert.IsTrue(sum == 15);
        }

        private int DeepestLeavesSum(BinaryTreeNode root)
        {
            (int depth, int value) result = (-1, int.MinValue);

            TraverseTreePostOrder(root, 0, ref result);

            return result.value;
        }

        private void TraverseTreePostOrder(BinaryTreeNode root, int currentDepth, ref (int depth, int value) result)
        {
            if (root == null)
            {
                return;
            }

            TraverseTreePostOrder(root.Left, currentDepth + 1, ref result);
            TraverseTreePostOrder(root.Right, currentDepth + 1, ref result);

            if (currentDepth == result.depth)
            {
                result.value += root.Value;
            }
            else if (currentDepth > result.depth)
            {
                result.depth = currentDepth;
                result.value = root.Value;
            }
        }
    }
}
