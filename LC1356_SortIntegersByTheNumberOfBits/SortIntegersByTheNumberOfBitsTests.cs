using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1356_SortIntegersByTheNumberOfBits
{
    [TestClass]
    public class SortIntegersByTheNumberOfBitsTests
    {
        [TestMethod]
        public void GivenArrayOfIntegers_SortIntegersByNumberOfBits_ShouldReturnNumberOfBits()
        {
            var array = new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };

            var result = SortByBits(array);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 }));
        }

        private int[] SortByBits(int[] array)
        {
            var buckets = new List<int>[33];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (var item in array)
            {
                var bits = GetNumberOfBits(item);
                buckets[bits].Add(item);
            }

            var result = new List<int>();

            foreach (var bucket in buckets)
            {
                bucket.Sort();
                result.AddRange(bucket);
            }

            return result.ToArray();
        }

        private int GetNumberOfBits(int number)
        {
            var bits = 0;

            for (int i = 0; i < 32; i++)
            {
                bits = (number & 1) == 1 ? bits + 1 : bits;
                number = number >> 1;
            }

            return bits;
        }
    }
}
