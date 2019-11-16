using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC802_EventualSafeNode
{
    [TestClass]
    public class EventualSafeGraph
    {
        [TestMethod]
        public void GivenEventualSafeGraph_FindEventualSafeNode_ShouldReturnListOfNodes()
        {
            var graph = new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 2, 3 }, new List<int> { 5 }, new List<int> { 0 }, new List<int> { 5 }, new List<int>(), new List<int>() };
            var result = FindEventualSafeDFS(graph);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 2, 4, 5, 6 }));
        }

        private enum States
        {
            Unknown = 0,
            Visiting,
            Unsafe,
            Safe
        }

        private List<int> FindEventualSafeDFS(List<List<int>> graph)
        {
            var result = new List<int>();
            for (int i = 0; i < graph.Count; i++)
            {
                var visited = new States[graph.Count];
                if (FindEventualSafeDFSHelper(i, graph, visited) == States.Safe)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private States FindEventualSafeDFSHelper(int currentNode, List<List<int>> graph, States[] states)
        {
            if (states[currentNode] == States.Visiting)
            {
                states[currentNode] = States.Unsafe;
                return States.Unsafe;
            }

            if (states[currentNode] != States.Unknown)
            {
                return states[currentNode];
            }

            states[currentNode] = States.Visiting;

            foreach(var node in graph[currentNode])
            {
                if (FindEventualSafeDFSHelper(node, graph, states) == States.Unsafe)
                {
                    states[currentNode] = States.Unsafe;
                    return States.Unsafe;
                }
            }

            return states[currentNode] = States.Safe;
        }
    }
}
