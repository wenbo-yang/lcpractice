using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC572_IsSubtree
{
    [TestClass]
    public class IsSubtreeTest
    {
        [TestMethod]
        public void GivenTreeAndItsSubtree_IsSubTree_ShouldReturnTrue()
        {
            var t1 = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "4", "5", "1", "2" });
            var t2 = BinaryTree.CreateBinaryTreeBFS(new string[] { "4", "1", "2" });

            var result = IsT2SubtreeOfT1(t1, t2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTreeAndInvalidSubtree_IsSubTree_ShouldReturnFalse()
        {
            var t1 = BinaryTree.CreateBinaryTreeBFS(new string[] { "3", "4", "5", "1", "2", null, null, null, null, "0"});
            var t2 = BinaryTree.CreateBinaryTreeBFS(new string[] { "4", "1", "2" });

            var result = IsT2SubtreeOfT1(t1, t2);

            Assert.IsFalse(result);
        }

        private bool IsT2SubtreeOfT1(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t2 == null)
            {
                return true;
            }

            if (t1 == null)
            {
                return false;
            }

            var isSubtree = false;

            if (t1.Value == t2.Value)
            {
                isSubtree = IsT2SubtreeOfT1Helper(t1, t2);
            }

            return isSubtree || IsT2SubtreeOfT1(t1.Left, t2) || IsT2SubtreeOfT1(t1.Right, t2);
        }

        private bool IsT2SubtreeOfT1Helper(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }

            if(t1 == null || t2 == null)
            {
                return false;
            }

            var left = IsT2SubtreeOfT1Helper(t1.Left, t2.Left);
            var right = IsT2SubtreeOfT1Helper(t1.Right, t2.Right);

            var isHeadMatching = t1.Value == t2.Value;

            var matching = left && right && isHeadMatching;

            return matching;
        }
    }
}
