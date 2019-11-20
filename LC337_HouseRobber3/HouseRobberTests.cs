using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC337_HouseRobber3
{
    [TestClass]
    public class HouseRobberTests
    {
        [TestMethod]
        public void GivenBinaryTree_MaxOfAlternativingLevel_ShouldReturnBiggerOfTheAlternatingRows()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "2", "3", null, "3", null, "1"});

            var result = MaxOfAlternatingLevel(root);

            Assert.IsTrue(result == 7);
        }

        private int MaxOfAlternatingLevel(BinaryTreeNode root)
        {
            int even = 0;
            int odd = 0;
            SumOfAlternatingLevel(root, 0, ref even, ref odd);

            return Math.Max(even, odd);
        }

        private void SumOfAlternatingLevel(BinaryTreeNode root, int level, ref int even, ref int odd)
        {
            if (root == null)
            {
                return;
            }

            if (level % 2 == 0)
            {
                even += root.Value;
            }
            else
            {
                odd += root.Value;
            }

            SumOfAlternatingLevel(root.Left, level + 1, ref even, ref odd);
            SumOfAlternatingLevel(root.Right, level + 1, ref even, ref odd);
        }
    }
}
