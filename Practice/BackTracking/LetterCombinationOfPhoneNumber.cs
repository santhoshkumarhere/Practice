using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    public class LetterCombinationOfPhoneNumber
    {
        //O(4^N * N) where N = Length of digit & 4 = longest value in hashmap
        public static void Test()
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            var result = new List<string>();
            
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "ghi");
            dict.Add('5', "jkl");
            dict.Add('6', "mno");
            dict.Add('7', "pqrs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxyz");
            var digits = "234";
            BackTracking(0, new StringBuilder(), digits, dict, result);
        }

        private static void BackTracking(int index, StringBuilder prefix, string digits, Dictionary<char, string> dict, IList<string> result)
        {
            if(prefix.Length == digits.Length)
            {
                result.Add(prefix.ToString());
                return;
            }

            var letters = dict[digits[index]]; // 0
            foreach(var c in letters) // abc
            {
                prefix.Append(c);
                BackTracking(index + 1, prefix, digits, dict, result);
                prefix.Remove(prefix.Length - 1, 1);
            }
        }
    }
}


   //     o
   //   / | \
   //  a  b  c    index 0
   // /|\
   //d e f        index 1