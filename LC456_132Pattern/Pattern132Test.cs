using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC456_132Pattern
{
    [TestClass]
    public class Pattern132Test
    {
        [TestMethod]
        public void Given132PatternArray_Is132Pattern_ShouldReturnTrue()
        {
            var array = new int[] { 3, 1, 4, 2 };
            var result = Is132Pattern(array);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnother132PatternArray_Is132Pattern_ShouldReturnTrue()
        {
            var array = new int[] { 3, 5, 0, 3, 4 };
            var result = Is132Pattern(array);

            Assert.IsTrue(result);
        }

        private bool Is132Pattern(int[] array)
        {
            var descendingStack = new Stack<int>();
            var third = int.MinValue;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < third)
                {
                    return true;
                }

                while (descendingStack.Count != 0 && array[i] > descendingStack.Peek())
                {
                    third = descendingStack.Pop();
                }

                descendingStack.Push(array[i]);
            }

            return false;
        }
    }
}
