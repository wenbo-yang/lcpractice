using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC311_SparseVectorMultiplication
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
