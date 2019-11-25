using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    internal class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            var result = 0;
            var dictionary = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            for (int i = 0; i < s.Length; i++)
            {
                var currentNumber = dictionary[s[i]];

                var nextNumber = i == s.Length -1 ? 0 : dictionary[s[i+1]];
                if (nextNumber > currentNumber)
                {
                    result = result + nextNumber - currentNumber;
                    i = i + 1;
                }
                else
                {
                    result = result + currentNumber;
                }
            }

            return result;
        }
    }
}
