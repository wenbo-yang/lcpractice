using System;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1430_ValidRootToLeafPath
{
    [TestClass]
    public class ValidRootToLeafPathTests
    {
        [TestMethod]
        public void GivenTreeAndArray_HasValidRootToLeafPath_ShouldReturnCorrectAnswer()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "0", "1", "0", "0", "1", "0", null, null, "1", "0", "0" });
            var arr = new int[] { 0, 1, 0, 1 };
            var result = HasValidRootToLeafPath(root, arr);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTreeAndAnotherArray_HasValidRootToLeafPath_ShouldReturnCorrectAnswer()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "0", "1", "0", "0", "1", "0", null, null, "1", "0", "0" });
            var arr = new int[] { 0, 0, 1 };
            var result = HasValidRootToLeafPath(root, arr);

            Assert.IsFalse(result);
        }

        private bool HasValidRootToLeafPath(BinaryTreeNode root, int[] arr)
        {
            return HasValidRootToLeafPathHelper(root, arr, 0);
        }

        private bool HasValidRootToLeafPathHelper(BinaryTreeNode root, int[] arr, int index)
        {
            if (root == null)
            {
                if (index == arr.Length)
                {
                    return true;
                }

                return false;
            }

            if (root.Value == arr[index])
            {
                return HasValidRootToLeafPathHelper(root.Left, arr, index + 1) || HasValidRootToLeafPathHelper(root.Right, arr, index + 1);
            }

            return false;
        }
    }
}
