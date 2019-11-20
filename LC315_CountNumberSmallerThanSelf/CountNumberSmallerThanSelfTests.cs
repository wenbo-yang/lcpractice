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


            return result;
        }

        private void InsertIntoBinraySearchTree(BinaryTreeNode root, int value)
        {
            throw new NotImplementedException();
        }

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

