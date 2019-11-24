using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC729_MyCalendar
{
    [TestClass]
    public class MyCalendarTests
    {
        [TestMethod]
        public void GivenCalendarClassAndEmptySlot_Book_ShouldReturnTrue()
        {
            var calendar = new Calendar();
            var result = calendar.Book(10, 20);
            Assert.IsTrue(result);
            result = calendar.Book(15, 25);
            Assert.IsFalse(result);
            result = calendar.Book(20, 30);
            Assert.IsTrue(result);
        }

        private class Calendar
        {
            private List<Tuple<int, int>> _timeSlots = new List<Tuple<int, int>>();

            public Calendar()
            {
            }

            public bool Book(int lower, int upper)
            {
                var target = new Tuple<int, int>(lower, upper);
                var conflict = _timeSlots.BinarySearch(target, new ConflictComparer());

                if (conflict == -1)
                {
                    _timeSlots.Add(target);
                    _timeSlots.Sort();

                    return true;
                }

                return false;
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


}
