using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1381_DesignAStackWithIncrementOperation
{
    [TestClass]
    public class DesignAStackWithIncrementOperationTests
    {
        [TestMethod]
        public void GivenStackOfSize3AndAddingToMaximum_Push_ShouldDoNothing()
        {
            var stack = new CustomStack(3);
            stack.Push(1); stack.Push(2); stack.Push(3); stack.Push(4);

            var result = stack.Pop();

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenEmptyStack_Pop_ShouldReturnMinus1()
        {
            var stack = new CustomStack(3);

            var result = stack.Pop();

            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void GivenStack_AddingAndPopping_ShouldReturnCorrespondingAnswer()
        {
            var stack = new CustomStack(3);
            stack.Push(1); stack.Push(2); stack.Push(3);

            var result = stack.Pop();
            Assert.IsTrue(result == 3);

            result = stack.Pop();
            Assert.IsTrue(result == 2);

            result = stack.Pop();
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenStackAndValuesIncrementSmallerThanCurrentStackSize_Increment_IncrementCorrectStackValues()
        {
            var stack = new CustomStack(3);
            stack.Push(1); stack.Push(2); stack.Push(3);
            stack.Increment(2, 5);

            var result = stack.Pop();
            Assert.IsTrue(result == 3);

            result = stack.Pop();
            Assert.IsTrue(result == 7);

            result = stack.Pop();
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenStackAndValuesIncrementGreaterThanStackSize_Increment_IncrementAllStackValues()
        {
            var stack = new CustomStack(3);
            stack.Push(1); stack.Push(2); stack.Push(3);
            stack.Increment(3, 5);

            var result = stack.Pop();
            Assert.IsTrue(result == 8);

            result = stack.Pop();
            Assert.IsTrue(result == 7);

            result = stack.Pop();
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenStackAndValuesAndIncrementInvalidValues_Increment_ShouldDoNothing()
        {
            var stack = new CustomStack(3);
            stack.Push(1); stack.Push(2); stack.Push(3);
            stack.Increment(0, 5);

            var result = stack.Pop();
            Assert.IsTrue(result == 3);
        }

        public class CustomStack
        {
            private int[] _stack;
            private int _maxSize;
            private int _stackPointer = - 1;

            public CustomStack(int maxSize)
            {
                _stack = new int[maxSize];
                _maxSize = maxSize;
            }

            public void Push(int x)
            {
                if (_stackPointer < _maxSize - 1)
                {
                    _stack[++_stackPointer] = x;
                }
            }

            public int Pop()
            {
                if (_stackPointer == -1)
                {
                    return -1;
                }

                return _stack[_stackPointer--];
            }

            public void Increment(int k, int val)
            {
                if (k < 1)
                {
                    return;
                }

                var shouldIncrement = k;
                if (k > _stackPointer + 1)
                {
                    shouldIncrement = _stackPointer + 1;
                }

                for (int i = 0; i < shouldIncrement; i++)
                {
                    _stack[i] += val;
                }
            }
        }
    }
}
