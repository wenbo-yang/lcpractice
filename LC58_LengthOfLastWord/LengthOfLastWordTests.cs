using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC58_LengthOfLastWord
{
    [TestClass]
    public class LengthOfLastWordTests
    {
        [TestMethod]
        public void GivenString_LengthOfLastWord_ShouldReturnCorrectAnswer()
        {
            var s = "Hello World";

            var result = LengthOfLastWord(s);

            Assert.IsTrue(result == 5);
        }

        private int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            var index = s.Length - 1;

            while (s[index] == ' ')
            {
                index--;
            }

            var last = index;

            while (index >= 0)
            {
                if (s[index] == ' ')
                {
                    break;
                }

                index--;
            }

            return last - index;
        }
    }
}
