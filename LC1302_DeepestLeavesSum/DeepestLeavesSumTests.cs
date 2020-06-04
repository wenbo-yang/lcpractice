using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1302_DeepestLeavesSum
{
    [TestClass]
    public class DeepestLeavesSumTests
    {
        [TestMethod]
        public void GivenTree_DeepestLeavesSum_ShouldReturnCorrectAnswer()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", "4", "5", null, "6", "7", null, null, null, null, "8" });
            var result = DeepestLeavesSum(root);

            Assert.IsTrue(result == 15);
        }

        private int DeepestLeavesSum(BinaryTreeNode root)
        {
            var result = 0;
            var currentLevel = -1;
            var queue = new Queue<(BinaryTreeNode node, int level)>();
            queue.Enqueue((root, 0));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                if (top.level > currentLevel)
                {
                    result = 0;
                    currentLevel = top.level;
                }

                result += top.node.Value;

                if (top.node.Left != null)
                {
                    queue.Enqueue((top.node.Left, top.level + 1));
                }

                if (top.node.Right != null)
                {
                    queue.Enqueue((top.node.Right, top.level + 1));
                }
            }

            return result;
        }
    }
}
