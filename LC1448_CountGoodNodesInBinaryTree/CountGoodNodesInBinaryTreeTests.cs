using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1448_CountGoodNodesInBinaryTree
{
    [TestClass]
    public class CountGoodNodesInBinaryTreeTests
    {
        [TestMethod]
        public void GivenTree_GetNumberOfGoodNodes_ShouldReturnCorrectNumber()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] {"3", "1", "4", "3", null, "1", "5"});

            var result = GetNumberOfGoodNodes(root);

            Assert.IsTrue(result == 4);
        }

        private int GetNumberOfGoodNodes(BinaryTreeNode root)
        {
            return GetNumberOfGoodNodesHelper(root, 0);
        }

        private int GetNumberOfGoodNodesHelper(BinaryTreeNode root, int max)
        {
            if (root == null)
            {
                return 0;
            }

            var result = max > root.Value ? 0 : 1;

            max = Math.Max(root.Value, max);
            result += GetNumberOfGoodNodesHelper(root.Left, max) + GetNumberOfGoodNodesHelper(root.Right, max);

            return result; 
        }
    }
}
