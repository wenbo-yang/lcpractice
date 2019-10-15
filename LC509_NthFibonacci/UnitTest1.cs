using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC509_NthFibonacci
{
    [TestClass]
    public class UnitTest1
    {
        // fn = (phi)^(n+1)/sqrt(5) - (phi')^(n+1)/sqrt(5);

        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 1; i < 100; i++)
            {

                if (FibNth(i) < FibNth(i - 1))
                {
                    Console.WriteLine(i);
                }
            }

        }

        private ulong FibNth(int n)
        {
            ulong n_prev1 = 1;
            ulong n_prev2 = 0;

            if (n == 0)
            {
                return n_prev2;
            }

            if (n == 1)
            {
                return n_prev1;
            }

            ulong n_curr = 0;

            for (int i = 2; i <= n; i++)
            {
                n_curr = n_prev1 + n_prev2;

                n_prev2 = n_prev1;
                n_prev1 = n_curr;
            }

            return n_curr;
        }
    }
}
