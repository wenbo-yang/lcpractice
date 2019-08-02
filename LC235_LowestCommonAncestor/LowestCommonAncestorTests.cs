using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC235_LowestCommonAncestor
{
    // LC236 is also here

    [TestClass]
    public class LowestCommonAncestorTests
    {
        [TestMethod]
        public void GivenBSTAndTwoNodes_FindLCA_ShouldReturnNode()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "6", "2", "8", "0", "4", "7", "9", null, null, "3", "5" });

            var result = FindLowestCommonAncestorBST(root, 2, 4);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenBinaryTreeAndTwoNodes_FindLCA_ShouldReturnNode()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "5", "1", "6", "2", "0", "8", null, null, "7", "4" });

            var result = FindLowestCommonAncestorBinaryTree(root, 5, 1);

            Assert.IsTrue(result == 3);
        }

        private int FindLowestCommonAncestorBinaryTree(BinaryTreeNode root, int node1, int node2)
        {
            BinaryTreeNode lca = null;

            FindLowestCommonAncestorBinaryTreeHelper(root, node1, node2, ref lca);

            return lca.Value;
        }

        private Found FindLowestCommonAncestorBinaryTreeHelper(BinaryTreeNode root, int node1, int node2, ref BinaryTreeNode result)
        {
            if (root == null)
            {
                return Found.None;
            }

            var foundL = FindLowestCommonAncestorBinaryTreeHelper(root.Left, node1, node2, ref result);
            if (foundL == Found.Both)
            {
                return foundL;
            }

            var foundR = FindLowestCommonAncestorBinaryTreeHelper(root.Right, node1, node2, ref result);
            if (foundR == Found.Both)
            {
                return foundR;
            }


            var retVal = Found.None;
            if (root.Value == node1)
            {
                retVal = Found.Node1;
            }

            if (root.Value == node2)
            {
                retVal = Found.Node2;
            }

            retVal = (retVal | foundL | foundR);
            if (retVal == Found.Both)
            {
                result = root;
            }

            return retVal;
        }

        private int FindLowestCommonAncestorBST(BinaryTreeNode root, int node1, int node2)
        {
            if (root.Value == node1 || root.Value == node2 || 
                (Math.Max(node1, node2) > root.Value && Math.Min(node1, node2) < root.Value) 
                )
            {
                return root.Value;
            }

            // personally I prefer this expression
            //if (node1 < root.Value && node2 < root.Value)
            //{
            //    return FindLowestCommonAncestorBST(root.Left, node1, node2);
            //}

            //if (node1 > root.Value && node2 > root.Value)
            //{
            //    return FindLowestCommonAncestorBST(root.Right, node1, node2);
            //}

            return Math.Max(node1, node2) < root.Value ? FindLowestCommonAncestorBST(root.Left, node1, node2) : FindLowestCommonAncestorBST(root.Right, node1, node2);
        }

        private enum Found
        {
            None = 0,
            Node1 = 1,
            Node2 = 2,
            Both = 3
        }
    }
}
