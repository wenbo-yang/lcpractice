using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC457_CircularArrayLoop
{
    [TestClass]
    public class CircularArrayLoopTests
    {
        // using fast and slow pointer
        [TestMethod]
        public void GivenCircularArray_IsCircularArray_ShouldReturnTrue()
        {
            var input = new int[] { 2, -1, 1, 2, 2 };

            var result = IsCircularArray(input);

            Assert.IsTrue(result);
        }

        private bool IsCircularArray(int[] input)
        {
            var fast = 0;
            var slow = 0;

            do
            {
                fast = GetNextFast(input, fast);
                slow = GetNextSlow(input, slow);
            }
            while (fast != slow);

            fast = GetNextFast(input, fast);
            slow = GetNextSlow(input, slow);

            if (slow == fast)
            {
                return false;
            }

            return true;
        }

        private int GetNextSlow(int[] input, int slow)
        {
            return (slow + input[slow]) % input.Length;
        }

        private int GetNextFast(int[] input, int fast)
        {
            var index = (fast + input[fast]) % input.Length;
            return (input[index] + index) % input.Length;
        }
    }
}
