using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1437_CheckToSeeIfAll1sAreOfKLengthAway
{
    [TestClass]
    public class CheckToSeeIfAll1sAreOfKLengthAwayTests
    {
        [TestMethod]
        public void GivenArray_CheckAll1SAreOfKLengthAway_ShoulReturnKLength()
        {
            var nums = new int[] { 1, 0, 0, 0, 1, 0, 0, 1 };
            var k = 2;

            var result = CheckKDistanceAway(nums, k);

            Assert.IsTrue(result);
        }

        private bool CheckKDistanceAway(int[] nums, int k)
        {
            var left = int.MinValue + nums.Length; var right = 0;

            while (right < nums.Length)
            {
                if (nums[right] == 1)
                {
                    if (right - left <= k)
                    {
                        return false;
                    }
                    else
                    {
                        left = right;
                    }
                }

                right++;
            }

            return true;
        }
    }
}
