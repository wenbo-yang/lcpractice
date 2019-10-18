using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC380_GetRandom
{
    // insert, remove and getrandom in O(1)
    // idea counter pointing list and hashtable
    [TestClass]
    public class GetRandomRemoveInsertInO1Tests
    {
        [TestMethod]
        public void GivenRandomSet_InsertAndGet_ShouldReturnTheInsertedNumber()
        {
            var randomSet = new RandomSet();

            randomSet.Insert(0);
            var result = randomSet.GetRandom();

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenRandomSet_InsertAndDelete_ShouldNotThrowException()
        {
            var randomSet = new RandomSet();
            randomSet.Insert(0);
            randomSet.Insert(2);

            Assert.IsTrue(randomSet.Count == 2);

            randomSet.Delete(0);
            Assert.IsTrue(randomSet.Count == 1);
        }

        public class RandomSet
        {
            private readonly Dictionary<int, int> table = new Dictionary<int, int>();
            private readonly List<int> values = new List<int>();

            public int GetRandom()
            {
                if (values.Count == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var random = new Random().Next(values.Count - 1);
                return values[random];
            }

            public void Insert(int number)
            {
                if (table.ContainsKey(number))
                {
                    return;
                }

                values.Add(number); // add to list
                table.Add(number, values.Count - 1); // insert the index
            }

            // list.removeat is O(N) average, but removeat(last item) is O(1)
            // so swap to the end and removeat(count - 1)
            // also update the 
            public void Delete(int number)
            {
                if (!table.ContainsKey(number)) // don't do anything if no such number
                {
                    return;
                }

                var index = table[number];
                SwapAndRemove(index, values.Count - 1);
            }

            public int Count => table.Count;

            private void SwapAndRemove(int index1, int index2)
            {
                table[values[index2]] = index1;
                values[index1] = values[index2];
                values.RemoveAt(values.Count - 1);
                table.Remove(index1);
            }
        }
    }
}
