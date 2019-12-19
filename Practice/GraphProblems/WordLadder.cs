using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Matrix
{
    class WordLadder
    {

        public static void Test()
        {
            var beginWord = "hit";
            var endWord = "cog";
            var wordList = new List<string>() {"hot", "dot", "dog", "lot", "log", "cog"};

            beginWord = "a";
            endWord = "c";
            wordList = new List<string>() { "a", "b", "c" };
            var res = LeetSolution(beginWord, endWord, wordList);
        }
       
        public static int LeetSolution(string beginWord, string endWord, IList<string> wordList)
        {
            int L = beginWord.Length;
    
            var allComboDict = new Dictionary<string, List<string>>();

            foreach(var word in wordList)
            {
               
                for (var i=0; i<word.Length; i++)
                {
                    var curr = TransformWord(word, i);
                    var transformations = allComboDict.ContainsKey(curr) ? allComboDict[curr] : new List<string>();
                    transformations.Add(word);
                    allComboDict[curr] = transformations;
                }
            }
            return BFS(beginWord, endWord, allComboDict);
        }

        private static string TransformWord(string word, int position)
        {
            var currWord = new StringBuilder(word);
            currWord[position] = '*';
            return currWord.ToString();
        }

        private static int BFS(string beginWord, string endWord, Dictionary<string, List<string>> allComboDict)
        {
            var L = beginWord.Length;
            var  q = new Queue<KeyValuePair<string, int>>();
            q.Enqueue(new KeyValuePair<string, int>(beginWord, 1));

           var  visited = new Dictionary<string, Boolean>();
            visited.Add(beginWord, true); 
            while (q.Count > 0)
            {
                var pair = q.Dequeue();
                string word = pair.Key;
                int level = pair.Value;
                for (int i = 0; i < L; i++)
                {
                    string newWord = TransformWord(word, i);
                    foreach (var adjacentWord in allComboDict.ContainsKey(newWord) ? allComboDict[newWord] : new List<string>())
                    {
                        if (adjacentWord.Equals(endWord))
                        {
                            return level+1;
                        }

                        if (!visited.ContainsKey(adjacentWord))
                        {
                            visited.Add(adjacentWord, true);
                            q.Enqueue(new KeyValuePair<string, int>(adjacentWord, level+1) ); 
                        }
                    }
                }
            }
            return 0;
        }
    }
}
//wordList.ToList().ForEach(
//    word =>
//    {
//        for (int i = 0; i < L; i++)
//        {
//            string newWord = word.Substring(0, i) + '*' + word.Substring(i + 1, L - (i + 1));
//            List<string> transformations = allComboDict.ContainsKey(newWord) ? allComboDict[newWord] : new List<string>();
//            transformations.Add(word);
//            allComboDict[newWord] = transformations;
//        }
//    });