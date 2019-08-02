using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC31_NextPermutation
{
    [TestClass]
    public class NextPermutationTests
    {
        [TestMethod]
        public void GivenInputArray_NextPermutation_ShouldSwapNextSignificantBit()
        {
            var input = new int[] { 1, 2, 3 };

            int[] output = NextPermutation(input);

            Assert.IsTrue(output[0] == 1);
            Assert.IsTrue(output[1] == 3);
            Assert.IsTrue(output[2] == 2);
        }

        [TestMethod]
        public void GivenInputArrayWithBiggestInTheMiddle_NextPermutation_ShouldSwapNextSignificantBit()
        {
            var input = new int[] { 1, 3, 2 };

            int[] output = NextPermutation(input);

            Assert.IsTrue(output[0] == 3);
            Assert.IsTrue(output[1] == 1);
            Assert.IsTrue(output[2] == 2);
        }
        [TestMethod]
        public void GivenInputArrayWithBiggestInTheFront_NextPermutation_ShouldSwapFirstAndLast()
        {
            var input = new int[] { 3, 2, 1 };

            int[] output = NextPermutation(input);

            Assert.IsTrue(output[0] == 1);
            Assert.IsTrue(output[1] == 2);
            Assert.IsTrue(output[2] == 3);
        }

        private int[] NextPermutation(int[] input)
        {
            // start from the last significant bit
            if (input.Length < 2)
            {
                return input;
            }
            // ask for if we destroy the original array;
            var output = new int[input.Length];
            input.CopyTo(output, 0);

            for (int i = output.Length - 2; i >= 0; i--)
            {
                if (output[i] >= output[i + 1])
                {
                    if (i == 0)
                    {
                        // swap last and first
                        var firstLastSwap = output[0];
                        output[0] = output[output.Length - 1];
                        output[output.Length - 1] = firstLastSwap;
                    }

                    continue;
                }
                else
                {
                    var leftRightSwap = output[i];
                    output[i] = output[i + 1];
                    output[i + 1] = leftRightSwap;

                    break;
                }
            }

            return output;
        }
    }
}
