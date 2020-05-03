using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1387_SortIntegersbyPowerValue
{
    [TestClass]
    public class SortIntegersbyPowerValueTests
    {
        [TestMethod]
        public void GivenIntegerLowerAndUpperValueAndK_GetSortedPowerValue_ShouldReturnTheKThValue()
        {
            var low = 12; var high = 15; var k = 2;

            var result = GetSortedPowerValue(low, high, k);

            Assert.IsTrue(result == 13);
        }

        [TestMethod]
        public void GivenAnotherRangeUpperValueAndK_GetSortedPowerValue_ShouldReturnTheKThValue()
        {
            var low = 1; var high = 1; var k = 1;

            var result = GetSortedPowerValue(low, high, k);

            Assert.IsTrue(result == 1);
        }

        private int GetSortedPowerValue(int low, int high, int k)
        {
            var table = new Dictionary<int, int>();

            var maxHeap = new MaxHeap<(int powerValue, int value)>();

            for (int i = low; i <= high; i++)
            {
                var powerValue = GetPowerValue(i, table);

                if (maxHeap.Count == k)
                {
                    if (powerValue < maxHeap.Peek().powerValue)
                    {
                        maxHeap.Pop();
                        maxHeap.Add((powerValue, i));
                    }
                }
                else
                {
                    maxHeap.Add((powerValue, i));
                }
            }

            return maxHeap.Peek().value;
        }

        private int GetPowerValue(int target, Dictionary<int, int> table)
        {
            if (table.ContainsKey(target))
            {
                return table[target];
            }

            if (target == 1)
            {
                return 1;
            }

            if (target % 2 == 0)
            {
                table.Add(target, GetPowerValue(target / 2, table) + 1);
            }
            else
            {
                table.Add(target, GetPowerValue(target * 3 + 1, table) + 1);
            }

            return table[target];
        }
    }
}
