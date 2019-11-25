using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class LetterCombination
    {
        Dictionary<string, string> phone = new Dictionary<string, string>() {
               {"2", "abc"},
               {"3", "def"},
               {"4", "ghi"},
               {"5", "jkl"},
               {"6", "mno"},
               {"7", "pqrs"},
               {"8", "tuv"},
               {"9", "wxyz"}
        };

        IList<string> output = new List<string>();

        //"2345"
        public void backtrack(string combination, string next_digits)
        {
            if (next_digits.Length == 0)
            {
                output.Add(combination);
            }
            else
            {
                var current = phone[next_digits.Substring(0, 1)];
                foreach (var letter in current)
                {
                    backtrack(combination + letter, next_digits.Substring(1));
                }
            }
        }


        public IList<string> letterCombinations(string digits)
        {
            if (digits.Length != 0)
                backtrack("", digits);
            return output;
        }
    }
}




//// if there is no more digits to check
//if (next_digits.Length == 0)
//{
//// the combination is done
//output.Add(combination);
//}
//// if there are still digits to check
//else
//{
//// iterate over all letters which map 
//// the next available digit
//string digit = next_digits.Substring(0, 1);
//string letters = phone[digit];
//    for (int i = 0; i<letters.Length; i++)
//{
//    String letter = phone[digit].Substring(i, 1);
//// append the current letter to the combination
//// and proceed to the next digits
//    backtrack(combination + letter, next_digits.Substring(1));
//}
//}