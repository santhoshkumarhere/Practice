using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.LeetCode2021
{
    public class GroupAnagrams
    {
        public static void Test()
        {
            var str = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var res = GroupAnagram(str);
        }

        private static  IList<IList<string>> GroupAnagram(string[] strs)
        {
            var result = new List<IList<string>>();

            if (strs.Length == 0)
                return result;
            var dict = new Dictionary<string, IList<string>>();

            foreach(var str in strs)
            {
                var arr = new char[26];

                foreach(var c in str)
                {
                    arr[c - 'a']++;
                }
                var key = new string(arr);
                if (!dict.ContainsKey(key))
                    dict[key] = new List<string>();
                dict[key].Add(str);
            }

            return dict.Values.ToList();
        }
    }
}
