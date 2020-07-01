using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC50_Power
{
    [TestClass]
    public class PowerOfDoubleTests
    {
        [TestMethod]
        public void GivenBaseAndPower_Compute_ShouldReturnCorrectAnswer()
        {
            var result = PowerOf(2.0, 10);

            Assert.IsTrue(result == 1024);
        }

        [TestMethod]
        public void GivenAnotherBaseAndPower_Compute_ShouldReturnCorrectAnswer()
        {
            var result = PowerOf(2.0, -2147483648);

            Assert.IsTrue(result == 0);
        }

        private double PowerOf(double num, long power)
        {
            if (num == 0 || num == 1)
            {
                return num;
            }

            var isNegative = power < 0;
            power = isNegative ? -1 * power : power;

            var mem = new Dictionary<long, double>();

            var result = PowerOfHelper(num, power, mem);

            return isNegative ? 1.0 / result : result; 
        }

        private double PowerOfHelper(double num, long power, Dictionary<long, double> mem)
        {
            if (power == 1)
            {
                return num;
            }

            if (power == 0)
            {
                return 1;
            }

            if (mem.ContainsKey(power))
            {
                return mem[power];
            }

            var pivot = power / 2;

            mem.Add(power, PowerOfHelper(num, pivot, mem) * PowerOfHelper(num, power - pivot, mem));

            return mem[power];
        }
    }
}
