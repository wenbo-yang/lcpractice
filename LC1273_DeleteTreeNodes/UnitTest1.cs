using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LC1273_DeleteTreeNodes
{
    [TestClass]
    public class DeleteTreeNodesTest
    {
        [TestMethod]
        public void GivenTree_DeleteTreeNode_ShouldReturnNumberOfRemainingNodes()
        {
        }

        public class TreeNode
        {
            public int value;
            public List<TreeNode> children;
        }

        private int DeleteTreeNode(TreeNode root, int number)
        {
            var deleted = InOrderTraversal(root);

            return number - deleted.deletedNodes;
        }

        private (int sum, int numberOfNodes, int deletedNodes) InOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return (0, 0, 0);
            }

            (int sum, int numberOfNodes, int deletedNodes) sum = (0, 0, 0);

            foreach (var child in root.children)
            {
                var temp = InOrderTraversal(root);
                sum.sum += temp.sum;
                sum.numberOfNodes += temp.numberOfNodes;
                sum.deletedNodes += temp.deletedNodes;
            }

            var currentSum = sum.sum + root.value;

            if (currentSum == 0)
            {
                return (currentSum, sum.numberOfNodes + 1, sum.numberOfNodes + 1);
            }

            return (currentSum, sum.numberOfNodes + 1, sum.deletedNodes);
        }

        private TreeNode CreateTree(int[] parent, int[] values)
        {
            TreeNode root = null;
            var queue = new Queue<(int id, TreeNode parent)>();
            queue.Enqueue((-1, null));

            var startIndex = 1;
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (top.parent == null) // first
                {
                    top.parent = new TreeNode
                    {
                        value = values[0],
                        children = new List<TreeNode>()
                    };

                    root = top.parent;
                    top.id = 0;
                }

                var endIndex = GetIndexOf(parent, startIndex, top.id + 1);
                if (endIndex != -1)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        top.parent.children.Add(new TreeNode { value = values[i], children = new List<TreeNode>() });
                        queue.Enqueue((++top.id, top.parent.children.Last()));
                    }

                    startIndex = endIndex;
                }
            }

            return root;
        }

        private int GetIndexOf(int[] parent, int startIndex, int id)
        {
            for (int i = startIndex; i < id; i++)
            {
                if (parent[i] == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
