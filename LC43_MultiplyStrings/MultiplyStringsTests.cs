using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC43_MultiplyStrings
{
    [TestClass]
    public class MultiplyStringsTests
    {
        [TestMethod]
        public void GivenStrings_Multiply_ShouldReturnCorrectString()
        {
            var num1 = "2"; var num2 = "32";

            var result = Multiply(num1, num2);

            Assert.IsTrue(result == "64");
        }

        [TestMethod]
        public void GivenAnotherStrings_Multiply_ShouldReturnCorrectString()
        {
            var num1 = "123"; var num2 = "456";

            var result = Multiply(num1, num2);

            Assert.IsTrue(result == "56088");
        }

        private string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            var smaller = num1.Length > num2.Length ? num2 : num1;
            var bigger = num1.Length <= num2.Length ? num2 : num1;

            var list = new List<List<char>>();
            var carry = 0;
            for (int i = smaller.Length - 1; i >= 0; i--)
            {
                list.Add(new List<char>());

                var diff = smaller.Length - 1 - i;
                while (diff-- > 0)
                {
                    list[list.Count - 1].Add('0');
                }

                carry = 0;
                var num = smaller[i] - '0';
                for (int j = bigger.Length - 1; j >= 0; j--)
                {
                    var result = (bigger[j] - '0') * num + carry;
                    carry = result / 10;
                    list[list.Count - 1].Add((char)(result - (result / 10) * 10 + '0'));
                }

                if (carry != 0) list[list.Count - 1].Add((char)(carry + '0')); 
            }

            var stack = new Stack<char>();
            carry = 0;
            var index = 0;

            while (index < list[list.Count - 1].Count)
            {
                var result = 0;
                
                for (int i = 0; i < list.Count; i++)
                {
                    if (index < list[i].Count)
                    {
                        result += list[i][index] - '0';
                    }
                }

                result += carry;
                carry = result / 10;
                stack.Push((char)(result - result / 10 * 10 + '0'));
                index++;
            }

            if (carry != 0) stack.Push((char)(carry + '0'));

            return new string(stack.ToArray());
        }
    }
}
