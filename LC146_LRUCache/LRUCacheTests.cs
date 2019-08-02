using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC146_LRUCache
{
    [TestClass]
    public class LRUCacheTests
    {
        public class LRUCache
        {
            private readonly LinkedList<int> _list = new LinkedList<int>();
            private readonly Dictionary<int, LinkedListNode<int>> _map = new Dictionary<int, LinkedListNode<int>>();

            private readonly int _capacity;

            public LRUCache(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (_map.ContainsKey(key))
                {
                    var value = _map[key].Value;
                    _list.Remove(_map[key]);
                    _map[key] = _list.AddFirst(value);
                    return value;
                }

                return -1;
            }

            public void Put(int key, int value)
            {
                if (_map.ContainsKey(key))
                {
                    _list.Remove(_map[key]);
                    _map.Remove(key);
                }

                _map.Add(key, _list.AddFirst(value));

                if (_list.Count > _capacity)
                {
                    _map.Remove(_list.Last.Value);
                    _list.RemoveLast();
                }
            }
        }


        [TestMethod]
        public void GivenPutOperation_LRUCache_ShouldAdd()
        {
            var cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.IsTrue(cache.Get(1) == 1);

            cache.Put(3, 3);
            Assert.IsTrue(cache.Get(2) == -1);

            cache.Put(4, 4);
            Assert.IsTrue(cache.Get(1) == -1);

            Assert.IsTrue(cache.Get(3) == 3);
            Assert.IsTrue(cache.Get(4) == 4);
        }
    }
}
