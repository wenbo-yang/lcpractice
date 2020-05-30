using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1441_BuildAnArrayWithStackOperations
{
    [TestClass]
    public class BuildAnArrayWithStackOperationsTests
    {
        [TestMethod]
        public void GivenArrayAndNumber_BuildWithStackOperations_ShouldReturnCorrectStackOperations()
        {
            var target = new int[] { 1, 2 }; var n = 2;
            var result = BuildArrayWithStackOperations(target, n);
            Assert.IsTrue(result.SequenceEqual(new List<string> { "Push", "Push"}));
        }

        private List<string> BuildArrayWithStackOperations(int[] target, int n)
        {
            var result = new List<string> { "Push"};

            var index = 0;
            var currentTop = 1;
            var currentStackSize = 1;

            while (index < target.Length)
            {
                if (target[index] == currentTop)
                {
                    if (currentStackSize == index + 1)
                    {
                        index++;
                        continue;
                    }
                }
                else
                {
                    if (currentStackSize == index + 1)
                    {
                        result.Add("Pop");
                        currentStackSize--;
                    }

                    result.Add("Push");
                    currentStackSize++;
                    currentTop++;
                }
            }

            return result;
        }
    }
}
