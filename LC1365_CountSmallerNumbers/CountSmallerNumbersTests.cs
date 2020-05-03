using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1365_CountSmallerNumbers
{
    [TestClass]
    public class CountSmallerNumbersTests
    {
        [TestMethod]
        public void GivenArray_CountSmallerNumbers_ShouldReturnCorrectArray()
        {
            var array = new int[] { 8, 1, 2, 2, 3 };
            var result = CountSmallerNumbers(array);

            Assert.IsTrue(result.SequenceEqual(new int[] { 4, 0, 1, 1, 3 }));
        }

        private int[] CountSmallerNumbers(int[] array)
        {
            var sortedDictionary = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!sortedDictionary.ContainsKey(array[i]))
                {
                    sortedDictionary.Add(array[i], new List<int>());
                }

                sortedDictionary[array[i]].Add(i);
            }

            var count = 0;
            var result = new int[array.Length];
            foreach (var item in sortedDictionary)
            {
                foreach (var index in item.Value)
                {
                    result[index] = count;
                }

                count += item.Value.Count;
            }

            return result;
        }
    }
}
