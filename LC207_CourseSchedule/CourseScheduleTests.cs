using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC207_CourseSchedule
{
    [TestClass]
    public class CourseScheduleTests
    {
        [TestMethod]
        public void GivenCourseSchedule_CanCompleteCourse_ShouldReturnCorrectAnswer()
        {
            var courses = new int[][] { new int[] { 1, 0 } };
            var numCourses = 2;

            var result = CanCompleteCourses(courses, numCourses);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherCourseSchedule_CanCompleteCourse_ShouldReturnCorrectAnswer()
        {
            var courses = new int[][] { new int[] { 1, 0 } , new int[] { 2, 1}, new int[] { 1, 2} };
            var numCourses = 3;

            var result = CanCompleteCourses(courses, numCourses);

            Assert.IsFalse(result);
        }

        private enum State
        { 
            Unknown = 0,
            Visiting = 1,
            Visited = 2
        }

        private bool CanCompleteCourses(int[][] courses, int numCourses)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            var root = BuildGraph(courses, numCourses, graph);

            if (root == -1)
            {
                return false;
            }

            var visited = new State[numCourses];
            return !FindCycleDfs(graph, visited, 0);
        }

        private bool FindCycleDfs(Dictionary<int, HashSet<int>> graph, State[] visited, int root)
        {
            if (visited[root] == State.Visited) return true;
            if (visited[root] == State.Visiting) visited[root] = State.Visited;
            if (visited[root] == State.Unknown) visited[root] = State.Visiting;
            
            if (graph.ContainsKey(root))
            {
                foreach (var child in graph[root])
                {
                    if (FindCycleDfs(graph, visited, child))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int BuildGraph(int[][] courses, int numCourses, Dictionary<int, HashSet<int>> graph)
        {
            var root = -1;
            var hasParent = new bool[numCourses];
            
            foreach (var course in courses)
            {
                if (!graph.ContainsKey(course[1]))
                {
                    graph.Add(course[1], new HashSet<int>());
                }

                graph[course[1]].Add(course[0]);
                hasParent[course[0]] = true;
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (hasParent[i] == false)
                {
                    root = i;
                }
            }

            return root;
        }
    }
}
