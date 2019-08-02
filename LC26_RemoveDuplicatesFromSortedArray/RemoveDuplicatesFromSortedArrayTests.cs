using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC26_RemoveDuplicatesFromSortedArray
{
    [TestClass]
    public class RemoveDuplicatesFromSortedArrayTests
    {
        [TestMethod]
        public void GivenArrayOfAllDups_Remove_ShouldYieldOneResult()
        {
            var input = new int[] { 1, 1, 1, 1, 1 };

            var output = RemoveDuplicateNumberInArray(input);

            Assert.IsTrue(output == 1);
        }

        [TestMethod]
        public void GivenArrayNoDups_Remove_ShouldReturn0AndOriginialArray()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };

            var output = RemoveDuplicateNumberInArray(input);

            Assert.IsTrue(output == 5);
        }

        [TestMethod]
        public void GivenArraySomeDups_Remove_ShouldInPlaceSwapFirstNElementShouldBeUnique()
        {
            var input = new int[] { 1, 1, 1, 2, 2, 3, 3, 4, 5 };

            var output = RemoveDuplicateNumberInArray(input);

            Assert.IsTrue(output == 5);
        }

        private int RemoveDuplicateNumberInArray(int[] input)
        {
            var left = 0;
            var right = 1;
            var count = 1;
            while (right < input.Length)
            {
                if (input[left] == input[right])
                {
                    right++;
                    continue;
                }

                if (input[left] == input[right - 1])
                {
                    input[++left] = input[right++];
                    count++;
                    continue;
                }
            }

            return count;
        }
    }
}
