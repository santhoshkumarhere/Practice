using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class FindAllNumbersDisAppearedInArray
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]); //abs is important

                if (nums[index - 1] > 0)
                {
                    nums[index - 1] = nums[index - 1] * -1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }
    }
}
