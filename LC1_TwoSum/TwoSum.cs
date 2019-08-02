using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoSum
{
    [TestClass]
    public class TwoSumTest
    {
        [TestMethod]
        public void GivenArrayWithTargetSum_TwoSum_ShouldReturnIndices()
        {
            var inputArray = new int[] { 2, 7, 11, 15 };

            var retVal = TwoSum(inputArray, 9);

            retVal.Item1.Should().Be(0);
            retVal.Item2.Should().Be(1);
        }

        [TestMethod]
        public void GivenArrayWithInvalidTargetSum_TwoSum_ShouldReturnNegativeIndices()
        {
            var inputArray = new int[] { 2, 7, 11, 15 };

            var retVal = TwoSum(inputArray, 14);

            retVal.Item1.Should().Be(-1);
            retVal.Item2.Should().Be(-1);
        }

        [TestMethod]
        public void GivenArrayHasTargetSum_TwoSumBool_ShouldReturnTrue()
        {
            var inputArray = new int[] { 2, 7, 11, 15 };

            var retVal = TwoSumBool(inputArray, 9);

            retVal.Should().BeTrue();
        }

        [TestMethod]
        public void GivenArrayHasInvalidTargetSum_TwoSumBool_ShouldReturnFalse()
        {
            var inputArray = new int[] { 2, 7, 11, 15 };

            var retVal = TwoSumBool(inputArray, 14);

            retVal.Should().BeFalse();
        }

        [TestMethod]
        public void Doc_GivenArrayHasLessThanTwo_TwoSumBool_ShouldReturnFalse()
        {
            var inputArray = new int[] { 2 };

            var retVal = TwoSumBool(inputArray, 12);

            retVal.Should().BeFalse();
        }

        [TestMethod]
        public void Doc_GivenArrayHasLessThanTwo_TwoSum_ShouldReturnNegativeIndices()
        {
            var inputArray = new int[] {};

            var retVal = TwoSum(inputArray, 12);

            retVal.Item1.Should().Be(-1);
            retVal.Item2.Should().Be(-1);
        }

        private Tuple<int, int> TwoSum(int[] inputArray, int targetSum)
        {
            if (inputArray == null || inputArray.Length < 2)
            {
                return new Tuple<int, int>(-1, -1);
            }

            var table = new Dictionary<int, int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (table.ContainsKey(targetSum - inputArray[i]))
                {
                    return new Tuple<int, int>(table[targetSum - inputArray[i]], i);
                }
                else
                {
                    table.Add(inputArray[i], i);
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        private bool TwoSumBool(int[] inputArray, int targetSum)
        {
            var retVal = false;

            if (inputArray == null || inputArray.Length < 2)
            {
                return retVal;
            }

            var set = new HashSet<int>();

            foreach (var item in inputArray)
            {
                if (set.Contains(targetSum - item))
                {
                    retVal = true;
                    break;
                }
                else
                {
                    set.Add(item);
                }
            }

            return retVal;
        }
    }
}
