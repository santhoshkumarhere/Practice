using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class CourseSchedule
    {
        public static void Test()
        {
            var numCourses4 = 20;
            var prerequisites4 = new int[][] { new int[] { 0, 10 }, new int[] { 3, 18 }, new int[] { 5, 5 }, new int[] { 6, 11 }, new int[] { 11, 14 }, new int[] { 13, 1 }, new int[] { 15, 1 }, new int[] { 17, 4 } };
            var result4 = CanFinish2(numCourses4, prerequisites4);

           
           var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 } };
            var result = CanFinish2(numCourses, prerequisites);

            numCourses = 5;
            prerequisites = new int[][] { new int[] { 1, 4 }, new int[] { 2, 4 }, new int[] { 3, 1 }, new int[] { 3, 2 } };
            result = CanFinish2(numCourses, prerequisites);

            var numCourses1 = 2;
            var prerequisites1 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var result1 = CanFinish2(numCourses1, prerequisites1);
        }

        private static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0) return true;

            var result = true;
            var graph = new Dictionary<int, List<int>>();
            var courseDone = new List<int>();
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
                if (!visited[key] && !DFS(graph, key, visited, courseDone))
                {
                    return false;
                }
            }

            return result;
        }

        private static bool DFS(Dictionary<int, List<int>> graph, int key, bool[] visited, List<int> courseDone)
        {
            visited[key] = true;

            if (graph.ContainsKey(key))
            {
                foreach (var adjKey in graph[key])
                {
                    if (!visited[adjKey] && !DFS(graph, adjKey, visited, courseDone))
                    {
                        return false;
                    }
                }

                foreach (var adjKey in graph[key])
                {
                    if (!courseDone.Contains(adjKey) || courseDone.Contains(key)) // if required courses are not done && if current course is already done then cycle
                        return false;
                }
                courseDone.Add(key);
                return true;
            }
            else
            {
                courseDone.Add(key); // leaves level courses with no dependencies
                return true;
            }
        }

        private static bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0) return true;
            
            var graph = new Dictionary<int, List<int>>();
            var courseDone = new bool[numCourses];
            var visited = new bool[numCourses];
            foreach (var item in prerequisites)
            {
                if (!graph.ContainsKey(item[0]))
                {
                    graph.Add(item[0], new List<int>() { item[1] });
                }
                else
                    graph[item[0]].Add(item[1]);
            }

            foreach (var key in graph.Keys)
            {
                if (!IsReachable(graph, key, visited, courseDone))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsReachable(Dictionary<int, List<int>> graph, int key, bool[] visited, bool[] courseDone)
        {
            if (!graph.ContainsKey(key) || courseDone[key]) //last courses with no dependencies or dependency on already finished course - required  due to dictionary
            {
                courseDone[key] = true;
                return true;
            }

            if (visited[key]) // if there is a visited node but with out completion then it is cyclical
                return false;

            visited[key] = true;
            foreach (var adjKey in graph[key])
            {
                if (!IsReachable(graph, adjKey, visited, courseDone))
                {
                    return false;
                }
            }
            courseDone[key] = true;
            return true; 
        }
    }
}
