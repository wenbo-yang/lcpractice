using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1394_LuckyIntegerInAnArray
{
    [TestClass]
    public class LuckyIntegerInAnArrayTests
    {
        [TestMethod]
        public void GivenArray_FindLuckyIntegers_ShouldReturnLuckyInteger()
        {
            var arr = new int[] { 2, 2, 3, 4 };

            var result = FindLuckyInteger(arr);

            Assert.IsTrue(result == 2);

        }

        private int FindLuckyInteger(int[] arr)
        {
            var table = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!table.ContainsKey(arr[i]))
                {
                    table.Add(arr[i], 0);
                }

                table[arr[i]]++;
            }

            var max = -1;

            foreach (var pair in table)
            {
                if (pair.Key == pair.Value)
                {
                    max = Math.Max(max, pair.Key);
                }
            }

            return max;
        }
    }
}
