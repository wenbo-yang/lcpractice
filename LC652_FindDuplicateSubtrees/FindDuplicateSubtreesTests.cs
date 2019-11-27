using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC652_FindDuplicateSubtrees
{
    [TestClass]
    public class FindDuplicateSubtreesTests
    {
        [TestMethod]
        public void GivenOneTree_FindDuplicateSubTree_ShouldReturnDuplicatedSubtree()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] {"1", "2", "3", "5", null,"2", "4", null,null, "4"});
            var duplicatedTree = FindDuplicateSubtree(root);

            Assert.IsTrue(duplicatedTree.Count == 2);
        }

        private List<BinaryTreeNode> FindDuplicateSubtree(BinaryTreeNode root)
        {
            var uniqueTrees = new HashSet<string>();
            var result = new List<BinaryTreeNode>();

            SerializeAndFindResults(root, uniqueTrees, result);

            return result;
        }

        private string SerializeAndFindResults(BinaryTreeNode root, HashSet<string> uniqueTrees, List<BinaryTreeNode> result)
        {
            if (root == null)
            {
                return "null";
            }

            var left = SerializeAndFindResults(root.Left, uniqueTrees, result);
            var right = SerializeAndFindResults(root.Right, uniqueTrees, result);

            var serializedTree = root.Value.ToString() + "," + left + "," + right;

            if (uniqueTrees.Contains(serializedTree))
            {
                result.Add(root);
            }

            uniqueTrees.Add(serializedTree);

            return serializedTree;
        }
    }
}
