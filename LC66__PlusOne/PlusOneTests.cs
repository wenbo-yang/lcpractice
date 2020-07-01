using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC66__PlusOne
{
    [TestClass]
    public class PlusOneTests
    {
        [TestMethod]
        public void GivenArray_PlusOne_ShouldReturnCorrectAnswer()
        {
            var digits = new int[] { 1, 2, 3 };

            var result = PlusOne(digits);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 2, 4 }));

        }

        [TestMethod]
        public void GivenAnotherArray_PlusOne_ShouldReturnCorrectAnswer()
        {
            var digits = new int[] { 9 };

            var result = PlusOne(digits);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 0 }));

        }

        private int[] PlusOne(int[] digits)
        {
            var carry = 1;
            var index = digits.Length - 1;
            var stack = new Stack<int>();
            do
            {
                var number = digits[index] + carry;
                carry = number >= 10 ? 1 : 0;
                stack.Push(number >= 10 ? number - 10 : number);

                index--;
            }
            while (index >= 0);

            if(carry == 1)
            {
                stack.Push(1);
            }

            return stack.ToArray();
        }
    }
}
