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
            var meetings = new List<Tuple<int, int>> { new Tuple<int, int>(3, 4), new Tuple<int, int>(1, 3), new Tuple<int, int>(1, 2) };

            int result = GetNumberOfRequiredRooms(meetings);

            Assert.IsTrue(result == 2);
        }

        private int GetNumberOfRequiredRooms(List<Tuple<int, int>> meetings)
        {
            if(meetings.Count == 0)
            {
                return 0;
            }

            meetings.Sort();
            var result = 1;
     
            for (int i = 1; i < meetings.Count; i++)
            {
                if (meetings[i].Item1 < meetings[i - 1].Item2)
                {
                    result++;
                }
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
