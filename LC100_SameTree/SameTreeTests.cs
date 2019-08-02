using CommonUtilities;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC100_SameTree
{
    [TestClass]
    public class SameTreeTests
    {
        [TestMethod]
        public void GivenTwoIdenticalTrees_VerifySameTree_ShouldReturnTrue()
        {
            var tree1 = BinaryTree.CreateBinaryTree(new string[] { "1", "2", "3" });
            var tree2 = BinaryTree.CreateBinaryTree(new string[] { "1", "2", "3" });

            bool result = VerifyTree(tree1, tree2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenDifferentTrees_VerifySameTree_ShouldReturnFalse()
        {
            var tree1 = BinaryTree.CreateBinaryTree(new string[] { "1", "2" });
            var tree2 = BinaryTree.CreateBinaryTree(new string[] { "1", null, "2" });

            bool result = VerifyTree(tree1, tree2);

            Assert.IsFalse(result);
        }

        private bool VerifyTree(BinaryTreeNode tree1, BinaryTreeNode tree2)
        {
            if (tree1 == null && tree2 == null)
            {
                return true;
            }

            if (tree1 == null || tree2 == null)
            {
                return false;
            }

            return tree1.Value == tree2.Value && VerifyTree(tree1.Left, tree2.Left) && VerifyTree(tree1.Right, tree2.Right);    
        }
    }
}
