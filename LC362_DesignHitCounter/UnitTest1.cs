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

            Assert.IsTrue(counter.GetHits(4) == 3);

            counter.Hit(300);
            Assert.IsTrue(counter.GetHits(300) == 4);
            Assert.IsTrue(counter.GetHits(301) == 3);
        }
    }

    public class HitCounter
    {
    }
}
