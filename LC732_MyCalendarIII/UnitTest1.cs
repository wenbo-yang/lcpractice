using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC732_MyCalendarIII
{
    [TestClass]
    // use segmented tree
    public class MyCalendarIIITests
    {
        [TestMethod]
        public void GivenMyCalendarAndBookingTimes_Book_ShouldReturnNumberOfBookedSlots()
        {
            var myCalendar = new MyCalendarIII();

            var result = myCalendar.Book(10, 20);
            Assert.IsTrue(result == 1);

            result = myCalendar.Book(50, 60);
            Assert.IsTrue(result == 1);

            result = myCalendar.Book(10, 40);
            Assert.IsTrue(result == 2);

            result = myCalendar.Book(5, 15);
            Assert.IsTrue(result == 3);

            result = myCalendar.Book(5, 10);
            Assert.IsTrue(result == 3);

            result = myCalendar.Book(25, 55);
            Assert.IsTrue(result == 3);
        }

        private class MyCalendarIII
        {
            private SortedDictionary<int, int> _conflict = new SortedDictionary<int, int>();

            public int Book(int start, int end)
            {
                if (!_conflict.ContainsKey(start))
                {
                    _conflict.Add(start, 0);
                }
                _conflict[start]++;

                if (!_conflict.ContainsKey(end))
                {
                    _conflict.Add(end, 0);
                }
                _conflict[end]--;


                var count = 0; var max = 0;

                foreach (var pair in _conflict)
                {
                    count += pair.Value;
                    max = Math.Max(max, count);
                }

                return max;
            }
        }
    }


}
