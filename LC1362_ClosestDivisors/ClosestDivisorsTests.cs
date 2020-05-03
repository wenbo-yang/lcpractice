using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1362_ClosestDivisors
{
    [TestClass]
    public class ClosestDivisorsTests
    {
        [TestMethod]
        public void GivenInteger_GetClosestTwoDivisors_ShouldReturnClosestDivisorPairs()
        {
            var num = 123;

            var divisors = GetClosestDivisorsForN1N2(num);

            Assert.IsTrue((divisors[0] == 5 && divisors[1] == 25) || (divisors[0] == 25 || divisors[1] == 5));
        }

        private int[] GetClosestDivisorsForN1N2(int num)
        {
            var ans1 = GetClosestDivisors(num + 1);
            var ans2 = GetClosestDivisors(num + 2);

            return Math.Abs(ans1[0] - ans1[1]) > Math.Abs(ans2[0] - ans2[1]) ? ans2 : ans1;
        }

        private int[] GetClosestDivisors(int n)
        {

            for (int i = ISqrt(n); i >= 2; i--)
            {
                if (n % i == 0)
                {
                    return new int[] { i, n / i};
                } 
            }

            return new int[] {1, n}; // prime number
        }

        private int ISqrt(int num)
        {
            if (0 == num) { return 0; }  // Avoid zero divide  
            int n = (num / 2) + 1;       // Initial estimate, never low  
            int n1 = (n + (num / n)) / 2;
            while (n1 < n)
            {
                n = n1;
                n1 = (n + (num / n)) / 2;
            } // end while  
            return n;
        } 

    }
}
