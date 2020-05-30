using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1442_CountTripletsThatCanFormTwoArraysOfEqualXOR
{
    [TestClass]
    public class CountTripletsThatCanFormTwoArraysOfEqualXORTests
    {
        [TestMethod]
        public void GivenArray_FindNumberOfTripletsWithEqualXOR_ShouldReturnCorrectAnswer()
        {
            var arr = new int[] { 2, 3, 1, 6, 7 };
            var result = FindNumberOfTripletsWithEqualXOR(arr);

            Assert.IsTrue(result == 4);
        }

        private int FindNumberOfTripletsWithEqualXOR(int[] arr)
        {
            int result = 0;
            var frequencyTable = new Dictionary<int, int> { { 0, 1} };
            var sumTable = new Dictionary<int, int>();
            int xor = 0;
            for (int i = 0; i < arr.Count(); ++i)
            {
                xor ^= arr[i];
                if (!sumTable.ContainsKey(xor))
                {
                    sumTable.Add(xor, 0);
                }

                if (!frequencyTable.ContainsKey(xor))
                {
                    frequencyTable.Add(xor, 0);
                }

                result += frequencyTable[xor] * i - sumTable[xor];
                frequencyTable[xor]++;
                sumTable[xor] += i + 1;
            }
            return result;
        }
    }
}
