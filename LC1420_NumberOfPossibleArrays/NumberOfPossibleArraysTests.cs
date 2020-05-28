using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1420_NumberOfPossibleArrays
{
    [TestClass]
    public class NumberOfPossibleArraysTests
    {
        [TestMethod]
        public void GivenArraySizeMaximumAndKComparisons_NumberOfPossibleArrays_ShouldReturnCorrectResult()
        {
            var n = 2; var m = 3; var k = 1;
            var result = NumberOfPossibleArrays(n, m, k);

            Assert.IsTrue(result == 6);
        }

        private int NumberOfPossibleArrays(int n, int m, int k)
        {
            var df = GenerateDynamicFunction(n, m, k);
            InitializeDf(df);

            uint mod = 1000000007;
            RunDf(df, mod);
            
            return (int)(df[n][m][k] % mod);
        }

        private void RunDf(uint[][][] df, uint mod)
        {
            for (int k = 2; k < df[0][0].Length; k++)
            {
                for (int i = k; i < df.Length; i++)
                {
                    for (int j = k; j < df[0].Length; j++)
                    {
                        var last = df[i][j - 1][k] == 0 ? df[i - 1][j][k -1] : df[i][j - 1][k];
                        df[i][j][k] = (last * (uint)j ) % mod; 
                    }
                }
            }
        }

        private void InitializeDf(uint[][][] df)
        {
            var k = 1;

            for (uint i = 1; i < df.Length; i++)
            {
                df[i][1][k] = 1;
            }

            for (uint i = 1; i < df[0].Length; i++)
            {
                df[1][i][k] = i;
            }

            for (uint i = 2; i < df.Length; i++)
            {
                for (uint j = 2; j < df[0].Length; j++)
                {
                    df[i][j][k] = df[i - 1][j][k] + df[i][j - 1][k];
                }
            }
        }

        private uint[][][] GenerateDynamicFunction(int n, int m, int k)
        {
            var df = new uint[n + 1][][];
            for (int i = 0; i < df.Length; i++)
            {
                df[i] = new uint[m + 1][];
                for (int j = 0; j < df[i].Length; j++)
                {
                    df[i][j] = new uint[k + 1];
                }
            }

            return df;
        }
    }
}
