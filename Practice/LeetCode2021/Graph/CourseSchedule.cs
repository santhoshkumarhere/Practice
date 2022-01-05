using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.Graph
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

        private static bool CanFinishGraphColoring2022(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0)
                return true;

            var graph = new Dictionary<int, List<int>>();
            var visited = new int[numCourses];
            for(int i = 0; i < numCourses;i++)
            {
                graph[i] = new List<int>();
            }

            foreach(var item in prerequisites)
            {
                graph[item[0]].Add(item[1]);
            }

            foreach(var key in graph.Keys)
            {
                if (visited[key] == 0) //not processed
                    if (IsCyclical(key, graph, visited))
                        return false;
            }

            return true;
        }

        private static bool IsCyclical(int key, Dictionary<int, List<int>> graph, int[] visited)
        {
            if (visited[key] == 2)
                return true;
            visited[key] = 2; //processing

            foreach(var adj in graph[key])
            {
                if (visited[adj] != 1)
                    if (IsCyclical(adj, graph, visited))
                        return true;
            }
            visited[key] = 1; //processed
            return false;
        }

            private static bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            //Accepted faster
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
                if (IsCyclical(graph, key, visited, courseDone))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsCyclical(Dictionary<int, List<int>> graph, int key, bool[] visited, bool[] currentStack)
        {
            if(!graph.ContainsKey(key)) // no following courses no loop
                 return false;

            if (currentStack[key]) // loop exists so cycle
                return true;

            if (visited[key])
                return false;

            currentStack[key] = true;
            visited[key] = true;
            foreach (var adjKey in graph[key])
            {
                if (IsCyclical(graph, adjKey, visited, currentStack))
                {
                    return true;
                }
            }

            currentStack[key] = false; //remove from stack
            return false; 
        }
    }
}
