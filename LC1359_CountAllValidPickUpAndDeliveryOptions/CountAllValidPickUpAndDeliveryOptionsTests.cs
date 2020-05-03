using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1359_CountAllValidPickUpAndDeliveryOptions
{
    [TestClass]
    public class CountAllValidPickUpAndDeliveryOptionsTests
    {
        [TestMethod]
        public void GivenPickupAndDeliveryNumber_CountOrders_ShouldReturnAllCount()
        {
            var n = 2;
            var result = CountOrders(n);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenAnotherPickupAndDeliveryNumber_CountOrders_ShouldReturnAllCount()
        {
            var n = 3;
            var result = CountOrders(n);

            Assert.IsTrue(result == 90);
        }

        private int CountOrders(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            var mod = 1000000000 + 7;
            var current = 1;

            for (int i = 2; i <= n; i++)
            {
                var totalSlots = i * 2;
                current = current * i * (totalSlots - 1) % mod;  
            }

            return current;
        }

    }
}
