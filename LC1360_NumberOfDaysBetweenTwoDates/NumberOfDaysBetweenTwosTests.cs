using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1360_NumberOfDaysBetweenTwoDates
{
    [TestClass]
    public class NumberOfDaysBetweenTwosTests
    {
        [TestMethod]
        public void GivenTwoDates_GetDaysInBetween_ShouldReturnCorrectAnswer()
        {
            var date1 = "2020-01-15"; var date2 = "2019-12-31";

            var result = GetDaysInBetween(date1, date2);

            Assert.IsTrue(result == 15);
        }

        private int GetDaysInBetween(string date1, string date2)
        {
            var dateTime1 = Convert.ToDateTime(date1);
            var dateTime2 = Convert.ToDateTime(date2);

            var diff = dateTime1 - dateTime2;

            return Math.Abs(Convert.ToInt32(diff.TotalDays));
        }
    }
}
