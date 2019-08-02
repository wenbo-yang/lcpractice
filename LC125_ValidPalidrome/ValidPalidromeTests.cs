using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC125_ValidPalidrome
{
    [TestClass]
    public class ValidPalidromeTests
    {
        [TestMethod]
        public void GivenPalidromeSentenceString_Validate_ShouldReturnTrue()
        {
            var input = "A man, a plan, a canal: Panama";

            var result = Validate(input);

            Assert.IsTrue(result);
        }

        private bool Validate(string input)
        {
            var left = 0;
            var right = input.Length - 1;

            var result = true;

            while (left < right)
            {
                if (input[right] < 'a' || input[right] > 'Z')
                {
                    right--;
                    continue;
                }

                if (input[left] < 'a' || input[left] > 'Z')
                {
                    left++;
                    continue;
                }

                result &= input[left++].ToString().ToLower() == input[right--].ToString().ToLower();
            }

            return result;
        }


    }
}
