using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC263_UglyNumber
{
    [TestClass]
    public class UglyNumberTests
    {
        [TestMethod]
        public void GivenUglyNumber_IsUglyNumber_ShouldReturnTrue()
        {
            var num = 5;

            bool result = IsUglyNumber(num);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNotUglyNumber_IsUglyNumber_ShouldReturnFalse()
        {
            var num = 2*2*3*3*5*7;

            bool result = IsUglyNumber(num);

            Assert.IsFalse(result);
        }

        private bool IsUglyNumber(int num)
        {
            var list = new List<int>() { 2, 3, 5 };

            var currentNumber = num;
            foreach (var uglyNumber in list)
            {
                while (currentNumber % uglyNumber == 0)
                {
                    currentNumber = currentNumber / uglyNumber;
                }
            }

            return currentNumber == 1;
        }
    }
}
