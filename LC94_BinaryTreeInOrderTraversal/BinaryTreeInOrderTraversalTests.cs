using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC94_BinaryTreeInOrderTraversal
{
    [TestClass]
    public class BinaryTreeInOrderTraversalTests
    {
        [TestMethod]
        public void GivenInputArray_CreateTree_ShouldCreateTree()
        {
            var input = new string[] { "1", null, "2", "3" };

            var root = BinaryTree.CreateBinaryTree(input);

            Assert.IsTrue(root.Value == 1);
            Assert.IsTrue(root.Left == null);
            Assert.IsTrue(root.Right.Value == 2);
            Assert.IsTrue(root.Right.Left.Value == 3);
        }

        [TestMethod]
        public void GivenInputArray_InOrderTraversal_ShouldTraverseTree()
        {
            var input = new string[] { "1", null, "2", "3" };

            var root = BinaryTree.CreateBinaryTree(input);

            List<int> result = InOrderTraversal(root);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 1, 3, 2 }));
        }

        private List<int> InOrderTraversal(BinaryTreeNode root)
        {
            var result = new List<int>();
            if (root != null)
            {
                result.AddRange(InOrderTraversal(root.Left));
                result.Add(root.Value);
                result.AddRange(InOrderTraversal(root.Right));
            }

            return result;
        }
    }
}
