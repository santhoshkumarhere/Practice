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
            var prerequisites = new int[][] { new int[] { 1, 0 }, new int[] { 0, 2 } };
            var result = CanFinish(numCourses, prerequisites);

            numCourses = 2;
            prerequisites = new int[][] { new int[] { 1, 0 } };
            result = CanFinish(numCourses, prerequisites);

            numCourses = 5;
            prerequisites = new int[][] { new int[] { 1, 4 }, new int[]{2, 4}, new int[]{3, 1}, new int[] { 3, 2 } };
            result = CanFinish(numCourses, prerequisites);

            var numCourses1 = 2;
            var prerequisites1 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
           var  result1 = CanFinish(numCourses1, prerequisites1);
        }

        private static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0) return true;

            var result = false;
            var graph = new Dictionary<int, List<int>>();
            var stack = new Stack<int>();
            var visited = new bool[numCourses];
            foreach(var item  in prerequisites)
            {
                if(!graph.ContainsKey(item[0]))
                {
                    graph.Add(item[0], new List<int>() { item[1] });
                }
                else
                graph[item[0]].Add(item[1]);
            }

            foreach(var key in graph.Keys)
            {
                if(!visited[key])
                    result = DFS(graph, key, visited, stack);
            }

            return result;
        }

        private static bool DFS(Dictionary<int, List<int>> graph, int key, bool[] visited, Stack<int> stack)
        {
            visited[key] = true;

            if (graph.ContainsKey(key))
            {
                foreach (var adjKey in graph[key])
                {
                    if (!visited[adjKey])
                    {
                       var canFinish =  DFS(graph, adjKey, visited, stack);
                        if (false)
                        {
                            return false;
                        }
                    }
                }

                var finishedDependencies = true;
                foreach (var adjKey in graph[key])
                {
                    if (!stack.Contains(adjKey))
                        return false;
                }
                stack.Push(key);
                return true;
            }
            else
            {
                stack.Push(key);
                return true;
            }
        }
    }
}
