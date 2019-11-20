using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC346_MovingWindowAverage
{
    [TestClass]
    public class MovingAverageTests
    {
        [TestMethod]
        public void GivenWindowSize_Next_ShouldCalculateTheMovingAverage()
        {
            var movingAverage = new WindowedAverage(3);

            Assert.IsTrue(movingAverage.Next(1) == 1);
            Assert.IsTrue(movingAverage.Next(10) == Convert.ToDouble((1 + 10)) / 2);
            Assert.IsTrue(movingAverage.Next(3) == Convert.ToDouble((1 + 10 + 3)) / 3);
            Assert.IsTrue(movingAverage.Next(5) == Convert.ToDouble((10 + 3 + 5)) / 3);
        }
    }

    public class WindowedAverage
    {
        private Queue<int> queue = new Queue<int>();
        private int _size;
        private int _sum = 0;

        public WindowedAverage(int size)
        {
            _size = size;
        }

        public Double Next(int number)
        {
            queue.Enqueue(number);
            _sum += number;

            if (queue.Count > _size)
            {
                _sum -= queue.Dequeue();
            }

            return Convert.ToDouble(_sum) / queue.Count;
        }
    }
}
