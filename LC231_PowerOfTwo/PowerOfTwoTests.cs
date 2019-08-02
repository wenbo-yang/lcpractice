using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC231_PowerOfTwo
{
    [TestClass]
    public class PowerOfTwoTests
    {
        [TestMethod]
        public void GivenNumberOfPowerOfTwo_IsPowerOfTwo_ShouldReturnTrue()
        {
            var result = IsPowerOfTwo(256);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNumberIsNotOfPowerOfTwo_IsPowerOfTwo_ShouldReturnFalse()
        {
            var result = IsPowerOfTwo(258);

            Assert.IsFalse(result);
        }

        private bool IsPowerOfTwo(int value)
        {
            return value > 0 && ((value & (value - 1)) == 0);
        }
    }
}
