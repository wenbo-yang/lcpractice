using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1317_FindPartitionWithNonZeroPartition
{
    [TestClass]
    public class FindPartitionWithNonZeroPartitionTests
    {
        [TestMethod]
        public void GivenInteger_FindPartitionWithNonZeroDigits_ShouldReturnCorrectAnswer()
        {
            var n = 1001;

            var result = FindPartitionWithNonZeroDigits(n);

            Assert.IsTrue(!result.Item1.ToString().Contains("0"));
            Assert.IsTrue(!result.Item2.ToString().Contains("0"));
        }

        private Tuple<int, int> FindPartitionWithNonZeroDigits(int n)
        {
            var item1 = n - 1;
            var item2 = 1;

            while (item1.ToString().Contains("0") || item2.ToString().Contains("0"))
            {
                item1--; item2++;
            }

            return new Tuple<int, int>(item1, item2);

        }
    }
}
