using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC210_CourseScheduleII
{
    [TestClass]
    // topological sort
    public class CourseScheduleIITests
    {
        [TestMethod]
        public void GivenCourseDependenciesAndNumber_GetCourseList_ShouldReturnCorrectList()
        {
            var prerequisites = new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } };
            var numCourses = 4;

            var result = GetCourseList(prerequisites, numCourses);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 0, 1, 2, 3 }) || result.SequenceEqual(new List<int> { 0, 2, 1, 3 }));
        }

        private List<int> GetCourseList(int[][] prerequisites, int numCourses)
        {
            var children = new Dictionary<int, HashSet<int>>();
            
            var root = BuildGraph(prerequisites, numCourses, children);

            return FindDependencyGraph(root, children);
        }

        private List<int> FindDependencyGraph(int root, Dictionary<int, HashSet<int>> children)
        {
            var result = new HashSet<int>();

            if (root == -1)
            {
                return result.ToList();
            }

            var queue = new Queue<int>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                result.Add(top);
                if (children.ContainsKey(top))
                {
                    foreach (var child in children[top])
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return result.ToList();
        }

        private int BuildGraph(int[][] prerequisites, int numCourses, Dictionary<int, HashSet<int>> children)
        {
            var root = -1;
            var hasParent = new bool[numCourses];

            foreach (var dependency in prerequisites)
            {
                hasParent[dependency[0]] = true;

                if (!children.ContainsKey(dependency[1]))
                {
                    children.Add(dependency[1], new HashSet<int>());
                }
                children[dependency[1]].Add(dependency[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!hasParent[i])
                {
                    root = i;
                    break;
                }
            }

            return root;
        }
    }
}

