using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC742_ClosestValueToTarget
{
    [TestClass]
    public class ClosestValueToTargetLeafNodeTests
    {
        [TestMethod]
        public void GivenTreeAndTarget_GetClosestLeafNodeShouldReturnLeafNode()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "3", "2" });
            var target = 1;

            var result = GetClosetLeafNode(root, target);

            Assert.IsTrue(result.Value == 3 || result.Value == 2);
        }

        private BinaryTreeNode GetClosetLeafNode(BinaryTreeNode root, int target)
        {
            var queue = new Queue<Tuple<BinaryTreeNode, int>>();
            Tuple<BinaryTreeNode, int> currentTarget = null;

            queue.Enqueue(new Tuple<BinaryTreeNode, int>(root, 0));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (IsLeafNode(top.Item1))
                {
                    if (currentTarget == null)
                    {
                        currentTarget = top;
                    }
                    else
                    {
                        if (Math.Abs(top.Item1.Value - target) < Math.Abs(currentTarget.Item1.Value - target))
                        {
                            currentTarget = top;
                        }
                        else if (Math.Abs(top.Item1.Value - target) == Math.Abs(currentTarget.Item1.Value - target))
                        {
                            currentTarget = top.Item2 < currentTarget.Item2 ? top : currentTarget;
                        }
                    }
                }
                else
                {
                    if (top.Item1.Left != null) queue.Enqueue(new Tuple<BinaryTreeNode, int>(top.Item1.Left, top.Item2 + 1));
                    if (top.Item1.Right != null) queue.Enqueue(new Tuple<BinaryTreeNode, int>(top.Item1.Right, top.Item2 + 1));
                }
            }

            return currentTarget.Item1;
        }

        private bool IsLeafNode(BinaryTreeNode root)
        {
            return root.Left == null && root.Right == null;
        }
    }
}
