using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC229_MajorityElement2
{
    [TestClass]
    public class MajorityElement2Tests
    {
        [TestMethod]
        public void GivenArray_FindFrequentElement_ShouldReturnCorrectList()
        {
            var input = new int[] { 3, 2, 3 };
            var result = FindFrequentElement(input);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 3 }));
        }

        [TestMethod]
        public void GivenAnotherArray_FindFrequentElement_ShouldReturnCorrectList()
        {
            var input = new int[] { 1, 1, 1, 3, 3, 2, 2, 2 };
            var result = FindFrequentElement(input);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 2 }));
        }

        private List<int> FindFrequentElement(int[] input)
        {
            var result = new List<int>();

            var majorityFirst = FindMajorityElementWithMask(input, 0, (input.Length - 1) / 2, false, int.MaxValue);
            var majoritySecond = FindMajorityElementWithMask(input, (input.Length - 1) / 2 + 1, input.Length - 1, false, int.MaxValue);

            if (CountFrequency(input, majorityFirst) > input.Length / 3)
            {
                result.Add(majorityFirst);
            }
            else if (CountFrequency(input, majoritySecond) > input.Length / 3)
            {
                result.Add(majoritySecond);
            }

            if (result.Count == 1)
            {
                var secondTarget = FindMajorityElementWithMask(input, 0, input.Length - 1, true, result[0]);
                if (CountFrequency(input, secondTarget) > input.Length / 3)
                {
                    result.Add(secondTarget);
                }
            }

            return result;
        }

        private int CountFrequency(int[] input, int majority)
        {
            var frequency = 0;
            foreach (var num in input)
            {
                if (num == majority)
                {
                    frequency++;
                }
            }

            return frequency;
        }

        private int FindMajorityElementWithMask(int[] input, int start, int end, bool haveMask, int mask)
        {
            var count = 0;
            var target = 0;
            for (int i = start; i <= end; i++)
            {
                if (haveMask && input[i] == mask)
                {
                    continue;
                }

                if (count == 0)
                {
                    target = input[i];
                    count = 1;
                    continue;
                }

                if (input[i] == target)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return target;
        }
    }
}
