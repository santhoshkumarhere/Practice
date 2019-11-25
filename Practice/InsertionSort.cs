using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class InsertionSort
    {
        public void SortInsertion(int[] arr)
        {
            int key, i;
            for (int j = 1; j < arr.Length; j++)
            {
                key = arr[j];
                i = j - 1;

                while (i >= 0 && arr[i] > key)
                {
                    arr[i + 1] = arr[i];
                    i = i - 1;
                }
                arr[i + 1] = key;
            }

            Console.WriteLine(string.Join(",", arr));
        }
    }
}
