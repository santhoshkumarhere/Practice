using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class PermutationString
    {
        public static void Permutate()
        {
            Permutate("ABC", 0, 2);
        }

        public static void Permutate(string str, int left, int right)
        {
            if(left == right)
            {
                Console.WriteLine(str);
            }

            for(var i = left; i <= right; i++)
            {
                str = Swap(str, left, i);
                Permutate(str, left + 1, right);
                str = Swap(str, left, i);
            }
        }    

        private static string Swap(string s, int i, int  j)
        {
            var charArray = s.ToCharArray();
            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;

            return new string(charArray);
        }
    }
}
