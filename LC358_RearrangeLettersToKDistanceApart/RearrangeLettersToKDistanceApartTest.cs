using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC358_RearrangeLettersToKDistanceApart
{
    [TestClass]
    public class RearrangeLettersToKDistanceApartTest
    {
        [TestMethod]
        public void GivenValidSetOfLetters_RearrangeLettersToKDistance_ShouldReturnRearragedLetter()
        {
            var input = "aabbcc";
            var k = 3;
            var result = RearrangeLettersToKDistanceApart(input, k);

            Assert.IsTrue(result == "abcabc");
        }

        private string RearrangeLettersToKDistanceApart(string input, int k)
        {
            // param validations //

            var frequency = new int[26];

            for (int i = 0; i < input.Length; i++)
            {
                frequency[input[i] - 'a']++;
            }

            var result = new char[input.Length];
            var currentIndex = 0;
            for (int i = 0; i < 26; i++)
            {
                if (frequency[i] == 0)
                {
                    continue;
                }

                var index = GetCharWithMaxFrequencyToPlace(frequency);
                var f = frequency[index]; frequency[index] = 0; // set to zero afterwards
                var c = (char)('a' + index);
                currentIndex = GetNextAvailableSlot(result, currentIndex);
                if (currentIndex == -1)
                {
                    return "";
                }

                if (!PlaceChars(result, currentIndex, c, f, k))
                {
                    return "";
                }
            }

            return new string(result);
        }

        private int GetNextAvailableSlot(char[] array, int current)
        {
            for (int i = current; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private int GetCharWithMaxFrequencyToPlace(int[] frequency)
        {
            var currentMax = -1;
            var result = 0;
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] > currentMax)
                {
                    currentMax = frequency[i];
                    result = i;
                }
            }

            return result;
        }

        private bool PlaceChars(char[] array, int index, char c, int frequency, int k)
        {
            var count = 0;
            while(count < frequency)
            {
                if (index >= array.Length)
                {
                    return false;
                }

                array[index] = c;
                index += k;
                count++;
            }

            return true;
        }
    }
}
