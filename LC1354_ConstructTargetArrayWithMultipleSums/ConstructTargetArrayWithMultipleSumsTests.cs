using System;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1354_ConstructTargetArrayWithMultipleSums
{
    [TestClass]
    public class ConstructTargetArrayWithMultipleSumsTests
    {
        [TestMethod]
        public void GivenTargetArray_IsPossible_ShouldReturnCorrectResult()
        {
            var target = new int[] { 9, 3, 5 };
            var result = IsPossible(target);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherTargetArray_IsPossible_ShouldReturnCorrectResult()
        {
            var target = new int[] { 1, 1, 1, 2};
            var result = IsPossible(target);

            Assert.IsFalse(result);
        }

        private bool IsPossible(int[] target)
        {
            var maxHeap = ConstructMaxHeap(target);
            var sum = target.Sum();

            while (maxHeap.Peek() != 1)
            {
                var remainderToAdd = -1 * (sum - maxHeap.Peek() - maxHeap.Peek());

                if (remainderToAdd < 1)
                {
                    return false;
                }

                sum = maxHeap.Peek();

                maxHeap.Pop();
                maxHeap.Add(remainderToAdd);
            }
            
            return true;
        }

        private MaxHeap<int> ConstructMaxHeap(int[] target)
        {
            var maxHeap = new MaxHeap<int>();
            foreach (var item in target)
            {
                maxHeap.Add(item);
            }

            return maxHeap;
        }
    }
}
    