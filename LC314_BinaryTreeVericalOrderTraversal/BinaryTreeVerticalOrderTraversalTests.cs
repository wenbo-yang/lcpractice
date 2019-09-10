using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC314_BinaryTreeVericalOrderTraversal
{
    [TestClass]
    public class BinaryTreeVerticalOrderTraversalTests
    {
        [TestMethod]
        public void GivenBinaryTree_VericalOrderTraversal_ShouldReturnTraversal()
        {
            var tree = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "9", "20", null, null, "15", "7" });

            List<List<int>> verticalTraversal = VerticalTraversal(tree);

            Assert.IsTrue(verticalTraversal.Count == 4);
            Assert.IsTrue(verticalTraversal[0].SequenceEqual(new List<int>() { 9 }));
            Assert.IsTrue(verticalTraversal[1].SequenceEqual(new List<int>() { 3, 15}));
            Assert.IsTrue(verticalTraversal[2].SequenceEqual(new List<int>() { 20 }));
            Assert.IsTrue(verticalTraversal[3].SequenceEqual(new List<int>() { 7 }));
        }

        private List<List<int>> VerticalTraversal(BinaryTreeNode root)
        {
            var vertical = new Dictionary<int, List<int>>();

            TraverseTree(root, 0, vertical);

            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var key in vertical.Keys)
            {
                if (key < min)
                {
                    min = key;
                }

                if (key > max)
                {
                    max = key;
                }
            }

            var result = new List<List<int>>();

            for (int i = min; i <= max; i++)
            {
                result.Add(vertical[i]);
            }

            return result;
        }

        private void TraverseTree(BinaryTreeNode root, int column, Dictionary<int, List<int>> vertical)
        {
            if (root == null)
            {
                return;
            }

            if (!vertical.ContainsKey(column))
            {
                vertical.Add(column, new List<int>());
            }

            vertical[column].Add(root.Value);

            TraverseTree(root.Left, column - 1, vertical);
            TraverseTree(root.Right, column + 1, vertical);
        }
    }
}
