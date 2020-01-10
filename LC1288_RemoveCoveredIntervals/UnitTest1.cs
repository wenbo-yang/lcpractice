using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1288_RemoveCoveredIntervals
{
    [TestClass]
    public class RemoveCoveredIntervalsTest
    {
        [TestMethod]
        public void GivenListOfIntervals_RemoveCoveredInterval_ShouldReturnNumberOfUniqueIntervals()
        {
            var intervals = new List<(int start, int end)> { (1, 4), (3, 6), (2, 8) };

            var result = RemoveCoveredIntervals(intervals);

            Assert.IsTrue(result == 2);
        }

        private int RemoveCoveredIntervals(List<(int start, int end)> intervals)
        {
            var result = intervals.Count;

            var segmentedTree = GenerateSegmentedTreeFromList(intervals);

            return segmentedTree.count;
        }

        private SegmentedTree GenerateSegmentedTreeFromList(List<(int start, int end)> intervals)
        {
            SegmentedTree root = null;

            foreach (var interval in intervals)
            {
                GenerateSegmentedTreeFromListHelper(ref root, interval);
            }

            return root;
        }

        private void GenerateSegmentedTreeFromListHelper(ref SegmentedTree root, (int start, int end) interval)
        {
            if (root == null || (interval.start <= root.start && interval.end >= root.end))
            {
                root = new SegmentedTree
                {
                    start = interval.start,
                    end = interval.end,
                    count = 1
                };

                return;
            }

            if (ShouldInsertLeft(root, interval))
            {
                GenerateSegmentedTreeFromListHelper(ref root.left, interval);
                root.start = Math.Min(root.start, root.left.start);
            }
            else if(ShouldInsertRight(root, interval))
            {
                GenerateSegmentedTreeFromListHelper(ref root.right, interval);
                root.end = Math.Max(root.end, root.right.end);
            }

            root.count = (root.left == null ? 0 : root.left.count) + (root.right == null ? 0 : root.right.count) + 1;

        }

        private bool ShouldInsertLeft(SegmentedTree root, (int start, int end) interval)
        {
            return root.start >= interval.start;
        }

        private bool ShouldInsertRight(SegmentedTree root, (int start, int end) interval)
        {
            return root.end <= interval.end;
        }

        public class SegmentedTree
        {
            public int start;
            public int end;
            public int count;
            public SegmentedTree left;
            public SegmentedTree right;
        }
        
        

    }
}
