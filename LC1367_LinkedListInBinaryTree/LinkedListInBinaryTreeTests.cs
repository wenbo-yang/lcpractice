using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1367_LinkedListInBinaryTree
{
    [TestClass]
    public class LinkedListInBinaryTreeTests
    {
        [TestMethod]
        public void GivenLinkedListInArrayFormAndBinaryTree_()
        {
            var head = new LinkedListBuilder().ConstructFromArray(new int[] { 4, 2, 8 }).Head;
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "4", "4", null, "2", "2", null, "1", null, "6", "8", null, null, null, null, "1", "3" });

            var result = IsLinkedListSubPath(head, root);

            Assert.IsTrue(result);
        }

        private bool IsLinkedListSubPath(ListNode head, BinaryTreeNode root)
        {
            if (root == null)
            {
                return false;
            }


            return IsPath(head, root) || IsLinkedListSubPath(head, root.Left) || IsLinkedListSubPath(head, root.Right);
        }

        private bool IsPath(ListNode head, BinaryTreeNode root)
        {
            if (head == null)
            {
                return true;
            }

            if (root == null)
            {
                return false;
            }

            if (head.Value != root.Value)
            {
                return false;
            }


            return IsPath(head.Next, root.Left) || IsPath(head.Next, root.Right);
        }
    }
}
