using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1450_NumberOfStudents
{
    [TestClass]
    public class NumberOfStudentsTests
    {
        [TestMethod]
        public void GivenStartAndEndTimeAndQuery_QueryBusyStudent_ShouldReturnCorrectNumberOfStudents()
        {
            var startTime = new int[] {1, 2, 3}; var endTime = new int[] { 3, 2, 7 }; var query = 4;
            var result = QueryBusyStudents(startTime, endTime, query);

            Assert.IsTrue(result == 1);
        }

        private int QueryBusyStudents(int[] startTime, int[] endTime, int query)
        {

            var result = 0;
            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= query && endTime[i] >= query)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
