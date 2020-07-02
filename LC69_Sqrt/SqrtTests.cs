using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC69_Sqrt
{
    [TestClass]
    public class SqrtTests
    {
        [TestMethod]
        public void GivenInteger_Sqrt_ShouldReturnCorrectAnswer()
        {
            var x = 4;

            var result = Sqrt(x);

            Assert.IsTrue(result == 2);
        }

        private int Sqrt(int a)
        {
            double epsilon = 1e-2;
            double x = a;
            while (x * x - a > epsilon)
            {
                x = (x + a / x) / 2.0;
            }
            return Convert.ToInt32(Math.Truncate(x));
        }
    }
}
