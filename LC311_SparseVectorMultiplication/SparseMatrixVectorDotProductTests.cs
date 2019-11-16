using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC311_SparseMatrixVectorMultiplication
{
    [TestClass]
    public class SparseVectorDotProductTests
    {
        [TestMethod]
        public void GivenTwoSparseVectors_DotProduct_ShouldReturnCorrectDotProduct()
        {
            var vector1 = new int[] { 0, 2, 0, 2, 0, 0, 3, 0, 0, 4 };
            var vector2 = new int[] { 0, 0, 0, 0, 5, 0, 2, 0, 0, 8 };

            var result = DotProductHash(vector1, vector2);

            Assert.IsTrue(result == 38);
        }

        [TestMethod]
        public void GivenTwoListTuplesSparseVectors_DotProduct_ShouldReturnCorrectDotProduct()
        {
            var vector1 = new List<Tuple<int, int>> { new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 2), new Tuple<int, int>(6, 3), new Tuple<int, int>(9, 4) };
            var vector2 = new List<Tuple<int, int>> { new Tuple<int, int>(4, 5), new Tuple<int, int>(6, 2), new Tuple<int, int>(9, 8) };

            var result = DotProductList(vector1, vector2);

            Assert.IsTrue(result == 38);
        }

        [TestMethod]
        public void GivenTwoSparseMatrices_DotProduct_ShouldReturnCorrectMatrix()
        {
            var mat1 = new int[][] { new int[] { 1, 0, 0},
                                     new int[] { -1, 0, 3}};

            var mat2 = new int[][] { new int[] { 7, 0, 0},
                                     new int[] { 0, 0, 0},
                                     new int[] { 0, 0, 1}};

            var result = Multiply(mat1, mat2);

            Assert.IsTrue(result[0].SequenceEqual(new int[] { 7, 0, 0 }));
            Assert.IsTrue(result[1].SequenceEqual(new int[] { -7, 0, 3 }));
        }

        private int[][] Multiply(int[][] mat1, int[][] mat2)
        {
            var result = GenerateResultMat(mat1);

            var mat1Row = GenerateSparseMatrixRowFirst(mat1);
            var mat2Col = GenerateSparseMatrixColFirst(mat2);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = DotProductList(mat1Row[i], mat2Col[j]);
                }
            }

            return result;
        }

        private int[][] GenerateResultMat(int[][] mat1)
        {
            var result = new int[mat1.Length][];

            for (int i = 0; i < mat1.Length; i++)
            {
                result[i] = new int[mat1[0].Length];
            }

            return result;
        }

        private List<List<Tuple<int, int>>> GenerateSparseMatrixRowFirst(int[][] mat1)
        {
            var result = new List<List<Tuple<int, int>>>();

            for (int i = 0; i < mat1.Length; i++)
            {
                result.Add(new List<Tuple<int, int>>());
                for (int j = 0; j < mat1[0].Length; j++)
                {
                    if (mat1[i][j] != 0)
                    {
                        result[i].Add(new Tuple<int, int>(j, mat1[i][j]));
                    }
                }
            }

            return result;
        }

        private List<List<Tuple<int, int>>> GenerateSparseMatrixColFirst(int[][] mat2)
        {
            var result = new List<List<Tuple<int, int>>>();


            for (int i = 0; i < mat2[0].Length; i++)
            {
                result.Add(new List<Tuple<int, int>>());
                for (int j = 0; j < mat2.Length; j++)
                {
                    if (mat2[j][i] != 0)
                    {
                        result[i].Add(new Tuple<int, int>(j, mat2[j][i]));
                    }
                }
            }

            return result;
        }

        private int DotProductList(List<Tuple<int, int>> vector1, List<Tuple<int, int>> vector2)
        {
            var product = 0;

            var smaller = vector1.Count < vector2.Count ? vector1 : vector2;
            var bigger = vector1.Count >= vector2.Count ? vector1 : vector2;

            var biggerPointer = 0;

            for (int i = 0; i < smaller.Count; i++)
            {
                while (biggerPointer < bigger.Count)
                {
                    if (bigger[biggerPointer].Item1 == smaller[i].Item1)
                    {
                        product += bigger[biggerPointer].Item2 * smaller[i].Item2;
                    }
                    else if (bigger[biggerPointer].Item1 > smaller[i].Item1)
                    {
                        break;
                    }

                    biggerPointer++;
                }

                if (biggerPointer == bigger.Count)
                {
                    break;
                }
            }

            return product;
        }

        private int DotProductHash(int[] vector1, int[] vector2)
        {
            var table1 = new Dictionary<int, int>();
            var table2 = new Dictionary<int, int>();

            for (int i = 0; i < vector1.Length; i++)
            {
                if (vector1[i] != 0)
                {
                    table1.Add(i, vector1[i]);
                }

                if (vector2[i] != 0)
                {
                    table2.Add(i, vector2[i]);
                }
            }

            var product = 0;

            foreach (var pair in table1)
            {
                if (table2.ContainsKey(pair.Key))
                {
                    product += pair.Value * table2[pair.Key];
                }
            }

            return product;
        }
    }
}
