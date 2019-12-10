using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.stringProblems
{
    class VowelSpellChecker
    {
        static HashSet<string> words_perfect;
        static IDictionary<string, string> words_cap;
        static IDictionary<string, string> words_vow;

        public static void Test()
        {
            var res = spellchecker(
                new string[] { "KiTe", "kite", "hare", "Hare" },
                new string[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" }
                );
        }

        public static string[] spellchecker(string[] wordlist, string[] queries)
        {
            words_perfect = new HashSet<string>();
            words_cap = new Dictionary<string, string>();
            words_vow = new Dictionary<string, string>();

            foreach (string word in wordlist)
            {
                words_perfect.Add(word);

                string wordlow = word.ToLower();
                if(!words_cap.ContainsKey(wordlow))
                words_cap[wordlow]= word;

                string wordlowDV = devowel(wordlow);
                if (!words_vow.ContainsKey(wordlowDV))
                    words_vow[wordlowDV] = word;
            }

            string[] ans = new string[queries.Length];
            int t = 0;
            foreach (string query in queries)
                ans[t++] = solve(query);
            return ans;
        }

        public static string solve(string query)
        {
            if (words_perfect.Contains(query))
                return query;

            string queryL = query.ToLower();
            if (words_cap.ContainsKey(queryL))
                return words_cap[queryL];

            string queryLV = devowel(queryL);
            if (words_vow.ContainsKey(queryLV))
                return words_vow[queryLV];

            return "";
        }

        public static string devowel(string word)
        {
            StringBuilder ans = new StringBuilder();
            foreach (var c in word.ToCharArray())
                ans.Append(isVowel(c) ? '*'  : c);
            return ans.ToString();
        }

        public static bool isVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }
    }
}
