using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1380_LuckyNumbersInAMatrix
{
    [TestClass]
    public class LuckyNumbersInAMatrixTests
    {
        [TestMethod]
        public void GivenAMatrix_FindLuckNumbers_ShouldReturnArrayOfLuckyNumbers()
        {
            var mat = new int[][] { new int[] { 3, 7, 8 }, new int[] { 9, 11, 13 }, new int[] { 15, 16, 17 } };
            var result = FindLuckyNumbers(mat);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 15 }));
        }

        private List<int> FindLuckyNumbers(int[][] mat)
        {
            var result = new List<int>();

            var row = new (int value, int c)[mat.Length];
            for (int i = 0; i < row.Length; i++)
            {
                row[i].value = int.MaxValue;
            }

            var col = new (int value, int r)[mat[0].Length];
            for (int i = 0; i < col.Length; i++)
            {
                col[i].value = int.MinValue;
            }

            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < col.Length; j++)
                {
                    row[i] = mat[i][j] < row[i].value ? (mat[i][j], j) : row[i];
                    col[j] = mat[i][j] > col[j].value ? (mat[i][j], i) : col[j];
                }
            }

            var table = new Dictionary<int, int>();
            foreach (var c in col)
            {
                table.Add(c.value, c.r);
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (table.ContainsKey(row[i].value) && table[row[i].value] == i)
                {
                    result.Add(row[i].value);
                }
            }

            return result;
        }
    }
}
