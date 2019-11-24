using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC735_CollidingAstroid
{
    [TestClass]
    public class CollidingAstroidTests
    {
        [TestMethod]
        public void GivenAstroids_FindRemainingAstroid_ShouldReturnCorrectArray()
        {
            var astroids = new int[] { 5, 10, -10, 8 };
            var result = FindRemainingAstroidAfterCollision(astroids);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 5, 8 }));
        }

        private List<int> FindRemainingAstroidAfterCollision(int[] astroids)
        {
            var positiveStack = new Stack<int>();
            var result = new List<int>();
            for (int i = 0; i < astroids.Length; i++)
            {
                if (astroids[i] == 0)
                {
                    continue;
                }

                if (astroids[i] > 0)
                {
                    positiveStack.Push(astroids[i]);
                }
                else
                {
                    while (positiveStack.Count != 0 && positiveStack.Peek() < (-1*astroids[i]))
                    {
                        positiveStack.Pop();
                    }

                    if (positiveStack.Peek() == (-1 * astroids[i]))
                    {
                        positiveStack.Pop();
                        continue;
                    }

                    if (positiveStack.Count == 0)
                    {
                        result.Add(astroids[i]);
                    }
                }
            }

            result.AddRange(positiveStack.ToArray().Reverse());

            return result;
        }
    }
}
