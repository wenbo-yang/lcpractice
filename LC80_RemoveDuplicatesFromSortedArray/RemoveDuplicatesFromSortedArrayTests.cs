using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC80_RemoveDuplicatesFromSortedArray
{
    [TestClass]
    public class RemoveDuplicatesFromSortedArrayTests
    {
        [TestMethod]
        public void GivenSortedArrayWithDuplicates_RemoveDuplicates_ShouldReturnArrayWith()
        {
            var input = new int[] { 0,0,1,1,1,2,2,3,3,4 };

            var length = RemoveDuplicates(input);

            Assert.IsTrue(length == 5);
            Assert.IsTrue(input[0] == 0 && input[1] == 1 && input[2] == 2 && input[3] == 3 && input[4] == 4);
        }

        private int RemoveDuplicates(int[] input)
        {

            var i = 1;
            var j = 0;

            while (i < input.Length)
            {
                if (input[i] != input[j])
                {
                    input[++j] = input[i];
                }

                i++;
            }

            return j + 1;
        }
    }
}
