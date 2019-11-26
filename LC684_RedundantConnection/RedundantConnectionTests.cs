using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC684_RedundantConnection
{
    [TestClass]
    public class RedundantConnectionTests
    {
        [TestMethod]
        public void GivenEdgesWithRedundantConnection_FindRedundantConnection_ShouldReturnRedundantConnection()
        {
            var edges = new int[][] { new int[] { 1, 2 }, new int[]{ 2, 3 }, new int[]{3, 4}, new int[] { 1, 4 }, new int[]{ 1, 5} };

            var result = FindRedundantConnection(edges);

            Assert.IsTrue(result.SequenceEqual(new int[] {1, 4}));
        }

        private int[] FindRedundantConnection(int[][] edges)
        {
            var set = new UnionFindSet<int>().Build(edges);

            set.GetRedundantEdges();

            return set.GetRedundantEdges().Last();
        }

    }
}
