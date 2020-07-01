using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC67_AddBinary
{
    [TestClass]
    public class AddBinaryTests
    {
        [TestMethod]
        public void GivenTwoBinaryStrings_AddBinary_ShouldReturnCorrectAnswer()
        {
            var a = "11"; var b = "1";

            var result = AddBinary(a, b);

            Assert.IsTrue(result == "100");
        }

        private string AddBinary(string a, string b)
        {
            var aIndex = a.Length - 1;
            var bIndex = b.Length - 1;
            var carry = '0';
            var stack = new Stack<char>();
            do
            {
                var digitA = aIndex >= 0 ? a[aIndex--] : '0';
                var digitB = bIndex >= 0 ? b[bIndex--] : '0';
                var result = ' ';
                (carry, result) = AddDigit(new char[] { digitA, digitB, carry});
                stack.Push(result);
            }
            while (aIndex >= 0 || bIndex >= 0);

            if (carry == '1')
            {
                stack.Push('1');
            }

            return new string(stack.ToArray());
        }

        private (char carry, char result) AddDigit(char[] array)
        {
            var numberOfOnes = array.Where(x => x== '1').Count();

            if (numberOfOnes == 3)
            {
                return ('1', '1');
            }

            if (numberOfOnes == 2)
            {
                return ('1', '0');
            }

            if (numberOfOnes == 1)
            {
                return ('0', '1');
            }

            return ('0', '0');
        }
    }
}
