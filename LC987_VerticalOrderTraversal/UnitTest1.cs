using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC987_VerticalOrderTraversal
{
    [TestClass]
    public class VerticalOrderTraversal
    {
        [TestMethod]
        public void GivenBinaryTree_PrintVerticalOrder_ShouldPrintVerticalOrder()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "9", "20", null, null, "15", "7" });

            var list = PrintVerticalOrder(root);

            Assert.IsTrue(list.Count == 4);
        }

        private List<List<int>> PrintVerticalOrder(BinaryTreeNode root)
        {
            var result = new List<List<int>>();
            if (root == null)
            {
                return result;
            }

            var left = 0;
            var right = 0;

            var table = new Dictionary<int, List<int>>();
            PrintVerticalOrderHelper(root, 0, ref left, ref right, table);

            for (int i = left; i <= right; i++)
            {
                result.Add(table[i]);
            }

            return result;
        }

        private void PrintVerticalOrderHelper(BinaryTreeNode root, int current, ref int left, ref int right, Dictionary<int, List<int>> table)
        {
            if (root == null)
            {
                return;
            }

            left = current < left ? current : left;
            right = current > right ? current : right;

            if (!table.ContainsKey(current))
            {
                table.Add(current, new List<int>());
            }

            table[current].Add(root.Value);

            PrintVerticalOrderHelper(root.Left, current - 1, ref left, ref right, table);
            PrintVerticalOrderHelper(root.Right, current + 1, ref left, ref right, table);
        }
    }
}
