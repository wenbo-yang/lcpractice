using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC38_CountAndSaySequence
{
    [TestClass]
    public class CountAndSaySequenceTests
    {
        [TestMethod]
        public void GivenNumber_CountAndSay_ShouldReturnCorrectAnswer()
        {
            var n = 4;
            var result = CountAndSay(n);

            Assert.IsTrue(result == "1211");
        }

        private string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            var s = CountAndSay(n - 1);

            var left = 0;
            var right = 0;
            var sb = new StringBuilder();
            var count = 0;

            while (right < s.Length)
            {
                if (s[left] == s[right])
                {
                    count++;
                }
                else
                {
                    sb.Append(count.ToString());
                    sb.Append(s[left]);

                    left = right;
                    count = 0;
                    continue;
                }
                right++;
            }

            sb.Append(count.ToString());
            sb.Append(s[left]);
            return sb.ToString();
        }

    }
}
