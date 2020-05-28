using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1417_ReconstructString
{
    [TestClass]
    public class ReformatStringTests
    {
        [TestMethod]
        public void GivenString_ReformatString_ShouldReturnString()
        {
            var s = "a0b1c2";
            var result = ReformatString(s);

            Assert.IsTrue(result == "a0b1c2");
        }

        private string ReformatString(string s)
        {
            var isFormatted = true;
            var lastIndexIsADigit = (s[0] - '0' <= 9 && s[0] - '0' >= 0) ? false : true;

            var digitCollection = new List<char>();
            var letterCollection = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var currentIndexIsADigit = (s[i] - '0' <= 9 && s[i] - '0' >= 0) ? true : false;

                isFormatted &= currentIndexIsADigit != lastIndexIsADigit;

                lastIndexIsADigit = currentIndexIsADigit;

                if (currentIndexIsADigit)
                {
                    digitCollection.Add(s[i]);
                }
                else
                {
                    letterCollection.Add(s[i]);
                }
            }

            if (isFormatted)
            {
                return s;
            }

            var bigger = digitCollection.Count > letterCollection.Count ? digitCollection : letterCollection;
            var smaller = digitCollection.Count <= letterCollection.Count ? digitCollection : letterCollection;

            if (bigger.Count - smaller.Count > 1)
            {
                return "";
            }

            var sb = new StringBuilder();

            for (int i = 0; i < smaller.Count; i++)
            {
                sb.Append(bigger[i]); sb.Append(smaller[i]);
            }

            sb.Append(bigger[bigger.Count - 1]);

            return sb.ToString();
        }
    }
}
