using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC269_AlienAlphabet
{
    [TestClass]
    public class AlienAlphabetTests
    {
        [TestMethod]
        public void GivenValidWordListOfWordsWithOneChar_FindAlphabetOrder_ShouldReturnExactSequence()
        {
            var wordList = new List<string> { "e", "d" };

            var result = FindAlphabetOrder(wordList);

            Assert.IsTrue(result.SequenceEqual(new List<char> { 'e', 'd' }));
        }

        [TestMethod]
        public void GivenWordListOfDifferentLength_FindAlphabetOrder_ShouldReturnValidSequence()
        {
            var wordList = new List<string> { "a", "aa" };

            var result = FindAlphabetOrder(wordList);

            Assert.IsTrue(result.SequenceEqual(new List<char> { 'a' }));
        }

        [TestMethod]
        public void GivenValidWordListOfSameLength_FindAlphabetOrder_ShouldReturnValidSequence()
        {
            var wordList = new List<string> {"bca", "aaa", "acb" };

            var result = FindAlphabetOrder(wordList);

            Assert.IsTrue(result.SequenceEqual(new List<char> { 'b', 'a', 'c' }));
        }

        [TestMethod]
        public void GivenInvalidWordListWithDanglingHead_FindAlphabetOrder_ShouldThrowException()
        {
            var wordList = new List<string> { "aa", "ab", "abc" };

            Assert.ThrowsException<ArgumentException>(() => FindAlphabetOrder(wordList) );
        }

        [TestMethod]
        public void GivenNullOrEmptyString_FindAlphabetOrder_ShouldThrowException()
        {
            var wordList = new List<string> { null, "ab", "abc" };

            Assert.ThrowsException<NullReferenceException>(() => FindAlphabetOrder(wordList));
        }

        [TestMethod]
        public void GivenValidComplexWordList_FindAlphabetOrder_ShouldReturnValidSequence()
        {
            var wordList = new List<string> { "abcdefg", "bcdefga", "cdefgaa", "defgaaa", "efgaaaa", "fgaaaaa", "gaaaaaaa" };

            var result = FindAlphabetOrder(wordList);

            Assert.IsTrue(result.SequenceEqual(new List<char> { 'a','b', 'c', 'd', 'e', 'f', 'g' }));
        }


        private List<char> FindAlphabetOrder(List<string> wordList)
        {
            var graph = new Dictionary<char, HashSet<char>>();
            var depth = new Dictionary<char, int>();

            InitializeGraph(wordList, graph, depth);

            MapGraph(wordList, graph, depth);

            var result = TopologicalSortBFS(graph, depth);

            return result;
        }


        private void InitializeGraph(List<string> wordList, Dictionary<char, HashSet<char>> graph, Dictionary<char, int> depth)
        {
            foreach (var word in wordList)
            {
                foreach (var c in word)
                {
                    if (!graph.ContainsKey(c))
                    {
                        graph.Add(c, new HashSet<char>());
                        depth.Add(c, 0);
                    }
                }
            }
        }


        private void MapGraph(List<string> wordList, Dictionary<char, HashSet<char>> graph, Dictionary<char, int> depth)
        {
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                var parent = wordList[i];
                var child = wordList[i + 1];

                var length = Math.Min(parent.Length, child.Length);

                for (int j = 0; j < length; j++)
                {
                    var p = parent[j];
                    var c = child[j];

                    if (p != c) // if chars are different
                    {
                        if (!graph[p].Contains(c))
                        {
                            graph[p].Add(c); // parent now have this child
                            depth[c]++;   // child is now + 1 depth from top // 
                        }

                        break; // break here to stop comparing next chars
                    }
                }
            }
        }

        private List<char> TopologicalSortBFS(Dictionary<char, HashSet<char>> graph, Dictionary<char, int> depth)
        {
            var result = new List<char>();
            var queue = new Queue<char>();
         
            // first find the char with depth of 0 and push on to queue
            foreach (var item in depth)
            {
                if (item.Value == 0)
                {
                    queue.Enqueue(item.Key);
                }
            }

            while (queue.Count != 0)
            {
                var parent = queue.Dequeue();

                if (queue.Count != 0)
                {
                    throw new ArgumentException("we have dangling nodes, this should not happen, please check input");
                }

                result.Add(parent);

                var children = graph[parent];
                // loop through each child deduct their depth, 
                // if particular child is of depth, we should enqueue it. 
                // note: if input is valid, we should always have only one child of 0 depth.
                foreach (var child in children)
                {
                    depth[child]--;
                    if (depth[child] == 0)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return result;
        }

    }
}
