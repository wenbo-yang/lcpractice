using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC307_RangeSumQueryMutable
{
    [TestClass]
    // 308 is here as well
    public class RangeSumQueryMutableTests
    {
        [TestMethod]
        public void GivenRangeSumWithUpdate_Query_ShouldStillReturnCorrectNumber()
        {
            var mutableRangeSumQuery = new MutableRangeSumQuery().Build(new int[] { 1, 3, 5 });
            Assert.IsTrue(mutableRangeSumQuery.RangeSum(0, 2) == 9);

            mutableRangeSumQuery.Update(1, 2);
            Assert.IsTrue(mutableRangeSumQuery.RangeSum(0, 2) == 8);
        }

        public class MutableRangeSumQuery
        {
            private FenwickTree _fenwickTreeRoot = null;

            public MutableRangeSumQuery Build(int[] array)
            {

                var rangeSum = new int[array.Length];
                rangeSum[0] = array[0];

                for (int i = 1; i < rangeSum.Length; i++)
                {
                    rangeSum[i] = rangeSum[i - 1] + array[i];
                }

                _fenwickTreeRoot = ParseIntoFenwickTree(rangeSum, 0, array.Length - 1);

                return this;
            }

            public int RangeSum(int start, int end)
            {
                return SearchTree(_fenwickTreeRoot, start, end);
            }

            private int SearchTree(FenwickTree fenwickTreeRoot, int start, int end)
            {
                if (fenwickTreeRoot.Range.Item1 == start && fenwickTreeRoot.Range.Item2 == end)
                {
                    return fenwickTreeRoot.Value;
                }

                if (fenwickTreeRoot.Range.Item1 == start)
                {
                    return end > fenwickTreeRoot.Range.Item2 ? SearchTree(fenwickTreeRoot.Right, start, end) : SearchTree(fenwickTreeRoot.Left, start, end);
                }

                if (start > fenwickTreeRoot.Range.Item1)
                {
                    return SearchTree(fenwickTreeRoot.Right, start, end);
                }

                return SearchTree(fenwickTreeRoot.Left, start, end);
            }

            public void Update(int index, int value)
            {
                UpdateFenwickTree(_fenwickTreeRoot, index, value);
            }

            private void UpdateFenwickTree(FenwickTree root, int index, int value)
            {
                if (root == null)
                {
                    return;
                }

                if (index  < root.Range.Item1 || index > root.Range.Item2)
                {
                    return;
                }

                if (root.Range.Item1 == index && root.Range.Item2 == index)
                {
                    root.Value = value;
                    return;
                }

                UpdateFenwickTree(root.Left, index, value);
                UpdateFenwickTree(root.Right, index, value);

                root.Value = root.Left.Value + root.Right.Value;
            }

            private FenwickTree ParseIntoFenwickTree(int[] rangeSum, int start, int end)
            {
                if (start > end)
                {
                    return null;
                }

                var pivot = (start + end) / 2;

                var root = new FenwickTree()
                {
                    Range = new Tuple<int, int>(start, end),
                    Value = RangeSumQuery(rangeSum, start, end),
                    Left = start == end ? null : ParseIntoFenwickTree(rangeSum, start, pivot),
                    Right = start == end? null : ParseIntoFenwickTree(rangeSum, pivot + 1, end)
                };

                return root;
            }

            private int RangeSumQuery(int[] rangeSum, int start, int end)
            {
                if (start == 0)
                {
                    return rangeSum[end];
                }

                if (start == end)
                {
                    return rangeSum[end] - rangeSum[end - 1];
                }

                return rangeSum[end] - rangeSum[start];
            }
        }

        public class FenwickTree
        {
            public Tuple<int, int> Range { get; set; }
            public int Value { get; set; }

            public FenwickTree Left { get; set; }
            public FenwickTree Right { get; set; }
        }
    }
}
