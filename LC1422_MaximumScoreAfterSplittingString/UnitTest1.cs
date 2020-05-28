using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1422_MaximumScoreAfterSplittingString
{
    [TestClass]
    public class MaximumScoreAfterSplittingString
    {
        [TestMethod]
        public void GivenStringInBinaryForm_GetMaximumScore_ShouldReturnMaximumScore()
        {
            var s = "011101";

            var result = GetMaximumScore(s);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenAnotherStringInBinaryForm_GetMaximumScore_ShouldReturnMaximumScore()
        {
            var s = "00111";

            var result = GetMaximumScore(s);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenThirdStringInBinaryForm_GetMaximumScore_ShouldReturnMaximumScore()
        {
            var s = "01001";

            var result = GetMaximumScore(s);

            Assert.IsTrue(result == 4);
        }

        private int GetMaximumScore(string s)
        {
            var oneCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') oneCount++;
            }

            var max = 0;
            var zeroCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    zeroCount++;
                }
                
                if(s[i] == '1')
                {
                    oneCount--;
                }

                max = Math.Max(max, zeroCount + oneCount);
            }

            return max;
        }
    }
}
