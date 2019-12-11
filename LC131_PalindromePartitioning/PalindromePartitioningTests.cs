using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC131_PalindromePartitioning
{
    [TestClass]
    public class PalindromePartitioningTests
    {
        [TestMethod]
        public void GivenString_ParlindromePartition_ShouldReturnListOfParlindromes()
        {
            var input = "aab";

            var result = PalindromePartitioning(input);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Contains("aa") && result[0].Contains("b"));
            Assert.IsTrue(result[1].Contains("a") && result[1].Contains("b"));
        }

        [TestMethod]
        public void GivenAnotherString_ParlindromePartition_ShouldReturnListOfParlindromes()
        {
            var input = "caaa";

            var result = PalindromePartitioning(input);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Contains("aaa") && result[0].Contains("c"));
            Assert.IsTrue(result[1].Contains("c") && result[1].Contains("aa"));
            Assert.IsTrue(result[1].Contains("c") && result[1].Contains("a"));
        }

        private List<List<string>> PalindromePartitioning(string input)
        {
            var result = new List<List<string>>();
            var dp = GenerateDP(input.Length);
            InitializeDP(dp);
            DeteminePalidrome(dp, input);

            for (int i = input.Length; i >= 1; i--)
            {
                GetParlidromePartitioningWithMinLength(dp, input, i, result);
            }
           
            return result;
        }

        private void InitializeDP(bool[][] dp)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i][i] = true;
            }
        }

        private void GetParlidromePartitioningWithMinLength(bool[][] dp, string input, int minLength, List<List<string>> result)
        {
            result.Add(new List<string>());
            for (int i = 0; i < input.Length; i++)
            {
                if (i + minLength <= input.Length && dp[i][i + minLength - 1])
                {
                    result[result.Count - 1].Add(input.Substring(i, minLength));
                    i = i + minLength - 1;
                }
                else
                {
                    result[result.Count - 1].Add(input[i].ToString());
                }
            }

            if (string.IsNullOrEmpty(result[result.Count - 1].Find(x => x.Length == minLength)))
            {
                result.RemoveAt(result.Count - 1);
            }
        }

        private void DeteminePalidrome(bool[][] dp, string input)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = i; j < dp.Length; j++)
                {
                    if (i != j)
                    {
                        dp[i][j] = input[i] == input[j] && (i == j - 1 ? true : dp[i + 1][j - 1]);
                    }
                }
            }
        }

        private bool[][] GenerateDP(int size)
        {
            var dp = new bool[size][];

            for (int i = 0; i < size; i++)
            {
                dp[i] = new bool[size];
            }

            return dp;
        }
    }
}
