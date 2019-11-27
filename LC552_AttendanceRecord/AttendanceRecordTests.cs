using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC552_AttendanceRecord
{
    [TestClass]
    // leetcode 551 is here as well
    public class AttendanceRecordTests
    {
        [TestMethod]
        public void GivenAttendanceIsOnlyOneAbsenceAndTwoLatesString_ShouldGetAward_ShouldReturnTrue()
        {
            var attendance = "PPALLP";

            var result = ShouldGetAward(attendance);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAttendanceWithThreeLates_ShouldGetAward_ShouldReturnFalse()
        {
            var attendance = "PPALLL";

            var result = ShouldGetAward(attendance);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenLengthOfThePeriod_GetNumberOfWays_ShouldReturnNumberOfWays()
        {
            var period = 2;

            var result = GetNumberOfWays(period);

            Assert.IsTrue(result == 8);
        }

        private int GetNumberOfWays(int period)
        {
            var dp = new (int numOfWays, int numSingleL, int numDoubleL)[period + 1];
            dp[0] = (1, 0, 0);

            for (int i = 1; i <= period; i++)
            {
                dp[i].numOfWays = dp[i - 1].numOfWays * 2 - dp[i - 1].numDoubleL;
                dp[i].numSingleL = dp[i - 1].numOfWays - dp[i - 1].numSingleL - dp[i - 1].numDoubleL;
                dp[i].numDoubleL = dp[i - 1].numSingleL;
            }

            var result = dp[period].numOfWays;

            for (int indexOfA = 1; indexOfA <= period; indexOfA++)
            {
                var temp = dp[indexOfA - 1].numOfWays * dp[period - indexOfA].numOfWays;

                result += temp;
            }

            return result;
        }

        private bool ShouldGetAward(string attendance)
        {
            int numberOfAbsence = 0;

            for (int i = 0; i < attendance.Length; i++)
            {
                if (attendance[i] == 'A')
                {
                    numberOfAbsence++;
                    if (numberOfAbsence > 1)
                    {
                        return false;
                    }
                }
                else if (attendance[i] == 'L' && IsTheThirdLate(attendance, i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsTheThirdLate(string attendance, int i)
        {
            return i >= 2 && attendance[i - 1] == 'L' && attendance[i - 2] == 'L';
        }
    }
}
