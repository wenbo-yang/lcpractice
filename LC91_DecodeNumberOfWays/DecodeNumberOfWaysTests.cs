using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC91_DecodeNumberOfWays
{
    [TestClass]
    public class DecodeNumberOfWaysTests
    {
        [TestMethod]
        public void GivenInputIntString_Decode_ShouldReturnCorrectWays()
        {
            var input = "226";

            int result = DecodeWays(input);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenInputIntStringWithOutBound_Decode_ShouldReturnCorrectWays()
        {
            var input = "227";

            int result = DecodeWays(input);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenStarting0String_Decode_ShouldReturn0()
        {
            var input = "0226";

            int result = DecodeWays(input);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenStringContaining0_Decode_ShouldReturnCorrectAnswer()
        {
            var input = "1120";

            int result = DecodeWays(input);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenStringContainingInvalid0_Decode_ShouldReturn0()
        {
            var input = "23026";

            int result = DecodeWays(input);

            Assert.IsTrue(result == 0);
        }

        private int DecodeWays(string input)
        {
            var prev = 1;
            var prevl1 = 0;
            var current = 0;

            if (input[0] == '0')
            {
                return 0;
            }

            for (int i = 0; i < input.Length; i++)
            {
                var digit = Convert.ToInt32(input[i].ToString());
                if (digit == 0)
                {
                    var prevDigit = Convert.ToInt32(input[i - 1].ToString());
                    if (prevDigit == 1 || prevDigit == 2)
                    {
                        prev = prevl1;
                        current = prevl1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (digit >= 7)
                {
                    current = prev;
                }
                else
                {
                    current = prev + prevl1;
                }

                prevl1 = prev;
                prev = current;
            }

            return current;
        }
    }
}
