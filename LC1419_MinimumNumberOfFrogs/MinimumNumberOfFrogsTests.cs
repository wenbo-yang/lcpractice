using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1419_MinimumNumberOfFrogs
{
    [TestClass]
    public class MinimumNumberOfFrogsTests
    {
        [TestMethod]
        public void GivenCroakingFrogs_GetMinimumNumberOfFrogs_ShouldReturnMinumNumberOfFrog()
        {
            var croakOfFrogs = "croakcroak";

            var result = GetMinimumNumberOfFrogs(croakOfFrogs);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenTwoCroakingFrogs_GetMinimumNumberOfFrogs_ShouldReturnMinumNumberOfFrog()
        {
            var croakOfFrogs = "crcoakroak";

            var result = GetMinimumNumberOfFrogs(croakOfFrogs);

            Assert.IsTrue(result == 2);
        }

        private int GetMinimumNumberOfFrogs(string croakOfFrogs)
        {
            var table = new int[26];
            var max = 0;
            for (int i = 0; i < croakOfFrogs.Length; i++)
            {
               
                table[croakOfFrogs[i] - 'a']++;

                if (croakOfFrogs[i] == 'k')
                {
                    max = Math.Max(max, table['c' - 'a'] + table['r' - 'a'] + table['o' - 'a'] + table['a' - 'a']);
                }

                if (croakOfFrogs[i] == 'c')
                {
                    continue;
                }

                var expectedChar = GetExpectedChar(croakOfFrogs[i]);

                if (expectedChar == ' ' || --table[expectedChar - 'a'] < 0)
                {
                    return -1;
                }
            }

            return (table['c' - 'a'] == 0 && table['r' - 'a'] == 0 && table['o' - 'a'] == 0 && table['a' - 'a'] == 0) ? max : -1;
        }

        private char GetExpectedChar(char c)
        {
            var expectedChar = ' '; 
            switch (c)
            {
                case 'r':
                    expectedChar = 'c';
                    break;
                case 'o':
                    expectedChar = 'r';
                    break;
                case 'a':
                    expectedChar = 'o';
                    break;
                case 'k':
                    expectedChar = 'a';
                    break;
                default:
                    break;
            }

            return expectedChar;
        }
    }
}
