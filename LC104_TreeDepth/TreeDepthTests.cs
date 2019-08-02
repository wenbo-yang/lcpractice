using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC104_TreeDepth
{
    [TestClass]
    public class TreeDepthTests
    {
        [TestMethod]
        public void GivenTree_GetDepth_ShouldReturnDepth()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "9", "20", null, null, "15", "7" });

            int depth = GetDepth(root);

            Assert.IsTrue(depth == 3);
        }

        private int GetDepth(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(GetDepth(root.Left), GetDepth(root.Right)) + 1;
        }
    }
}
