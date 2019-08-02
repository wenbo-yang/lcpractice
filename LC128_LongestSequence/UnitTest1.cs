using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC128_LongestSequence
{
    [TestClass]
    public class LongestSequenceTest
    {
        // two ways, first sort and loop
        // or use table to store leftKey and rightKey

        [TestMethod]
        public void GivenArray_FindLongestSequence_ShouldReturnTheLengthOfLongestSequence()
        {
            var array = new int[] { 100, 4, 200, 1, 3, 2 };

            int result = FindLongestConsecutiveSequence(array);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenAscendingArray_FindLongestSequence_ShouldReturnTheLengthOfLongestSequence()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6 };

            int result = FindLongestConsecutiveSequence(array);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenDescendingArray_FindLongestSequence_ShouldReturnTheLengthOfLongestSequence()
        {
            var array = new int[] { 6, 5, 4, 3, 2, 1 };

            int result = FindLongestConsecutiveSequence(array);

            Assert.IsTrue(result == 6);
        }


        private int FindLongestConsecutiveSequence(int[] array)
        {
            var leftKey = new Dictionary<int, int>();
            var rightKey = new Dictionary<int, int>();
            var longest = 1;

            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (!leftKey.ContainsKey(item))
                {
                    leftKey.Add(item, item);
                }

                if (!rightKey.ContainsKey(item))
                {
                    rightKey.Add(item, item);
                }

                if (rightKey.ContainsKey(item - 1))
                {
                    var result = MergeRight(leftKey, rightKey, item);

                    longest = result > longest ? result : longest;
                }

                if (leftKey.ContainsKey(item + 1))
                {
                    var result = MergeLeft(leftKey, rightKey, item);

                    longest = result > longest ? result : longest;
                }

                if (leftKey[item] != rightKey[item])
                {
                    var result = MergeLeftAndRight(leftKey, rightKey, item);

                    longest = result > longest ? result : longest;
                }

            }

            return longest;
        }

        private int MergeLeftAndRight(Dictionary<int, int> leftKey, Dictionary<int, int> rightKey, int item)
        {
            leftKey[rightKey[item]] = leftKey[item];
            rightKey[rightKey[item]] = rightKey[item];

            return leftKey[rightKey[item]] - rightKey[item] + 1;
        }

        private int MergeLeft(Dictionary<int, int> leftKey, Dictionary<int, int> rightKey, int item)
        {
            rightKey[leftKey[item + 1]] = item;
            leftKey[item] = leftKey[item + 1];

            return leftKey[item] - item + 1;
        }

        private int MergeRight(Dictionary<int, int> leftKey, Dictionary<int, int> rightKey, int item)
        {
            leftKey[rightKey[item - 1]] = item;
            rightKey[item] = rightKey[item - 1];

            return item - rightKey[item] + 1;
        }
    }
}
