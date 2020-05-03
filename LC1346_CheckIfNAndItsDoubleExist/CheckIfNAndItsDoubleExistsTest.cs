using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1346_CheckIfNAndItsDoubleExist
{
    [TestClass]
    public class CheckIfNAndItsDoubleExistsTest
    {
        [TestMethod]
        public void GivenArrayWith5And10_CheckNAndItsDouble_ShouldReturnTrue()
        {
            var array = new int[] { 10, 2, 5, 3 };

            var result = CheckIfNAndItsDoubleExists(array);

            Assert.IsTrue(result);
        }

        private bool CheckIfNAndItsDoubleExists(int[] array)
        {
            var hashSet = new HashSet<int>();

            foreach (var item in array)
            {
                if (hashSet.Contains(item * 2) || (item % 2 == 0 && hashSet.Contains(item / 2)))
                {
                    return true;
                }

                hashSet.Add(item);
            }

            return false;
        }
    }
}
