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
            var res = LadderLength(beginWord, endWord, wordList);
            res = LeetSolution(beginWord, endWord, wordList);
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
            var  Q = new Queue<string>();
            Q.Enqueue(beginWord);

           var  visited = new Dictionary<string, Boolean>();
            visited.Add(beginWord, true);
            var steps = 0;
            while (Q.Count > 0)
            {
                string word = Q.Dequeue();
                for (int i = 0; i < L; i++)
                {
                    string newWord = TransformWord(word, i);
                    foreach (var adjacentWord in allComboDict.ContainsKey(newWord) ? allComboDict[newWord] : new List<string>())
                    {
                        if (adjacentWord.Equals(endWord))
                        {
                            steps++;
                            return steps;
                        }

                        if (!visited.ContainsKey(adjacentWord))
                        {
                            visited.Add(adjacentWord, true);
                            Q.Enqueue(adjacentWord);
                        }
                    }
                }
                steps++;
            }
            return 0;
        }

        private static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var wordSet = new HashSet<string>(wordList);

            var result = new List<IList<string>>();
            if (!wordSet.Contains(endWord))
            {
                return 0;
            }

            var queue = new Queue<string>();
            queue.Enqueue(beginWord);

            var length = 1;

            while (queue.Any())
            {
                var count = queue.Count;
                for (int c = 0; c < count; c++)
                {
                    var cur = queue.Dequeue();
                    wordSet.Remove(cur);

                    var wordArray = cur.ToArray();
                    for (int i = 0; i < cur.Length; i++)
                    {
                        var curChar = cur[i];
                        for (var j = 'a'; j <= 'z'; j++)
                        {
                            if (curChar != j)
                            {
                                wordArray[i] = j;
                                var next = new string(wordArray);

                                // save one level from BFS
                                if (next == endWord)
                                {
                                    return length + 1;
                                }

                                if (wordSet.Contains(next))
                                {
                                    queue.Enqueue(next);
                                    // save time for the duplication.
                                    wordSet.Remove(next);
                                }
                                wordArray[i] = curChar;
                            }
                        }
                    }
                }
                length++;
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