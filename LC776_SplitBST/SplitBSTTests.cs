using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC776_SplitBST
{
    [TestClass]
    public class SplitBSTTests
    {
        [TestMethod]
        public void ValidBinarySearchTreeAndValidTarget_SplitTree_ShouldReturnValidTreeNodes()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] {"4", "2", "6", "1", "3", "5", "7" });
            var target = 2;

            var splitedTree = SplitTree(ref root, target);

            Assert.IsTrue(splitedTree.Value == 2);
            Assert.IsTrue(splitedTree.Left.Value == 1);
            Assert.IsTrue(splitedTree.Right == null);

            Assert.IsTrue(root.Left.Value == 3);
            Assert.IsTrue(root.Left.Right == null);
            Assert.IsTrue(root.Left.Left == null);
        }

        private BinaryTreeNode SplitTree(ref BinaryTreeNode root, int target)
        {
            if (target == root.Value)
            {
                var temp = root;
                root = root.Right;
                temp.Right = null;
                return temp;
            }

            return target > root.Value ? SplitTree(ref root.Right, target) : SplitTree(ref root.Left, target);
        }
    }
}
