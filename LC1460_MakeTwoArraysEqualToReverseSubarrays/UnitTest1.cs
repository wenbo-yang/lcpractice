using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1460_MakeTwoArraysEqualToReverseSubarrays
{
    [TestClass]
    public class MakeTwoArraysEqualToReverseSubarraysTests
    {
        [TestMethod]
        public void GivenTwoArrays_MakeEqualReverseSubarray_ShouldReturnCorrectAnswer()
        {
            var target = new int[] { 1, 2, 3, 4 }; var arr = new int[] { 2, 4, 1, 3 };
            var result = CanBeOther(target, arr);

            Assert.IsTrue(result);
        }

        private bool CanBeOther(int[] target, int[] arr)
        {
            if(target.Length != arr.Length)
            {
                return false;
            }

            var table = new Dictionary<int, int>();

            for (int i = 0; i < target.Length; i++)
            {
                if (!table.ContainsKey(target[i]))
                {
                    table.Add(target[i], 0);
                }
                table[target[i]]++;

                if (!table.ContainsKey(arr[i]))
                {
                    table.Add(arr[i], 0);
                }
                table[arr[i]]--;
            }

            var values = table.Values;

            foreach (var value in values)
            {
                if (value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
