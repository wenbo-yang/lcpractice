using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G1_RangeQueryLetter
{
    [TestClass]
    public class RangeQueryLetterTests
    {
        [TestMethod]
        public void GivenListOfRangesLetters_RangeQueryLetter_ShouldReturnListOfLetters()
        {
            var input = new List<Tuple<int, int, char>> { new Tuple<int, int, char>(0, 4, 'X'), new Tuple<int, int, char>(3, 6, 'Y'), new Tuple<int, int, char>(5, 7, 'Z') };
            var rangeQueryLetter = new RangeQueryLetter().Build(input);
            var result = rangeQueryLetter.Query(0, 3);

            Assert.IsTrue(result.Count == 1 && result.First() == 'X');

            result = rangeQueryLetter.Query(3, 4);

            Assert.IsTrue(result.Count == 2 && result.Contains('X') && result.Contains('Y'));

            result = rangeQueryLetter.Query(5, 6);

            Assert.IsTrue(result.Count == 2 && result.Contains('Y') && result.Contains('Z'));
        }

        [TestMethod]
        public void GivenAnotherListOfRangesLetters_RangeQueryLetter_ShouldReturnListOfLetters()
        {
            var input = new List<Tuple<int, int, char>> { new Tuple<int, int, char>(0, 4, 'X'), new Tuple<int, int, char>(3, 4, 'Y'), new Tuple<int, int, char>(5, 7, 'Z') };
            var rangeQueryLetter = new RangeQueryLetter().Build(input);

            var result = rangeQueryLetter.Query(0, 5);
            Assert.IsTrue(result.Count == 2 && result.Contains('X') && result.Contains('Y'));
        }


        public class RangeQueryLetter
        {
            private readonly List<Tuple<int, bool, char>> _rangeList = new List<Tuple<int, bool, char>>();

            public RangeQueryLetter Build(List<Tuple<int, int, char>> input)
            {
                foreach (var range in input)
                {
                    _rangeList.Add(new Tuple<int, bool, char>(range.Item1, true, range.Item3));
                    _rangeList.Add(new Tuple<int, bool, char>(range.Item2, false, range.Item3));
                }

                _rangeList.Sort();
                return this;
            }

            public HashSet<char> Query(int start, int end)
            {
                if (start < _rangeList.First().Item1)
                {
                    start = _rangeList.First().Item1;
                }

                var result = new HashSet<char>();
                foreach (var range in _rangeList)
                {
                    if (range.Item1 >= end)
                    {
                        break;
                    }

                    if (range.Item2)
                    {
                        result.Add(range.Item3);
                    }
                    else if (range.Item1 < start)
                    {
                        result.Remove(range.Item3);
                    }
                }

                return result;
            }
        }
    }
}
