using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1284_MinimumNumberOfFlips
{
    [TestClass]
    public class MinimumNumberOfFlips
    {
        [TestMethod]
        public void GivenMat_FindMinimumNumberOfFlips_ShouldReturnMinimumNumberOfFlips()
        {
            var mat = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } };

            var result = GetMinimumNumberOfFlips(mat);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenAnotherMat_FindMinimumNumberOfFlips_ShouldReturnMinimumNumberOfFlips()
        {
            var mat = new int[][] { new int[] { 1, 1, 1}, new int[] { 1, 0, 1 }, new int[] { 0, 0, 0} };

            var result = GetMinimumNumberOfFlips(mat);

            Assert.IsTrue(result == 6);
        }

        private int GetMinimumNumberOfFlips(int[][] mat)
        {
            throw new NotImplementedException();
        }
    }
}
