using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC108_ConvertSortedArrayToBST
{
    [TestClass]
    public class ConvertSortedArrayToBstTests
    {
        [TestMethod]
        public void GivenSortedArray_Convert_ShouldConvertToBST()
        {
            var input = new int[] { -10, -3, 0, 5, 9 };

            BinaryTreeNode root = ConvertToBST(input);

            Assert.IsTrue(root.Value == 0);
            Assert.IsTrue(root.Left.Value == -10);
            Assert.IsTrue(root.Left.Right.Value == -3);
            Assert.IsTrue(root.Right.Value == 5);
            Assert.IsTrue(root.Right.Right.Value == 9);
        }

        [TestMethod]
        public void GivenSortedArrayWithDupes_Convert_ShouldConvertToBST()
        {
            var input = new int[] { -10, -3, -3, 0, 5, 9 };

            BinaryTreeNode root = ConvertToBST(input);

            Assert.IsTrue(root.Value == 0);
            Assert.IsTrue(root.Left.Value == -10);
            Assert.IsTrue(root.Left.Right.Value == -3);
            Assert.IsTrue(root.Left.Right.Right.Value == -3);
            Assert.IsTrue(root.Right.Value == 5);
            Assert.IsTrue(root.Right.Right.Value == 9);
        }

        [TestMethod]
        public void GivenArrayOfDups_ConvertToUniqueList_ShouldConvertToUniqueList()
        {
            var input = new int[] { 0, 0, 1, 1, 1 };

            var list = ConvertSortedArrayToUniqueValueList(input);

            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0].Item1 == 0);
            Assert.IsTrue(list[0].Item2 == 2);
            Assert.IsTrue(list[1].Item1 == 1);
            Assert.IsTrue(list[1].Item2 == 3);
        }

        private BinaryTreeNode ConvertToBST(int[] input)
        {
            var list = ConvertSortedArrayToUniqueValueList(input);
            return ConvertToBSTHelper(list, 0, list.Count - 1);
        }

        private BinaryTreeNode ConvertToBSTHelper(List<Tuple<int, int>> inputList, int lower, int upper)
        {
            var mid = (upper + lower) / 2;

            var root = new BinaryTreeNode() { Value = inputList[mid].Item1 };
            var tempRight = root;

            for (int i = 1; i < inputList[mid].Item2; i++)
            {
                tempRight.Right = new BinaryTreeNode() { Value = inputList[mid].Item1 };
                tempRight = tempRight.Right;
            }

            if (lower >= upper)
            {
                return root;
            }

            root.Left = ConvertToBSTHelper(inputList, lower, mid - 1);
            tempRight.Right = ConvertToBSTHelper(inputList, mid + 1, upper);

            return root;
        }

        private List<Tuple<int, int>> ConvertSortedArrayToUniqueValueList(int[] input)
        {
            var result = new List<Tuple<int, int>>();

            var left = 0;
            var right = 0;

            while (right < input.Length)
            {
                if (input[right] > input[left])
                {
                    result.Add(new Tuple<int, int>(input[left], right - left));

                    left = right;
                }

                right++;
            }

            result.Add(new Tuple<int, int>(input[left], right - left));

            return result;
        }
    }
}
