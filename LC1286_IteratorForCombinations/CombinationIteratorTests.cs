using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1286_IteratorForCombinations
{
    [TestClass]
    public class CombinationIteratorTests
    {
        [TestMethod]
        public void GivenStringAndCombinationIterator_GetNext_ShouldReturnReturnNext()
        {
            var iterator = new CombinationIterator("abc", 2).Build();

            Assert.IsTrue(iterator.HasNext());
            Assert.IsTrue(iterator.GetNext() == "ab");
        }

        [TestMethod]
        public void GivenStringAndCombinationIterator_GetNextMultipleTimes_ShouldReturnReturnNext()
        {
            var iterator = new CombinationIterator("abc", 2).Build();

            Assert.IsTrue(iterator.GetNext() == "ab");
            Assert.IsTrue(iterator.GetNext() == "ac");
        }

        [TestMethod]
        public void GivenStringAndCombinationIterator_GetNextAll_ShouldReturnReturnNext()
        {
            var iterator = new CombinationIterator("abc", 2).Build();

            Assert.IsTrue(iterator.GetNext() == "ab");
            Assert.IsTrue(iterator.GetNext() == "ac");
            Assert.IsTrue(iterator.GetNext() == "bc");
        }

        public class CombinationIterator
        {
            private string _sourceString;
            private int _length;
            private string _current;
            private List<int> _usedIndices = new List<int>();
            private string _last;


            public CombinationIterator(string sourceString, int length)
            {
                _sourceString = sourceString;
                _length = length;
            }

            public CombinationIterator Build()
            {
                _last = _sourceString.Substring(_sourceString.Length - _length + 1);
                
                return this;
            }

            public string GetNext()
            {
                if (string.IsNullOrEmpty(_current))
                {
                    _current = _sourceString.Substring(0, _length);

                    for (int i = 0; i < _length; i++) _usedIndices.Add(i);

                    return _current;
                }

                _current = ConstructFromCurrent(_usedIndices, _sourceString);

                return _current;
            }

            public bool HasNext()
            {
                return _current != _last;
            }

            private string ConstructFromCurrent(List<int> usedIndices, string sourceString)
            {
                var lastIndex = sourceString.Length - 1;

                var shouldIncrement = ShouldIncrement(usedIndices, sourceString);

                if (shouldIncrement == -1)
                {
                    throw new Exception("should not call this");
                }

                usedIndices[shouldIncrement]++;

                for (int i = shouldIncrement + 1; i < usedIndices.Count; i++)
                {
                    usedIndices[i] = usedIndices[i - 1] + 1;
                }

                var index = 0;
                var current = "";
                for (int i = 0; i < sourceString.Length; i++)
                {
                    if (usedIndices[index] == i)
                    {
                        current += sourceString[i];
                        index++;
                    }
                }

                return current;
            }

            private int ShouldIncrement(List<int> usedIndices, string sourceString)
            {
                var last = sourceString.Length - 1;
                var currentIndex = usedIndices.Count - 1;
                for (int i = 0; i < usedIndices.Count; i++)
                {
                    if (usedIndices[currentIndex - i] == last - i)
                    {
                        continue;
                    }

                    return currentIndex - i;
                }

                return -1;
            }
        }
    }


}
