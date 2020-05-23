using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1409_QueriesInAPermutationWithKey
{
    [TestClass]
    // fenwick tree
    public class QueriesInAPermutationWithKeyTests
    {
        [TestMethod]
        public void GivenArraySizeAndQueriesArray_ProcessQueries_ShouldReturnCorrectQueries()
        {
            var queries = new int[] { 3, 1, 2, 1 }; var m = 5;

            var result = ProcessQueries(queries, m);

            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 1, 2, 1 }));
        }

        private int[] ProcessQueries(int[] queries, int m)
        {
            var prefixSum = GenerateCountPrefixSumArray(m);
            var valueIndexArray = GenerateIndexWithOffsetArray(m);

            var head = ParseArrayIntoFenwickTree(prefixSum);
            var result = new int[queries.Length];
            var currentSlot = m - 1;
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = QueryAndUpdateFenwickTree(queries[i], head, valueIndexArray, currentSlot--) - 1;
            }

            return result;
        }

        private int QueryAndUpdateFenwickTree(int value, FenwickTreeNode head, int[] valueIndexArray, int currentEmptySlot)
        {
            var index = valueIndexArray[value];

            var result = Query(head, 0, index);

            Update(head, index, 0);
            Update(head, currentEmptySlot, 1);

            valueIndexArray[value] = currentEmptySlot;

            return result;
        }

        private void Update(FenwickTreeNode head, int index, int value)
        {
            if (head == null)
            {
                return;
            }

            if (head.upper == index && head.lower == index)
            {
                head.value = value;
                return;
            }

            if (index <= (head.upper + head.lower) / 2)
            {
                Update(head.left, index, value);
            }
            else
            {
                Update(head.right, index, value);
            }

            head.value = (head.left == null ? 0 : head.left.value) + (head.right == null ? 0 : head.right.value);
        }

        private int Query(FenwickTreeNode head, int lower, int upper)
        {
            if (head == null)
            {
                return 0;
            }

            if (head.lower == lower && head.upper == upper)
            {
                return head.value;
            }


            if (upper <= head.left.upper)
            {
                return Query(head.left, lower, upper);
            }
            else
            {
                return Query(head.left, lower, head.left.upper) + Query(head.right, head.right.lower, upper);
            }
        }

        private int[] GenerateCountPrefixSumArray(int m)
        {
            var array = new int[m * 2];
            for (int i = m; i < array.Length; i++)
            {
                array[i] = 1; 
            }

            return array;
        }

        private int[] GenerateIndexWithOffsetArray(int m)
        {
            var indexArray = new int[m + 1];
            for (int i = 1; i < indexArray.Length; i++)
            {
                indexArray[i] = m + i - 1;
            }

            return indexArray;
        }

        private FenwickTreeNode ParseArrayIntoFenwickTree(int[] array)
        {
            return ParseArrayIntoFenwickTreeHelper(array, 0, array.Length - 1);
        }

        private FenwickTreeNode ParseArrayIntoFenwickTreeHelper(int[] array, int lower, int upper)
        {
            if (lower > upper)
            {
                return null;
            }

            if (lower == upper)
            {
                return new FenwickTreeNode
                {
                    lower = lower,
                    upper = upper,
                    value = array[lower],
                };
            }


            var node = new FenwickTreeNode
            {
                lower = lower,
                upper = upper,
                left = ParseArrayIntoFenwickTreeHelper(array, lower, (upper + lower) / 2),
                right = ParseArrayIntoFenwickTreeHelper(array, (upper + lower) / 2 + 1, upper),
            };

            node.value = (node.left == null ? 0 : node.left.value) + (node.right == null ? 0 : node.right.value);

            return node;
        }

        public class FenwickTreeNode
        {
            public int upper;
            public int lower;
            public int value;
            public FenwickTreeNode left;
            public FenwickTreeNode right;
        }
    }
}
