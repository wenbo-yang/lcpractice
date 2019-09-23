using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC344_ReverseString
{
    [TestClass]
    // LC344 LC345
    public class ReverseStringTests
    {
        [TestMethod]
        public void GivenArrayOfChar_Revere_ShouldReverseString()
        {
            var input = "Hello";

            var result = Reverse(input.ToCharArray());

            Assert.IsTrue(result == "olleH");
        }

        [TestMethod]
        public void GivenArrayOfChar_ReverseVowel_ShouldReverseString()
        {
            var input = "Hello";
            var result = ReverseVowels(input);

            Assert.IsTrue(result == "Holle");       
        }

        private string ReverseVowels(string input)
        {
            var chars = input.ToCharArray();

            var left = 0;
            var right = input.Length - 1;

            if (input[0] == 'Y' || input[0] == 'y')
            {
                left = 1;
            }

            while (left < right)
            {
                if (!IsVowel(chars[left]))
                {
                    left++;
                    continue;
                }

                if (!IsVowel(chars[right]))
                {
                    right--;
                    continue;
                }

                if (IsVowel(chars[left]) && IsVowel(chars[right]))
                {
                    var temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;
                    right--;
                    left++;
                }
            }

            return new string(chars);
        }

        private string Reverse(char[] input)
        {
            var mid = input.Length / 2;

            for (int i = 0; i <= mid; i++)
            {
                var temp = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = temp;
            }

            return new string(input);
        }


        private bool IsVowel(char c)
        {
            var hashSet = new HashSet<char>()
            {
                'a', 'e', 'o', 'u', 'y',
                'A', 'E', 'O', 'U', 'Y'
            };

            return hashSet.Contains(c);
        }

    }
}
