using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1315_SumOfNodesInEvenValuedGrandParent
{
    [TestClass]
    public class SumOfNodesInEvenValuedGrandParentTests
    {
        [TestMethod]
        public void GivenRoot_SumOfNodes_ShouldReturnCorrectResult()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "6", "7", "8", "2", "7", "1", "3", "9", null, "1", "4", null, null, null, "5"});

            var result = GetSumOfNodesWithEvenValuedGrandParents(root);

            Assert.IsTrue(result == 18);
        }

        private int GetSumOfNodesWithEvenValuedGrandParents(BinaryTreeNode root)
        {
            var result = 0;

            var queue = new Queue<(BinaryTreeNode current, BinaryTreeNode parent, BinaryTreeNode grandParent)>();

            queue.Enqueue((root, null, null));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (top.grandParent != null && top.grandParent.Value % 2 == 0)
                {
                    result += top.current.Value;
                }

                if (top.current.Left != null)
                {
                    queue.Enqueue((top.current.Left, top.current, top.parent));
                }

                if (top.current.Right != null)
                {
                    queue.Enqueue((top.current.Right, top.current, top.parent));
                }
            }

            return result;
        }
    }
}
