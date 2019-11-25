using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.HashTable
{
    class HashTableExample
    {
        private int hash(char c)
        {
            return Char.ToLower(c) - 'a';
        }

        public void FindStringLength(string input)
        {
            int[] frequency = new int[26];

            for (int i = 0; i < input.Length; i++)
            {
                int index = hash(input[i]);
                frequency[index] = frequency[index] + 1;
            }

            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine((char)(i + 'a') + " => " + frequency[i]);
            }
            Console.ReadLine();
        }
    }
}
