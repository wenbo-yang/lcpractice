using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC169_MajorityElement
{
    [TestClass]
    public class MajorityElementTests
    {
        [TestMethod]
        public void GivenArrayWithMajorityElement_FindMajorityElement_ShouldReturnCorrectResult()
        {
            var input = new int[] { 2, 2, 1, 1, 1, 1, 1, 2, 2 };
            var result = FindMajorityElement(input);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherArrayWithMajorityElement_FindMajorityElement_ShouldReturnCorrectResult()
        {
            var input = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var result = FindMajorityElement(input);
            Assert.IsTrue(result == 2);
        }

        private int FindMajorityElement(int[] input)
        {
            var count = 0;
            var target = 0;
            for (int i = 0; i < input.Length; i++)
            {
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
