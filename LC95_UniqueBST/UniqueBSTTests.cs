
using CommonUtilities;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC95_UniqueBST
{
    [TestClass, Ignore]
    public class UniqueBSTTests
    {
        [TestMethod]
        public void GivenGeneratedTree_Clone_ShouldCloneTree()
        {
            var root = BinaryTree.CreateBinaryTree(new string[] { "1", null, "2", "3" });
            var newRoot = BinaryTree.CloneBinaryTree(root);

            Assert.IsTrue(newRoot.Value == root.Value);
            Assert.IsTrue(newRoot.Left == null);
            Assert.IsTrue(newRoot.Right.Value == root.Right.Value);
            Assert.IsTrue(newRoot.Right.Left.Value == root.Right.Left.Value);
        }

        [TestMethod]
        public void GivenInputNumbers_Generate_ShouldGenerateUniqueBinarySearchTrees()
        {
            var input = 3;

            List<BinaryTreeNode> results = GenerateUniqueBST(input);

            Assert.IsTrue(results.Count == 5);
        }

        private List<BinaryTreeNode> GenerateUniqueBST(int input)
        {
            var inputList = GenerateList(input);
            var results = new List<BinaryTreeNode>();

            for (int i = 1; i <= input; i++)
            {
                var root = new BinaryTreeNode { Value = i };
                Dfs(root, root, new List<int> { i }, input, results);
            }

            return results;
        }

        private void Dfs(BinaryTreeNode originalRoot, BinaryTreeNode currentRoot, List<int> inputList, int input, List<BinaryTreeNode> results)
        {
            if (inputList.Count == input)
            {
                var result = CloneBinaryTree(originalRoot);
                results.Add(result);
                return;
            }

            for (int i = inputList.Count; i <= input; i++)
            {
                var next = (inputList[inputList.Count - 1] + i) % input;
                inputList.Add(next);
                if (next >= currentRoot.Value)
                {
                    currentRoot.Right = new BinaryTreeNode() { Value = next };
                    Dfs(originalRoot, currentRoot.Left, inputList, input, results);
                    currentRoot.Right = null;
                }
                else
                {
                    currentRoot.Left = new BinaryTreeNode() { Value = next };
                    Dfs(originalRoot, currentRoot.Left, inputList, input, results);
                    currentRoot.Left = null;
                }
                inputList.RemoveAt(inputList.Count - 1);
            }
        }

        private BinaryTreeNode CloneBinaryTree(BinaryTreeNode originalRoot)
        {
            return BinaryTree.CloneBinaryTree(originalRoot);
        }

        private List<int> GenerateList(int input)
        {
            var inputList = new List<int>();

            for (int i = 1; i <= input; i++)
            {
                inputList.Add(i);
            }

            return inputList;
        }

        
    }
}
