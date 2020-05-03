using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1385_FindTheDistanceValueBetweenTwoArrays
{
    [TestClass]
    public class FindTheDistanceValueBetweenTwoArraysTests
    {
        [TestMethod]
        public void GivenTwoArray_FindDistanceValue_ShouldReturnNumberOfItemsInTheOtherArray()
        {
            var arr1 = new int[] { 1, 4, 2, 3 };
            var arr2 = new int[] { -4, -3, 6, 10, 20, 30 };
            var d = 3;

            var result = FindDistanceValue(arr1, arr2, d);
            Assert.IsTrue(result == 2);
        }

        private int FindDistanceValue(int[] arr1, int[] arr2, int d)
        {
            var targetSet = new HashSet<int>();

            for (int i = 0; i < arr2.Length; i++)
            {
                var upper = arr2[i] - d;
                var lower = arr2[i] + d;
                for (int j = upper; j <= lower; j++)
                {
                    targetSet.Add(j);
                }
            }

            var sourceSet = new Dictionary<int, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!sourceSet.ContainsKey(arr1[i]))
                {
                    sourceSet.Add(arr1[i], 0);
                }

                sourceSet[arr1[i]]++;
            }

            foreach (var item in targetSet)
            {
                if (sourceSet.ContainsKey(item))
                {
                    sourceSet.Remove(item);
                }
            }

            return sourceSet.Values.Sum();
        }
    }
}
