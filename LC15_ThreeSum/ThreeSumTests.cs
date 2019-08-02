using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC15_ThreeSum
{
    [TestClass]
    public class ThreeSumTests
    {
        // reduce to two sum
        // 
        [TestMethod]
        public void GivenSortedArray_TwoSum_ShouldReturnListOfSolutions()
        {
            var list = new List<int> { 1, 2, 3, 4, 5};

            var result = TwoSumResults(list, 6);

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void GivenSortedArray_ThreeSum_ShouldReturnListOfSolutions()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            HashSet<Tuple<int, int, int>> result = ThreeSumResults(list, 6);

            var tupleArray = new Tuple<int, int, int>[1];
            result.CopyTo(tupleArray, 0);
            Assert.IsTrue(tupleArray.Length == 1);
            Assert.IsTrue(tupleArray[0].Item1 == 1);
            Assert.IsTrue(tupleArray[0].Item2 == 2);
            Assert.IsTrue(tupleArray[0].Item3 == 3);
        }

        private HashSet<Tuple<int, int, int>> ThreeSumResults(List<int> list, int targetSum)
        {
            var result = new HashSet<Tuple<int, int, int>>(); // enforce uniqueness

            list.Sort();

            while (list.Count > 2)
            {
                var currentValue = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);

                var twoSumResults = TwoSumResults(list, targetSum - currentValue);

                if (twoSumResults.Count > 0)
                {
                    foreach (var item in twoSumResults)
                    {
                        var resultEntry = new Tuple<int, int, int>(list[item.Item1], list[item.Item2], currentValue);

                        if (!result.Contains(resultEntry))
                        {
                            result.Add(resultEntry);
                        }
                    }
                }
            }

            return result;
        }

        private List<Tuple<int, int>> TwoSumResults(List<int> sortedArray, int targetSum)
        {
            var left = 0;
            var right = sortedArray.Count - 1;

            var result = new List<Tuple<int, int>>();

            while (left < right)
            {
                if (sortedArray[left] + sortedArray[right] == targetSum)
                {
                    result.Add(new Tuple<int, int>(left, right));
                    left++;
                    right--;
                    continue;
                }

                if (sortedArray[left] + sortedArray[right] > targetSum)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return result;
        }

        private int BinarySearchForResults(List<int> sortedArray, int target)
        {
            var result = -1;

            var left = 0;
            var right = sortedArray.Count - 1;

            var p = (right + left) / 2;

            do
            {
                if (sortedArray[p] == target)
                {
                    result = p;
                    break;
                }

                if (sortedArray[p] > target)
                {
                    right = p;
                }
                else
                {
                    left = p;
                }

                p = (right + left) / 2;
            }
            while (left != right);

            return result;
        }
    }
}
