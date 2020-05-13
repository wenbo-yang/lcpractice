using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC460_LFUCache
{
    [TestClass]
    public class LeastFrequentlyUsedCacheTests
    {
        [TestMethod]
        public void GivenLFUCache_Put_ShouldPutKeyValuePairIntoTheCache()
        {
            var cache = new LFUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.IsTrue(cache.Get(1) == 1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Assert.IsTrue(cache.Get(2) == -1);       // returns -1 (not found)
            Assert.IsTrue(cache.Get(3) == 3);       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            Assert.IsTrue(cache.Get(1) == -1);       // returns -1 (not found)
            Assert.IsTrue(cache.Get(3) == 3);       // returns 3
            Assert.IsTrue(cache.Get(4) == 4);       // returns 4
        }

        private class LFUCache
        {
            private LinkedList<int> _list = new LinkedList<int>();
            private Dictionary<int, int> _cache = new Dictionary<int, int>();
            private Dictionary<int, LinkedListNode<int>> _keyToListMapping = new Dictionary<int, LinkedListNode<int>>();
            private int _capacity = 0;

            public LFUCache(int capacity)
            {
                _capacity = capacity;
            }

            public void Put(int key, int value)
            {
                if (_cache.Count == _capacity)
                {
                    var node = _list.Last;
                    _keyToListMapping.Remove(node.Value);
                    _cache.Remove(node.Value);
                    _list.RemoveLast();
                }

                if (!_cache.ContainsKey(key))
                {
                    _cache.Add(key, 0);
                }

                _cache[key] = value;

                if (_keyToListMapping.ContainsKey(key))
                {
                    _list.Remove(_keyToListMapping[key]);
                }

                _keyToListMapping.Add(key, new LinkedListNode<int>(key));
                _list.AddFirst(_keyToListMapping[key]);
            }

            public int Get(int key)
            {
                if (_keyToListMapping.ContainsKey(key))
                {
                    var nodeToRemove = _keyToListMapping[key];
                    _list.Remove(nodeToRemove);
                    _keyToListMapping[key] = new LinkedListNode<int>(key);
                    _list.AddFirst(_keyToListMapping[key]);

                    return _cache[key];
                }

                return -1;
            }
        }
    }
}
