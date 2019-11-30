using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC379_DesignPhoneDirectory
{
    [TestClass]
    public class PhoneDirectoryTests
    {
        [TestMethod]
        public void GivenPhoneDirectory_Get_ShouldReturnTheFirstAvailablePhoneNumber()
        {
            var phoneDirectory = new PhoneDirectory(3).Build();
            Assert.IsTrue(phoneDirectory.Get() == 0);

            Assert.IsTrue(phoneDirectory.Get() == 1);

            Assert.IsTrue(phoneDirectory.Check(2));

            Assert.IsTrue(phoneDirectory.Get() == 2);

            Assert.IsFalse(phoneDirectory.Check(2));
            phoneDirectory.Release(2);

            Assert.IsTrue(phoneDirectory.Check(2));

        }

        private class PhoneDirectory
        {
            private int _capacity;
            private Queue<int> _availablePool = new Queue<int>();
            private HashSet<int> _usedPool = new HashSet<int>();

            public PhoneDirectory(int capacity)
            {
                _capacity = capacity;
            }

            public PhoneDirectory Build()
            {
                for (int i = 0; i < _capacity; i++)
                {
                    _availablePool.Enqueue(i);
                }

                return this;
            }

            public int Get()
            {
                if (_availablePool.Count == 0)
                {
                    return -1;
                }

                var top = _availablePool.Dequeue();
                _usedPool.Add(top);

                return top;
            }

            public bool Check(int number)
            {
                return !_usedPool.Contains(number) && number < _capacity && number >= 0;
            }

            public void Release(int number)
            {
                if (number < 0 || number >= _capacity)
                {
                    throw new ArgumentException();
                }

                if (_usedPool.Contains(number))
                {
                    _usedPool.Remove(number);
                    _availablePool.Enqueue(number);
                }
            }
        }
    }


}
