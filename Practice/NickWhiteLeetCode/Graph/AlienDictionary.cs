using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class AlienDictionary
    {
        public static void Test()
        {
            var words = new string[] { "wrt", "wrf", "er", "ett", "rftt" };
            var res1 = AlienOrder(words);

            var words2 = new string[] { "x", "z", "x" };
            var res2 = AlienOrder(words2);

            var words3 = new string[] { "x", "x" };
            var res3 = AlienOrder(words3);

            var words4 = new string[] { "ab", "adc" };
            var res4 = AlienOrder(words4);

            var words5 = new string[] { "wrt", "wrtkj" };
            var res5 = AlienOrder(words5);

            var words6 = new string[] { "abc", "ab" };
            var res6 = AlienOrder(words6);
        }

        private static string AlienOrder(string[] words)
        {
            var graph = new Dictionary<char, IList<char>>();

            foreach(var word in words)
            {
                foreach(var c in word)
                {
                    if(!graph.ContainsKey(c))
                    {
                        graph[c] = new List<char>();
                    }
                }
            }
            for(var i = 1; i < words.Length; i++)
            {
                var word1 = words[i - 1];
                var word2 = words[i];
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                    return "";
                Compare(words[i - 1], words[i], graph);
            }


            var visited = new HashSet<char>();
            var recursiveStack = new HashSet<char>();
            var stack = new Stack<char>();

            foreach(var key in graph.Keys)
            {
               if(IsCyclic(key, graph, visited, recursiveStack, stack))
               {
                   return string.Empty;
               }
            }

            var stringbuilder = new StringBuilder();

            while(stack.Count > 0)
            {
                stringbuilder.Append(stack.Pop());
            }
            return stringbuilder.ToString();
        }


        private static bool IsCyclic(char key, Dictionary<char, IList<char>> graph, HashSet<char> visited, HashSet<char> recursiveStack, Stack<char> stack)
        {
            if (recursiveStack.Contains(key))
                return true; //cyclic

            if (visited.Contains(key))
                return false;

            visited.Add(key);
            recursiveStack.Add(key);
          
            foreach(var adjKey in graph[key])
            {
                if(IsCyclic(adjKey, graph, visited, recursiveStack, stack))
                {
                    return true;
                }
            }          

            stack.Push(key);
            recursiveStack.Remove(key);
            return false;
        }
       

        private static void Compare(string word1, string word2, Dictionary<char, IList<char>> graph)
        {
            var minLength = Math.Min(word1.Length, word2.Length);

            for(var i = 0; i < minLength; i++)
            {
                if (word1[i] == word2[i])
                {    
                    continue;
                }
                
                graph[word1[i]].Add(word2[i]);
                break;
            }
        }
    }
}
