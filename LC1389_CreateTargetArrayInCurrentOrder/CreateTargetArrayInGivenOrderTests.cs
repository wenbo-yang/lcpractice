using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1389_CreateTargetArrayInCurrentOrder
{
    [TestClass]
    public class CreateTargetArrayInGivenOrderTests
    {
        [TestMethod]
        public void GivenTargetArrayAndIndex_CreateTargetArray_ShouldReturnTargetArray()
        {
            var nums = new int[] { 0, 1, 2, 3, 4};
            var index = new int[] { 0, 1, 2, 2, 1 };

            var result = CreateTargetArray(nums, index);

            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 4, 1, 3, 2 }));
        }

        private int[] CreateTargetArray(int[] nums, int[] index)
        {
            var list = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Count == 0)
                {
                    list.Add(nums[i]);
                }
                else
                {
                    list.Insert(index[i], nums[i]);
                }
            }

            return list.ToArray();
        }
    }
}
