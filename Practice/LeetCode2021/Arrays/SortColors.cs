using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class SortColors
    {

        public static void Test()
        {
            var nums = new []{ 2, 0, 2, 1, 1, 0 };
            SortColor(nums);
        }

        private static void SortColor(int[] nums)
        {
            var left = 0; var right = nums.Length - 1;
            var current = 0;

            while(current <= right)
            {
                if (nums[current] == 0)
                {
                    Swap(current, left, nums);
                    left++; current++; // no need to reprocess because replaced value from left has been already processed
                }
                else if (nums[current] == 2)
                {
                    Swap(current, right, nums);
                    right--; // reprocess the current element in next iteration because the value could be unprocessed 0/1
                }
                else
                {
                    current++;
                }
            }
        }

        private static void Swap(int i, int j, int[] nums)
        {
            var temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
        }



        //for(int i = 0; i <= right; i++)
        //{
        //    if(nums[i] == 0)
        //    {
        //        Swap(i, left, nums);
        //        left++;
        //    }
        //    else if(nums[i] == 2)
        //    {
        //        Swap(i, right, nums);
        //        right--;
        //        i--; //backtrack - rerun
        //    }
        //}
    }
}
