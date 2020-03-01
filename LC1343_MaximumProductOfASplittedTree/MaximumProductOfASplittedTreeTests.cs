using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1343_MaximumProductOfASplittedTree
{
    [TestClass]
    public class MaximumProductOfASplittedTreeTests
    {
        [TestMethod]
        public void GivenBinaryTree_MaximizeProduct_ShouldReturnMaximizedProduct()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", null, "2", "3", "4", null, null, "5", "6" });

            var result = MaximizeProduct(root);

            Assert.IsTrue(result == 90);
        }

        [TestMethod]
        public void GivenAnotherBinaryTree_MaximizeProduct_ShouldReturnMaximizedProduct()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "2", "3", "9", "10", "7", "8", "6", "5", "4", "11", "1" });

            var result = MaximizeProduct(root);

            Assert.IsTrue(result == 1025);
        }

        [TestMethod]
        public void GivenThirdBinaryTree_MaximizeProduct_ShouldReturnMaximizedProduct()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "1" });

            var result = MaximizeProduct(root);

            Assert.IsTrue(result == 1);
        }

        private int MaximizeProduct(BinaryTreeNode root)
        {
            SumTreePostOrder(root);
            int currentMax = 0; 
            GetProductPreorder(root, root.Value, ref currentMax);

            return currentMax;
        }

        private void GetProductPreorder(BinaryTreeNode root, int globalSum, ref int currentMax)
        {
            if (root == null)
            {
                return;
            }

            currentMax = Math.Max(currentMax, (globalSum - root.Value) * root.Value);
            GetProductPreorder(root.Left, globalSum, ref currentMax);
            GetProductPreorder(root.Right, globalSum, ref currentMax);
        }

        private int SumTreePostOrder(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            root.Value = SumTreePostOrder(root.Left) + SumTreePostOrder(root.Right) + root.Value;

            return root.Value;
        }
    }
}
    