using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC777_IsSwapsMatching
{
    [TestClass]
    public class IsMatchingBySwappingTests
    {
        [TestMethod]
        public void GivenTwoMatchingStringsBySwapping_IsMatchingBySwapping_ShouldReturnTrue()
        {
            var start = "RXXLRXRXLXX";
            var end =   "XRLXXRRLXXX";

            var result = IsMatchingBySwapping(start, end);

            Assert.IsTrue(result);
        }

        private bool IsMatchingBySwapping(string start, string end)
        {
            // param validation

            var sIndex = 0;
            var eIndex = 0;
            var retVal = true;
            while (sIndex < start.Length)
            {
                sIndex = FindUsefulIndex(start, sIndex);
                eIndex = FindUsefulIndex(end, eIndex);

                if (sIndex == -1 && eIndex == -1)
                {
                    break;
                }

                if (sIndex == -1 || eIndex == -1)
                {
                    retVal = false;
                    break;
                }

                if (start[sIndex] != end[eIndex])
                {
                    retVal = false;
                    break;
                }

                if (sIndex == eIndex)
                {
                    sIndex++;
                    eIndex++;
                    continue;
                }

                if (start[sIndex] == 'R' && sIndex == eIndex - 1)
                {
                    eIndex++;
                    sIndex = eIndex;
                    continue;
                }

                if (start[sIndex] == 'L' && sIndex == eIndex + 1)
                {
                    sIndex++;
                    eIndex = sIndex;
                }
            }

            return retVal;
        }

        private int FindUsefulIndex(string target, int index)
        {
            for (int i = index; i < target.Length; i++)
            {
                if (target[i] == 'R' || target[i] == 'L')
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
