using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class MaxArraySum
    {
        public void GetLargeArraySum(int[] arr)
        {
            int arr_sum_current = 0;
            int arr_total_sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr_sum_current += arr[i];

                if (arr_sum_current < 0)
                {
                    arr_sum_current = 0;
                }
                else if (arr_sum_current > arr_total_sum)
                {
                    arr_total_sum = arr_sum_current;
                }
            }

            Console.WriteLine("LargeSum of Array: " + string.Join(",", arr) + " is => " + arr_total_sum);
        }
    }
}
