using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1379_FindTheCorrespondingNodeOfABinaryTree
{
    [TestClass]
    public class FindTheCorrespondingNodeOfABinaryTreeTestsFindTheCorrespondingNodeOfABinaryTreeTests
    {
        [TestMethod]
        public void GivenBinaryTreeAndClonedTree_FindCorrespondingNodeInClonedTree_ShouldReturnCorrectNode()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "7", "4", "3", null, null, "6", "19" });
            var clonedRoot = BinaryTree.CreateBinaryTreeBFS(new string[] { "7", "4", "3", null, null, "6", "19" });

            var target = root.Right;

            var result = FindTheCorrespondingNodeInClonedTree(root, clonedRoot, target);

            Assert.IsTrue(result == clonedRoot.Right && result.Value == target.Value);
        }

        private BinaryTreeNode FindTheCorrespondingNodeInClonedTree(BinaryTreeNode root, BinaryTreeNode clonedRoot, BinaryTreeNode target)
        {
            if (root == null || target == null)
            {
                return null;
            }

            var queue = new Queue<(BinaryTreeNode source, BinaryTreeNode cloned)>();
            queue.Enqueue((root, clonedRoot));
            
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (top.source == target)
                {
                    return top.cloned;
                }

                if (top.source.Left != null)
                {
                    queue.Enqueue((top.source.Left, top.cloned.Left));
                }

                if (top.source.Right != null)
                {
                    queue.Enqueue((top.source.Right, top.cloned.Right));
                }
            }

            return null;
        }
    }
}
