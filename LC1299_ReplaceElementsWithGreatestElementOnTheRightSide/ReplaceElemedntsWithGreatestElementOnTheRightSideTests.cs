using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1299_ReplaceElementsWithGreatestElementOnTheRightSide
{
    [TestClass]
    public class ReplaceElemedntsWithGreatestElementOnTheRightSideTests
    {
        [TestMethod]
        public void GivenArray_ReplaceElements__ShouldReturnCorrectArray()
        {
            var array = new int[] { 17, 18, 5, 4, 6, 1};

            var result = ReplaceElements(array);

            Assert.IsTrue(result.SequenceEqual(new int[] { 18, 6, 6, 6, 1, -1 }));
        }

        private int[] ReplaceElements(int[] array)
        {
            var stack = new Stack<(int value, int index)>();

            stack.Push((-1, array.Length - 1));
            for (int i = array.Length - 1; i >= 1; i--)
            { 
                if(array[i] > stack.Peek().value)
                {
                    stack.Push((array[i], i - 1)); 
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = stack.Peek().value;
                if (stack.Peek().index == i)
                {
                    stack.Pop();
                }
            }

            return array;
        }
    }
}
