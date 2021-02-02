using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class CourseSchedule
    {
        public static void Test()
        {
            var numCourses = 3;
            var prerequisites = new int[][] { new int[]{ 1, 0 }, new int[]{ 0, 2 } };
            var result = CanFinish(numCourses, prerequisites);

            numCourses = 2;
            prerequisites = new int[][] { new int[] { 1, 0 } };
            result = CanFinish(numCourses, prerequisites);

            numCourses = 2;
            prerequisites = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            result = CanFinish(numCourses, prerequisites);
        }

        private static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0 && numCourses == 1) return true;

            var stack = new Stack<int>();
            var graph = new Dictionary<int, int>();
            var visited = new bool[numCourses];
            foreach(var item  in prerequisites)
            {
                if(!graph.ContainsKey(item[0]))
                graph.Add(item[0], item[1]);
            }

            foreach(var key in graph.Keys)
            {
                if(!visited[key])
                DFS(graph, key, visited, stack);
            }

            return stack.Count == numCourses;
        }

        private static void DFS(Dictionary<int, int> graph, int key, bool[] visited, Stack<int> stack)
        {
            visited[key] = true;

            if(graph.ContainsKey(key))
            {
                var adjKey = graph[key];
                if (visited[adjKey])
                {
                    return;
                }
                else {
                    DFS(graph, adjKey, visited, stack);
                }
            }
            stack.Push(key);
        }
    }
}
