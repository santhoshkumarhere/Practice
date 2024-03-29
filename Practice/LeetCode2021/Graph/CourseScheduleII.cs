﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.Graph
{
    public class CourseScheduleII
    {
        public static void Test()
        {
            //var numCourses4 = 20;
            //var prerequisites4 = new int[][] { new int[] { 0, 10 }, new int[] { 3, 18 }, new int[] { 5, 5 }, new int[] { 6, 11 }, new int[] { 11, 14 }, new int[] { 13, 1 }, new int[] { 15, 1 }, new int[] { 17, 4 } };
            //var result4 = FindOrder(numCourses4, prerequisites4);

           
           var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 } };
            var result = FindOrder(numCourses, prerequisites);

            //var numCourses44 = 2;
            //var prerequisites44 = new int[][] {  };
            //var result44 = FindOrder(numCourses44, prerequisites44);

            //var numCourses45 = 4;
            //var prerequisites45 = new int[][] { };
            //var result45= FindOrder(numCourses45, prerequisites45);

            numCourses = 5;
            prerequisites = new int[][] { new int[] { 1, 4 }, new int[] { 2, 4 }, new int[] { 3, 1 }, new int[] { 3, 2 } };
            result = FindOrder(numCourses, prerequisites);

            var numCourses1 = 2;
            var prerequisites1 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var result1 = FindOrder(numCourses1, prerequisites1);
        }

        private static int[] FindOrder(int numCourses, int[][] prerequisites)
        {        
            var graph = new Dictionary<int, List<int>>();
            var courseDone = new bool[numCourses];
            var visited = new bool[numCourses];
            var result = new List<int>();
            if (prerequisites.Length == 0)
                return result.ToArray();

            for (var i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var item in prerequisites)
            {
                if(item != null)
                graph[item[0]].Add(item[1]);
            }

            var visitedLocal = new int[numCourses];
            foreach(var key in graph.Keys)
            {
                if (visitedLocal[key] == 0 
                        && IsCycleExists(visitedLocal, graph, key))
                        return result.ToArray();
            }

            foreach (var key in graph.Keys)
            {
                if (!visited[key])
                {
                    TopologicalSort(result, graph, key, visited);
                }
            }

           
            //foreach (var key in graph.Keys)
            //{
            //    if (IsCyclic(graph, key, visited, courseDone, result))
            //    {
            //        return new int[] {};
            //    }
            //}

            return result.ToArray();
        }

        private static bool IsCycleExists(int[] visited, Dictionary<int, List<int>> graph, int key)
        {
            if (visited[key] == 2)
                return true;

            visited[key] = 2;

            foreach (var adj in graph[key])
            {
                if (visited[adj] != 1 && IsCycleExists(visited, graph, adj))
                    return true;                
            }
            visited[key] = 1;
            return false;
        }

        private static void TopologicalSort(List<int> list, Dictionary<int, List<int>> graph, int key, bool[] visited)        
        {
            visited[key] = true;

            foreach(var adj in graph[key])
            {
                if (!visited[adj])
                    TopologicalSort(list, graph, adj, visited);
            }
            list.Add(key);
        }

        private static bool IsCyclic(Dictionary<int, List<int>> graph, int key, bool[] visited, bool[] recursiveStack, List<int> result)
        {
            if (recursiveStack[key])
                return true;
            
            if (visited[key])
                return false;

            recursiveStack[key] = true;
            visited[key] = true;

            foreach(var adjKey in graph[key])
            {
                Console.WriteLine(adjKey);
               if(IsCyclic(graph, adjKey, visited, recursiveStack, result))
               {
                    return true;
               }
               else
               {
                    if (!result.Contains(adjKey))
                    {
                        result.Add(adjKey);
                    }
               }
            }
            recursiveStack[key] = false; //remove from stack - course completed

            if (!result.Contains(key))
                result.Add(key);

            return false;
        }
    }
}
