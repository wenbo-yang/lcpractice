using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC126_WordLadder
{
    [TestClass]
    public class WordLadderTests
    {
        [TestMethod]
        // use bfs to contruct graph dfs to search
        public void GivenListOfWord_WordLadder_ShouldContructListOfOutputs()
        {
            var list = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            List<List<string>> results = WordLadder(list, "hit", "cog");

            Assert.IsTrue(results.Count == 2);
            Assert.IsTrue(results[0].SequenceEqual(new List<string>() { "hit", "hot", "dot", "dog", "cog" }));
            Assert.IsTrue(results[1].SequenceEqual(new List<string>() { "hit", "hot", "lot", "log", "cog" }));
        }

        private List<List<string>> WordLadder(List<string> list, string begin, string end)
        {
            var graphNode = new Dictionary<string, List<string>>();
            var set = new HashSet<string>(list);
            var queue = new Queue<string>();

            set.Remove(begin);
            queue.Enqueue(begin);
            
            while (set.Count != 0)
            {
                var count = queue.Count;
                var nodeToRemove = new HashSet<string>();
                var index = 0;
                while (index++ < count)
                {
                    var nextNodeKey = queue.Dequeue();
                    var nextNodeChildren = GetNextClosestStringFromList(nextNodeKey, set);
                    graphNode.Add(nextNodeKey, new List<string>());

                    foreach (var child in nextNodeChildren)
                    {
                        queue.Enqueue(child);
                        nodeToRemove.Add(child);
                        graphNode[nextNodeKey].Add(child);
                    }
                }

                foreach (var item in nodeToRemove)
                {
                    set.Remove(item);
                }
            }

            var results = new List<List<string>>();
            FindPathDFS(graphNode, new List<string>() { begin }, results, end);

            return results;
        }

        private void FindPathDFS(Dictionary<string, List<string>> graphNode, List<string> currentResult, List<List<string>> results, string end)
        {
            if (currentResult.Count > 0 && currentResult[currentResult.Count - 1] == end)
            {
                results.Add(new List<string>(currentResult));
                return;
            }

            if (graphNode.ContainsKey(currentResult[currentResult.Count - 1]))
            {
                var children = graphNode[currentResult[currentResult.Count - 1]];
                for (int i = 0; i < children.Count; i++)
                {
                    currentResult.Add(children[i]);
                    FindPathDFS(graphNode, currentResult, results, end);
                    currentResult.RemoveAt(currentResult.Count - 1);
   
                }
            }
        }

        private HashSet<string> GetNextClosestStringFromList(string target, HashSet<string> list)
        {
            var results = new HashSet<string>();
            foreach(var item in list)
            {
                var matches = 0;
                for (int i = 0; i < target.Length; i++)
                {
                    if (target[i] == item[i])
                    {
                        matches++;
                    }
                }

                if (matches == target.Length - 1)
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }
}
