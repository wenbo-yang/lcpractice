using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC362_DesignHitCounter
{
    [TestClass]
    public class DesignHitCounterTests
    {
        [TestMethod]
        public void GivenHitCounterAndHits_GetHits_ShouldReturnListOfHits()
        {
            var counter = new HitCounter();
            counter.Hit(1);
            counter.Hit(2);
            counter.Hit(3);
            var hits = counter.GetHits(4);

            Assert.IsTrue(hits == 3);

            counter.Hit(300);
            Assert.IsTrue(counter.GetHits(300) == 4);
            Assert.IsTrue(counter.GetHits(301) == 3);
        }
    }

    public class HitCounter
    {
        private int[] _counter = new int[300];
        private int _lastTimeStamp = -1;
        private int _firstTimeStamp = -1;

        public int GetHits(int timeStamp)
        {
            UpdateWindow(timeStamp - 1);

            return CountHits();
        }

        private int CountHits()
        {
            var total = 0;
            for (int i = _firstTimeStamp; i <= _lastTimeStamp; i++)
            {
                total += _counter[i % 300];
            }

            return total;
        }

        private void UpdateWindow(int timeStamp)
        {
            if (_firstTimeStamp == -1)
            {
                _firstTimeStamp = timeStamp;
            }


            if (timeStamp - _lastTimeStamp >= 300)
            {
                _counter = new int[300];

                _firstTimeStamp = timeStamp;
            }
            else if (timeStamp - _firstTimeStamp >= 300)
            {
                _firstTimeStamp = timeStamp - (300 - 1);

                var temp = _firstTimeStamp;
                do
                {
                    temp--;
                    _counter[temp % 300] = 0;
                }
                while (temp % 300 != 0);
            }

            _lastTimeStamp = timeStamp;
        }

        public void Hit(int timeStamp)
        {
            UpdateWindow(timeStamp - 1);
            _counter[_lastTimeStamp % 300]++;
        }
    }
}
