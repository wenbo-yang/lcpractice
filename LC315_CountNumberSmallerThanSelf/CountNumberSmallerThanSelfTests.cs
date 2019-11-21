using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC315_CountNumberSmallerThanSelf
{
    [TestClass]
    // sort with index
    public class CountNumberSmallerThanSelfTests
    {
        [TestMethod]
        public void GivenArray_CountNumberSmallerThanSelf_ShouldReturnCorrectArray()
        {
            var input = new int[] { 1, 5, 2, 6, 1 };

            var result = CountNumberSmallerThanSelf(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 2, 1, 1, 0 }));
        }
        [TestMethod]
        public void GivenAnotherArray_CountNumberSmallerThanSelf_ShouldReturnCorrectArray()
        {
            var input = new int[] { 6, 5, 2, 1, 1 };

            var result = CountNumberSmallerThanSelf(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 4, 3, 2, 0, 0 }));
        }

        private int[] CountNumberSmallerThanSelf(int[] input)
        {
            var result = new int[input.Length];
            input.Reverse();

            BinaryTreeNode root = null;
            for (int i = 0; i < input.Length; i++)
            {
                root = InsertIntoBinaryTree(null, input[i]);
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                result[i] = GetFrequency(root, input[i]);
            }

            return result;
        }

        private BinaryTreeNode InsertIntoBinaryTree(BinaryTreeNode root, int value)
        {
            if (root == null)
            {
                return new BinaryTreeNode
                {
                    Value = value,
                    Frequency = 1
                };
            }

            if (root.Value == value)
            {
                root.Frequency++;
                return root;
            }

            if (root.Value < value)
            {
                root.Right = InsertIntoBinaryTree(root.Right, value);
            }
            else
            {
                root.Left = InsertIntoBinaryTree(root.Left, value);
                root.LeftCount++;
            }

            return root;
        }

        //private void InsertIntoBinraySearchTree(BinaryTreeNode root, BinaryTreeNode parent, int value)
        //{
        //    if (root == null)
        //    {
        //        if (parent.Value > value)
        //        {
        //            parent.Right = new BinaryTreeNode
        //            {
        //                Value = value,
        //                Frequency = 1
        //            };
        //        }
        //        else
        //        {
        //            parent.Left = new BinaryTreeNode
        //            {
        //                Value = value,
        //                Frequency = 1
        //            };
        //        }

        //        return;
        //    }

        //    if (root.Value == value)
        //    {
        //        root.Frequency++;

        //        return;
        //    }

        //    if (root.Value > value)
        //    {
        //        root.LeftCount++;
        //        InsertIntoBinraySearchTree(root.Left, parent, value);
        //        return;
        //    }

        //    InsertIntoBinraySearchTree(root.Right, parent, value);
        //}

        private int GetFrequency(BinaryTreeNode root, int value)
        {
            if (root.Value == value)
            {
                return root.LeftCount;        
            }

            if (root.Value > value)
            {
                return GetFrequency(root.Right, value);
            }

            return GetFrequency(root.Left, value);
        }

        public class BinaryTreeNode
        {
            public int Value { get; set; }
            public int Frequency { get; set; }
            public int LeftCount { get; set; }
            public BinaryTreeNode Left { get; set; }
            public BinaryTreeNode Right { get; set; }
        }

    }
}

