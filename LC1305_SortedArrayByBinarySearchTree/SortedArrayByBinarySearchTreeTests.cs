using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1305_SortedArrayByBinarySearchTree
{
    [TestClass]
    public class SortedArrayByBinarySearchTreeTests
    {
        [TestMethod]
        public void GivenTwoBinarySearchTree_GetSortedArray_ShouldReturnCorrectAnswer()
        {
            var root1 = BinaryTree.CreateBinaryTreeBFS(new string[] { "2", "1", "4" });
            var root2 = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "0", "3" });

            var result = GetSortedArray(root1, root2);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 0, 1, 1, 2, 3, 4 }));
        }

        private List<int> GetSortedArray(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            var list1 = new Queue<int>();
            var list2 = new Queue<int>();

            PreorderTraversal(root1, list1);
            PreorderTraversal(root2, list2);

            var result = new List<int>();
            while (list1.Count != 0 || list2.Count != 0)
            {
                var smaller = GetSmaller(list1, list2);
                result.Add(smaller);
            }

            return result;
        }

        private int GetSmaller(Queue<int> list1, Queue<int> list2)
        {
            if (list1.Count != 0 && list2.Count != 0)
            {
                if (list1.Peek() < list2.Peek())
                {
                    return list1.Dequeue();
                }
                else
                {
                    return list2.Dequeue();
                }
            }
            else if (list1.Count != 0)
            {
                return list1.Dequeue();
            }

            return list2.Dequeue();
        }

        private void PreorderTraversal(BinaryTreeNode root, Queue<int> list)
        {
            if (root == null)
            {
                return;
            }

            PreorderTraversal(root.Left, list);
            list.Enqueue(root.Value);
            PreorderTraversal(root.Right, list);
        }
    }
}
