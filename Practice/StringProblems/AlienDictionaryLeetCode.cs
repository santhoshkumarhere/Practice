using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.StringProblems
{
    class AlienDictionaryLeetCode
    {

        public static void Test()
        {
            var res = AlienOrder(new string[] { "abc", "ab" }); 

            var res1 = AlienOrder(new string[] { "wrt", "wrf", "er", "ett", "rftt" });
        }

        private static string AlienOrder(string[] words)
        {
            var n = words.Length;
            var longestLength = words.Max(c => c.Length);

            var adjacencyMatrix = new Dictionary<char, HashSet<char>>();
            var indegrees = new Dictionary<char, int>();

            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (!adjacencyMatrix.ContainsKey(c))
                    {
                        adjacencyMatrix[c] = new HashSet<char>();
                        indegrees[c] = 0;
                    }
                }
            }


            for (int j = 0; j < longestLength; j++)
            {
                for (int i = 1; i < n; i++)
                {
                    var pre = words[i - 1];
                    var cur = words[i];
                    if (j < pre.Length && j < cur.Length && pre.Substring(0, j) == cur.Substring(0, j))
                    {
                        var preWordChar = pre[j];
                        var curWordChar = cur[j];

                        if (preWordChar != curWordChar)
                        {
                            if (!adjacencyMatrix[preWordChar].Contains(curWordChar))
                            {
                                indegrees[curWordChar]++;
                                adjacencyMatrix[preWordChar].Add(curWordChar);
                            }
                        }
                    }
                }
            }

            var queue = new Queue<char>();

            foreach (var keyAndValue in indegrees)
            {
                if (keyAndValue.Value == 0)
                {
                    queue.Enqueue(keyAndValue.Key);
                }
            }

            var result = new List<char>();
            while (queue.Any())
            {
                var size = queue.Count;

                for (int s = 0; s < size; s++)
                {
                    var cur = queue.Dequeue();
                    result.Add(cur);

                    foreach (var next in adjacencyMatrix[cur])
                    {
                        indegrees[next]--;
                        if (indegrees[next] == 0)
                        {
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            if (indegrees.Values.Any(c => c != 0)) return "";

            //return string.Join("", result);
            //var str = TopologicalSort(adjacencyMatrix);
            return string.Join("", result);
        }

        static void TopologicalSortUtil(Stack<char> stack, Dictionary<char, bool> visited, char key, Dictionary<char, HashSet<char>> g)
        {
            visited[key] = true;
            if (g[key] != null)
            {
                foreach (var adj in g[key])
                {
                    if (!visited.ContainsKey(adj))
                    {
                        TopologicalSortUtil(stack, visited, adj, g);
                    }
                }

            }
            stack.Push(key);
        }

        private static string TopologicalSort(Dictionary<char, HashSet<char>> g)
        {
            var stack = new Stack<char>();
            var visited = new Dictionary<char, bool>();
            StringBuilder str = new StringBuilder();
            foreach (var key in g.Keys)
            {
                if (!visited.ContainsKey(key))
                    TopologicalSortUtil(stack, visited, key, g);
            }

            while (stack.Count > 0)
            {
                var x = stack.Pop();
                str.Append(x);
                Console.WriteLine(x + " ");
            }
            return str.ToString();
        }
    }
}
