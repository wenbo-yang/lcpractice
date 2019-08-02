using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC226_InvertBinaryTree
{
    [TestClass]
    public class InvertBinaryTreeTests
    {
        [TestMethod]
        public void GivenBinaryTree_Invert_ShouldInvertBinaryTree()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "4", "2", "7", "1", "3", "6", "9" });

            root = Invert(root);

            Assert.IsTrue(root.Value == 4);
            Assert.IsTrue(root.Left.Value == 7);
            Assert.IsTrue(root.Right.Value == 2);
            Assert.IsTrue(root.Left.Left.Value == 9);
            Assert.IsTrue(root.Left.Right.Value == 6);
            Assert.IsTrue(root.Right.Left.Value == 3);
            Assert.IsTrue(root.Right.Right.Value == 1);
        }

        private BinaryTreeNode Invert(BinaryTreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            var tempLeft = Invert(node.Left);
            node.Right = Invert(node.Right);

            node.Left = node.Right;
            node.Right = tempLeft;

            return node;
        }
    }
}
