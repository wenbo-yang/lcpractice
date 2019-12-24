using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1278_PalindromePartitioning
{
    [TestClass]
    public class PalindromePartitioningTests
    {
        [TestMethod]
        public void GivenSourceStringnAndNumberOfPartitions_PalindromePartitioning_ShouldReturnCorrectCost()
        {
            var source = "abc";
            var k = 2;

            var result = PalidromePartitioning(source, k);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherSourceStringnAndNumberOfPartitions_PalindromePartitioning_ShouldReturnCorrectCost()
        {
            var source = "babc";
            var k = 2;

            var result = PalidromePartitioning(source, k);

            Assert.IsTrue(result == 0);
        }

        private int PalidromePartitioning(string source, int k)
        {
            var palidromeCostTable = CalculateParlindromeCost(source);

            var minPartitioningCost = new Dictionary<(int start, int k), int>();

            GetPartitioningCost(source, 0, k, minPartitioningCost, palidromeCostTable);
            
            return minPartitioningCost[(0, k)];
        }

        private int GetPartitioningCost(string source, int start, int k, Dictionary<(int start, int k), int> minPartitioningCost, Dictionary<(int start, int end), int> palidromeCostTable)
        {
            if (k == 1)
            {
                if (!minPartitioningCost.ContainsKey((start, 0)))
                {
                    minPartitioningCost.Add((start, 0), palidromeCostTable[(start, source.Length - 1)]);
                }

                return palidromeCostTable[(start, source.Length - 1)];
            }

            if (minPartitioningCost.ContainsKey((start, k)))
            {
                return minPartitioningCost[(start, k)];
            }
            var maxCharPerPartition = source.Length / k + 1;

            var result = int.MaxValue;
            for (int i = start; i < maxCharPerPartition; i++)
            {
                result = Math.Min(result, palidromeCostTable[(start, start + i)] + GetPartitioningCost(source, i + 1, k - 1, minPartitioningCost, palidromeCostTable));
            }

            minPartitioningCost.Add((start, k), result);

            return result;
        }

        private Dictionary<(int start, int end), int> CalculateParlindromeCost(string source)
        {
            var parlindromeCost = new Dictionary<(int start, int end), int>();

            for (int i = 0; i < source.Length; i++)
            {
                parlindromeCost.Add((i, i), 0);
            }

            for (int i = 1; i < source.Length; i++)
            {
                parlindromeCost.Add((i - 1, i), source[i - 1] == source[i] ? 0:1);
            }

            for (int i = 2; i < source.Length; i++)
            {
                for (int j = 0; j < source.Length - i; j++)
                {
                    var cost = source[j] == source[j + i] ? 0 : 1;
                    parlindromeCost.Add((j, j + i), parlindromeCost[(j + 1, j + i - 1)] + cost);
                }
            }

            return parlindromeCost;
        }
    }
}
