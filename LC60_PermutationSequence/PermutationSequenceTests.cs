using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC60_PermutationSequence
{
    [TestClass]
    public class PermutationSequenceTests
    {
        [TestMethod]
        public void Given3NumberPermutation_FindSequence_ShouldReturnCorrectResult()
        {
            var n = 3;
            var k = 3;

            string output = FindSequence(n, k);
            Assert.IsTrue(output == "213");
        }

        [TestMethod]
        public void Given3NumberPermutationWithK1_FindSequence_ShouldReturnCorrectResult()
        {
            var n = 3;
            var k = 1;

            string output = FindSequence(n, k);
            Assert.IsTrue(output == "123");
        }

        [TestMethod]
        public void Given3NumberPermutationWithK2_FindSequence_ShouldReturnCorrectResult()
        {
            var n = 3;
            var k = 2;

            string output = FindSequence(n, k);
            Assert.IsTrue(output == "132");
        }


        [TestMethod]
        public void Given4NumberPermutationWithK9_FindSequence_ShouldReturnCorrectResult()
        {
            var n = 4;
            var k = 9;

            string output = FindSequence(n, k);
            Assert.IsTrue(output == "2314");
        }

        [TestMethod]
        public void Given4NumberPermutationWithK24_FindSequence_ShouldReturnCorrectResult()
        {
            var n = 4;
            var k = 24;

            string output = FindSequence(n, k);
            Assert.IsTrue(output == "4321");
        }

        // use divide;
        private string FindSequence(int n, int k)
        {
            var factorialTable = GenerateFactorialTable(n);
            var remainer = GeneratePermSet(n);

            return Dfs(n, k - 1, factorialTable, remainer, new List<char>());
        }

        private string Dfs(int n, int k, Dictionary<int, int> table, List<int> remainer, List<char> currentResult)
        {
            if (remainer.Count == 1)
            {
                currentResult.Add(remainer[0].ToString()[0]);
                return new string(currentResult.ToArray());
            }

            var current = k / table[n - 1];
            var next = k % table[n - 1];

            currentResult.Add(remainer[current].ToString()[0]); // this is the first digit 
            remainer.RemoveAt(current);
            return Dfs(n - 1, next, table, remainer, currentResult);
        }

        private List<int> GeneratePermSet(int n)
        {
            var set = new List<int>();

            for (int i = 0; i < n; i++)
            {
                set.Add(i + 1);
            }

            return set;
        }

        private Dictionary<int, int> GenerateFactorialTable(int n)
        {
            var table = new Dictionary<int, int>();

            var prev = 1;
            for (int i = 1; i <= n; i++)
            {
                var current = prev * i;
                table.Add(i, current);
                prev = current;
            }

            return table;
        }
    }
}
