using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// lc 253 is here as well
namespace LC252_MeetingRooms
{
    [TestClass]
    public class MeetingRoomsTests
    {
        [TestMethod]
        public void GivenOverlappingInputArray_CanAttend_ShouldReturnFalse()
        {
            var meetings = new List<Tuple<int, int>> { new Tuple<int, int>(3, 4), new Tuple<int, int>(1, 3), new Tuple<int, int>(1, 2)};

            bool result = CanAttend(meetings);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNonOverlappingInputArray_CanAttend_ShouldReturnTrue()
        {
            var meetings = new List<Tuple<int, int>> { new Tuple<int, int>(3, 4), new Tuple<int, int>(1, 2), new Tuple<int, int>(2, 3) };

            bool result = CanAttend(meetings);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenOverlappingInputArray_GetNumRooms_ShouldReturnNumberOfRoomsRequired()
        {
            var meetings = new List<Tuple<int, int>> { new Tuple<int, int>(0, 30), new Tuple<int, int>(5, 10), new Tuple<int, int>(15, 20) };

            int result = GetNumberOfRequiredRooms(meetings);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenAnotherOverlappingInputArray_GetNumRooms_ShouldReturnNumberOfRoomsRequired()
        {
            var meetings = new List<Tuple<int, int>> { new Tuple<int, int>(1, 5), new Tuple<int, int>(2, 10), new Tuple<int, int>(5, 14), new Tuple<int, int>(10, 13) };

            int result = GetNumberOfRequiredRooms(meetings);

            Assert.IsTrue(result == 2);
        }

        private int GetNumberOfRequiredRooms(List<Tuple<int, int>> meetings)
        {
            var startTimes = new List<int>();
            var endTimes = new List<int>();

            foreach (var meeting in meetings)
            {
                startTimes.Add(meeting.Item1);
                endTimes.Add(meeting.Item2);
            }

            startTimes.Sort();
            endTimes.Sort();

            // after sorting 
            // 1 5
            // 2, 10
            // 5, 13,
            // 10, 14

            var result = 0;

            var i = 0; var j = 0;

            while (i < startTimes.Count && j < endTimes.Count)
            {
                if (endTimes[j] > startTimes[i])
                {
                    result++;
                }
                else
                {
                    j++;
                }

                i++;
            }

            return result;
        }

        private bool CanAttend(List<Tuple<int, int>> meetings)
        {
            // param validation
            if (meetings.Count < 2)
            {
                return true;
            }

            meetings.Sort();

            for (int i = 1; i < meetings.Count; i++)
            {
                if (meetings[i].Item1 < meetings[i - 1].Item2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
