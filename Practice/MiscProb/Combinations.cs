using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    // C# program to print all 
    // combination of size r 
    // in an array of size n 
 

    class Combinations
    {
        static void combinationUtil(int[] arr, int[] data, int start, int end, int index, int r)
        {
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                    Console.Write(data[j] + " ");
                Console.WriteLine("");
                return;
            }

            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1,
                    end, index + 1, r);
            }
        }

        static void printCombination(int[] arr, int n, int r)
        {
            // A temporary array to store 
            // all combination one by one 
            int[] data = new int[r];

            // Print all combination 
            // using temprary array 'data[]' 
            combinationUtil(arr, data, 0,
                n - 1, 0, r);
        }

        // Driver Code 
        static public void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int r = 3;
            int n = arr.Length;
            printCombination(arr, n, r);
        }
    } 

}
