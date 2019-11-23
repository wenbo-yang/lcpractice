using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public static class BinaryTree
    {
        public static BinaryTreeNode CreateBinaryTree(string[] input)
        {
            var index = 0;
            return CreatePreOrder(input, ref index);
        }

        public static BinaryTreeNode CreateBinaryTreeBFS(string[] input)
        {
            return CreateTreeBFS(input);
        }

        private static BinaryTreeNode CreateTreeBFS(string[] input)
        {
            
            var root = new BinaryTreeNode { Value = Convert.ToInt32(input[0]) };
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            var index = 1;
            while (index < input.Length)
            {
                var currentRoot = queue.Dequeue();
                var value = input[index++];
                if (value == null)
                {
                    currentRoot.Left = null;
                }
                else
                {
                    currentRoot.Left = new BinaryTreeNode() { Value = Convert.ToInt32(value) };
                    queue.Enqueue(currentRoot.Left);
                }

                if (index == input.Length)
                {
                    break;
                }

                value = input[index++];

                if (value == null)
                {
                    currentRoot.Right = null;
                }
                else
                {
                    currentRoot.Right = new BinaryTreeNode() { Value = Convert.ToInt32(value) };
                    queue.Enqueue(currentRoot.Right);
                }
            }

            return root;
        }

        public static BinaryTreeNode CloneBinaryTree(BinaryTreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            return new BinaryTreeNode()
            {
                Value = root.Value,
                Left = CloneBinaryTree(root.Left),
                Right = CloneBinaryTree(root.Right)
            };
        }

        private static BinaryTreeNode CreatePreOrder(string[] input, ref int index)
        {
            if (index >= input.Length || input[index] == null)
            {
                index++;
                return null;
            }

            return new BinaryTreeNode()
            {
                Value = Convert.ToInt32(input[index++]),
                Left = CreatePreOrder(input, ref index),
                Right = CreatePreOrder(input, ref index)
            };
        }
    }

    public class BinaryTreeNode
    {
        public int Value;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right; 
    }

}
