using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1399_CountLargestGroup
{
    [TestClass]
    public class CountLargestGroupTests
    {
        [TestMethod]
        public void GivenGroupArrays_CountLargestGroup_ShouldReturnLargestGroup()
        {
            var n = 24;
            var result = CountLargestGroup(n);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenAnotherGroupArrays_CountLargestGroup_ShouldReturnLargestGroup()
        {
            var n = 2;
            var result = CountLargestGroup(n);

            Assert.IsTrue(result == 1);
        }

        private int CountLargestGroup(int n)
        {
            if (n < 10)
            {
                return n;
            }

            var upperBound = GetUpperBound(n);

            var table = new int[upperBound + 1];

            var sum = new int[n + 1];

            for (int i = 1; i < 10; i++)
            {
                sum[i] = i;
                table[sum[i]]++;
            }

            for (int i = 10; i <= n; i++)
            {
                var divider = GetDivider(i);
                var mSD = i / divider;
                var remainder = i % divider;

                sum[i] = sum[remainder] + mSD;

                table[sum[i]]++;
            }

            var max = table.Max();
            return table.Where(x => x == max).AsEnumerable().ToArray().Length;
        }

        private int GetDivider(int n)
        {
            if (n >= 1000)
            {
                return 1000;
            }
            else if (n >= 100)
            {
                return 100;
            }
            else if (n >= 10)
            {
                return 10;
            }

            return 1;
        }

        private int GetUpperBound(int n)
        {
            var count = 0;
            while (n != 0)
            {
                count++;
                n /= 10;
            }

            return count * 9;
        }
    }
}
