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
            Assert.IsTrue(result[0].Contains("aa"));
            Assert.IsTrue(result[1].Contains("a") && result[1].Contains("b"));
        }

        private List<List<string>> PalindromePartitioning(string input)
        {
            var result = new List<List<string>>();
            var dp = GenerateDP(input.Length);

            DeteminePalidrome(dp, input);

            MatrixDiagnoTrace(dp, input, result);

            return result;
        }

        private void MatrixDiagnoTrace(bool[][] dp, string input, List<List<string>> result)
        {
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                var position = new int[] { 0, i };
                result.Add(new List<string>());
                do
                {
                    if (dp[position[0]][position[1]])
                    {
                        result[result.Count - 1].Add(input.Substring(position[0], position[1] - position[0] + 1));
                    }

                    position[0]++; position[1]++;
                }
                while (CanMove(position, dp));

                if (result[result.Count - 1].Count == 0)
                {
                    result.RemoveAt(result.Count - 1);
                }
            }
        }

        private bool CanMove(int[] position, bool[][] dp)
        {
            return position[0] >= 0 && position[1] >= 0 && position[0] < dp.Length && position[1] < dp[0].Length;
        }

        private void DeteminePalidrome(bool[][] dp, string input)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = i; j < dp.Length; j++)
                {
                    if (i == j)
                    {
                        dp[i][j] = true;
                    }
                    else
                    {
                        dp[i][j] = input[i] == input[j] && (i + 1 <= j - 1 ? dp[i + 1][j - 1] : true);
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
