using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1262_GreatestSumDivisibleBy3
{
    [TestClass]
    public class GreatestSumDivisibleBy3Tests
    {
        [TestMethod]
        public void GivenArray_GetGreatestSumDivisibleByThree_ShouldReturnGreatestSum()
        {
            var array = new int[] { 3, 6, 5, 1, 8 };

            var sum = GetGreatestSum(array);

            Assert.IsTrue(sum == 18);
        }

        private int GetGreatestSum(int[] array)
        {
            var hashSet = new HashSet<int>(array);

            var dp = new int[3];

            foreach(var num in array)
            {
                var temp = new List<int>(dp);
                foreach (var r in temp)
                {
                    dp[(r + num) % 3] = Math.Max(dp[(r + num) % 3], r + num);
                }
                    
            }
            return dp[0];
        }
    }
}
