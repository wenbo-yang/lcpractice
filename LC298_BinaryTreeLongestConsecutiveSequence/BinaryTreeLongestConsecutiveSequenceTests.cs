using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC298_BinaryTreeLongestConsecutiveSequence
{
    [TestClass]
    public class BinaryTreeLongestConsecutiveSequenceTests
    {
        [TestMethod]
        public void GivenBinaryTree_FindLongestConsecutiveSequence_ShouldReturnSequenceLength()
        {
            var root = BinaryTree.CreateBinaryTree(new string[] { "1", null, "3", "2", null, null, "4", null, "5"});

            var result = FindLongestConsecutiveSequence(root);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenAnotherBinaryTree_FindLongestConsecutiveSequence_ShouldReturnSequenceLength()
        {
            var root = BinaryTree.CreateBinaryTree(new string[] { "1", null, "2", "3", null, null, "4", null, "5" });

            var result = FindLongestConsecutiveSequence(root);

            Assert.IsTrue(result == 3);
        }

        private int FindLongestConsecutiveSequence(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var max = -1;

            FindLongestConsecutiveSequenceHelper(root, root.Value - 1, 0, ref max);

            return max;
        }

        private void FindLongestConsecutiveSequenceHelper(BinaryTreeNode root, int parentValue, int currentLength, ref int max)
        {
            if (root == null)
            {
                return;
            }

            if (parentValue == root.Value - 1)
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > max)
            {
                max = currentLength;
            }

            FindLongestConsecutiveSequenceHelper(root.Left, root.Value, currentLength, ref max);
            FindLongestConsecutiveSequenceHelper(root.Right, root.Value, currentLength, ref max);
        }
    }
}
