using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC326_PowerOf3
{
    // lc326, lc342
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenPowerOf3_IsPowerOfThree_ShouldReturnTrue()
        {
            var result = new PowerOf(3).Build().IsNumberPowerOf(27);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNotPowerOf3_IsPowerOfThree_ShouldReturnFalse()
        {
            var result = new PowerOf(3).Build().IsNumberPowerOf(15);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenPowerOf4_IsPowerOf_ShouldReturnTrue()
        {
            var result = new PowerOf(4).Build().IsNumberPowerOf(16);

            Assert.IsTrue(result);
        }

        public class PowerOf
        {
            private int _baseNumber;
            private int _maxPowerOf;

            public PowerOf(int baseNumber)
            {
                _baseNumber = baseNumber;
            }

            public PowerOf Build()
            {
                _maxPowerOf = 0;
                var current = _baseNumber;
                do
                {
                    _maxPowerOf = current;
                    current *= _baseNumber;
                }
                while (current > 0);

                return this;
            }

            public bool IsNumberPowerOf(int target)
            {
                return target > 0 && ((_maxPowerOf % target) == 0);
            }
        }
    }
}
