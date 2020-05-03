using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1372_LongestZigZagBinaryTree
{
    [TestClass]
    public class LongestZigZagBinaryTreeTests
    {
        [TestMethod]
        public void GivenBinaryTree_GetLongestZigZagPath_ShouldReturnLongestLength()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", null, "1", "1", "1", null, null, "1", "1", null, "1", null, null, null, "1", null, "1" });

            var height = GetLongestZigZagPath(root);

            Assert.IsTrue(height == 3);
        }

        private int GetLongestZigZagPath(BinaryTreeNode root)
        {
            if (root == null) return 0;

            var globalMax = 0;

            GetLongestZigZagPathHelper(root.Right, Direction.Right, 0, ref globalMax);
            GetLongestZigZagPathHelper(root.Left, Direction.Left, 0, ref globalMax);
            return globalMax;
        }

        private void GetLongestZigZagPathHelper(BinaryTreeNode root, Direction direction, int current, ref int globalMax)
        {
            if (root == null)
            {
                globalMax = Math.Max(current, globalMax);
                return;
            }

            if (direction == Direction.Left)
            {
                GetLongestZigZagPathHelper(root.Right, Direction.Right, current + 1, ref globalMax);
                GetLongestZigZagPathHelper(root.Left, Direction.Left, 0, ref globalMax);
            }
            else 
            {
                GetLongestZigZagPathHelper(root.Left, Direction.Left, current + 1, ref globalMax);
                GetLongestZigZagPathHelper(root.Right, Direction.Right, 0, ref globalMax);
            }
        }

        public enum Direction
        {
            Left,
            Right
        }
    }
}
