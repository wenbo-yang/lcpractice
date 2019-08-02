using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC199_BinaryTreeSideView
{
    [TestClass]
    public class BinaryTreeSideViewTests
    {
        [TestMethod]
        public void GivenBinaryTree_SideView_ShouldOutputSideNodes()
        {
            var root = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", null, "5", null, "4" });

            List<int> result = SideView(root);

            Assert.IsTrue(result.SequenceEqual(new List<int>() { 1, 3, 4 }));
        }

        private List<int> SideView(BinaryTreeNode root)
        {   
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            var queue = new Queue<Tuple<BinaryTreeNode, int>>();
            queue.Enqueue(new Tuple<BinaryTreeNode, int>(root, 0));
            var currentLevel = -1;
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (current.Item2 > currentLevel)
                {
                    result.Add(current.Item1.Value);
                    currentLevel = current.Item2;
                }

                if (current.Item1.Right != null) queue.Enqueue(new Tuple<BinaryTreeNode, int>(current.Item1.Right, currentLevel + 1));
                if (current.Item1.Left != null) queue.Enqueue(new Tuple<BinaryTreeNode, int>(current.Item1.Left, currentLevel + 1));
            }

            return result;
        }


    }
}
