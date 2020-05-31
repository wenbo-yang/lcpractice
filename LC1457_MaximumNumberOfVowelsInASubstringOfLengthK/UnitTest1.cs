using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1457_MaximumNumberOfVowelsInASubstringOfLengthK
{
    [TestClass]
    public class MaximumNumberOfVowelsInASubstringOfLengthKTests
    {
        [TestMethod]
        public void GivenStringAndK_MaxVowelsOfSubstringK_ShouldReturnMaxVowels()
        {
            var s = "abciiidef"; var k = 3;
            var result = MaxVowelsOfSubstringLengthK(s, k);

            Assert.IsTrue(result == 3);
        }

        private int MaxVowelsOfSubstringLengthK(string s, int k)
        {
            var left = 0; var right = 0;
            
            var current = 0;
            while (right < k)
            {
                if (IsVowel(s[right++]))
                {
                    current++; 
                }
            }
            var max = 0;
            max = Math.Max(max, current);

            while (right < s.Length)
            {
               
                if (IsVowel(s[left]))
                {
                    current--;
                }

                if (IsVowel(s[right]))
                {
                    current++;
                }

                max = Math.Max(max, current);
                if (max == k)
                {
                    return k;
                }
                left++;
                right++;
            }

            return max;
        }

        private bool IsVowel(char c)
        {
            if ((c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')) return true;
            return false;
        }
    }
}
