using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LC260_SingleNumber
{
    [TestClass]
    public class SingleNumberTests
    {
        [TestMethod]
        public void GivenValidInputArray_FindSingleNumbersHas_ShouldReturnTwoSingleNumbers()
        {
            var input = new int[] { 1, 2, 1, 3, 2, 5 };

            int[] result = FindSingleNumberUsingHash(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 5}) || result.SequenceEqual(new int[] { 5, 3}));
        }

        [TestMethod]
        public void GivenValidInputArray_FindSingleNumbersConstantSpace_ShouldReturnTwoSingleNumbers()
        {
            var input = new int[] { 1, 2, 1, 3, 2, 5 };

            int[] result = FindSingleNumberConstantSpace(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 5 }) || result.SequenceEqual(new int[] { 5, 3 }));
        }

        private int[] FindSingleNumberConstantSpace(int[] input)
        {
            int AXORB = 0;
            foreach (var item in input)
            {
                AXORB ^= item;
            }

            // pick one bit as flag
            int bitFlag = (AXORB & (~(AXORB - 1)));
            int[] res = new int[2];
            foreach (int item in input)
            {
                if ((item & bitFlag) == 0)
                {
                    res[0] ^= item;
                }
                else
                {
                    res[1] ^= item;
                }
            }
            return res;
        }

        private int[] FindSingleNumberUsingHash(int[] input)
        {
            var hashSet = new HashSet<int>();
            foreach (var item in input)
            {
                if (hashSet.Contains(item))
                {
                    hashSet.Remove(item);
                }
                else
                {
                    hashSet.Add(item);
                }
            }

            var array = new int[2];
            hashSet.CopyTo(array);

            return array;
        }
    }
}
