using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1433_CheckIfAStringCanBreakAnotherString
{
    [TestClass]
    public class CheckIfAStringCanBreakAnotherStringTests
    {
        [TestMethod]
        public void GivenTwoStrings_CheckIfStringsCanBreak_ShouldReturnCorrectAnswer()
        {
            var s1 = "abc"; var s2 = "xya";

            var result = CheckIfStringsCanBreak(s1, s2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoUnmatchingStrings_CheckIfStringsCanBreak_ShouldReturnCorrectAnswer()
        {
            var s1 = "abe"; var s2 = "acd";

            var result = CheckIfStringsCanBreak(s1, s2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnotherTwoUnmatchingStrings_CheckIfStringsCanBreak_ShouldReturnCorrectAnswer()
        {
           
            var s1 = "ixzhsdka"; var s2 = "aauramvg";

            var result = CheckIfStringsCanBreak(s1, s2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAnotherMatchingStrings_CheckIfStringsCanBreak_ShouldReturnCorrectAnswer()
        {
            var s1 = "yopumzgd"; var s2 = "pamntyya";

            var result = CheckIfStringsCanBreak(s1, s2);

            Assert.IsTrue(result);
        }

        private bool CheckIfStringsCanBreak(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var countS1 = new int[26];
            var countS2 = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                countS1[s1[i] - 'a']++;
                countS2[s2[i] - 'a']++;
            }

            var diff = new int[26];
            diff[0] = countS1[0] - countS2[0];
            for (int i = 1; i < 26; i++)
            {
                diff[i] = countS1[i] - countS2[i] + diff[i - 1];
            }

            var firstNoneZero = -1;
            for (int i = 0; i < 26; i++)
            {
                if (firstNoneZero == -1 && diff[i] != 0)
                {
                    firstNoneZero = i;
                    continue;
                }

                if (diff[i] < 0 && diff[firstNoneZero] > 0)
                {
                    return false;
                }

                if (diff[i] > 0 && diff[firstNoneZero] < 0)
                {
                    return false;
                }
            }

            return diff[25] == 0;
        }
    }
}
