using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC731_MyCalendarII
{
    [TestClass]
    public class MyCalenderIITests
    {
        [TestMethod]
        public void GivenCalendarAndTimeRange_Book_ShouldReturnFalseForTripleBooking()
        {
            var myCalendar = new MyCalendarII();
            var result = myCalendar.Book(10, 20);
            Assert.IsTrue(result);

            result = myCalendar.Book(50, 60);
            Assert.IsTrue(result);

            result = myCalendar.Book(10, 40);
            Assert.IsTrue(result);

            result = myCalendar.Book(5, 15);
            Assert.IsFalse(result);

            result = myCalendar.Book(5, 10);
            Assert.IsTrue(result);

            result = myCalendar.Book(25, 55);
            Assert.IsTrue(result);
        }

        private class MyCalendarII
        {
            private List<Tuple<int, int>> _singleBookedSet = new List<Tuple<int, int>>();
            private List<Tuple<int, int>> _doubleBookedSet = new List<Tuple<int, int>>();

            public bool Book(int start, int end)
            {
                var targetSlot = new Tuple<int, int>(start, end);
                var hasConflict = _singleBookedSet.BinarySearch(targetSlot, new ConflictComparer());
                if (hasConflict >= 0)
                {
                    var slot = _singleBookedSet[hasConflict];
                    var doubleBookedSlot = new Tuple<int, int>(Math.Max(slot.Item1, targetSlot.Item1), Math.Min(slot.Item2, targetSlot.Item2));

                    if (_doubleBookedSet.BinarySearch(targetSlot, new ConflictComparer()) >= 0)
                    {
                        return false;
                    }

                    _doubleBookedSet.Add(doubleBookedSlot);
                    _doubleBookedSet.Sort();
                }

                _singleBookedSet.Add(targetSlot);
                _singleBookedSet.Sort();

                return true;
            }
        }

        private class ConflictComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (y.Item2 <= x.Item1)
                {
                    return -1;
                }

                if (y.Item1 >= x.Item2)
                {
                    return 1;
                }

                return 0;
            }
        }
    }

    
}
