using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC349_IntersectionOfTwoArrays
{
    [TestClass]
    // 350 is here as well
    public class IntersectionOfTwoArraysTests
    {
        [TestMethod]
        public void GivenTwoArrays_GetIntersection_ShouldReturnIntersectionArray()
        {
            var array1 = new int[] { 1, 2, 2, 1 };
            var array2 = new int[] { 2, 2 };

            var result = GetIntersection(array1, array2);

            Assert.IsTrue(result.Contains(2));
        }

        [TestMethod]
        public void GivenTwoArrays_GetIntersectionMany_ShouldReturnIntersectionArray()
        {
            var array1 = new int[] { 1, 2, 2, 1 };
            var array2 = new int[] { 2, 2 };

            var result = GetIntersectionMany(array1, array2);

            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 2}));
        }

        private List<int> GetIntersectionMany(int[] array1, int[] array2)
        {
            var table1 = new Dictionary<int, int>();
            var table2 = new Dictionary<int, int>();

            var intersection = new Dictionary<int, int>();

            foreach (var item in array1)
            {
                if (!table1.ContainsKey(item))
                {
                    table1.Add(item, 0);
                }
                table1[item]++;
            }

            foreach (var item in array2)
            {
                if (!table2.ContainsKey(item))
                {
                    table2.Add(item, 0);
                }
                table2[item]++;
            }

            foreach (var key in table1.Keys)
            {
                if (table2.ContainsKey(key))
                {
                    intersection.Add(key, Math.Min(table1[key], table2[key]));
                }
            }

            var result = new List<int>();

            foreach (var keyValuePair in intersection)
            {
                var value = keyValuePair.Value;
                while (value != 0)
                {
                    result.Add(keyValuePair.Key);
                    value--;
                }
            }

            return result;
        }

        private HashSet<int> GetIntersection(int[] array1, int[] array2)
        {
            var set1 = new HashSet<int>(array1);

            set1.IntersectWith(array2);

            return set1;
        }
    }
}
