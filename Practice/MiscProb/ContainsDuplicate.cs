using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class ContainsDuplicate
    {

        public static void Test()
        {
           var result = ContainsDuplicateProblem(new int[] {1,2,3,4, 1 });
        }

        private static bool ContainsDuplicateProblem(int[] nums)
        {
            var hash = new HashSet<int>();
            
            for(var i=0; i< nums.Length; i++)
            {
                if(hash.Contains(nums[i]))
                {
                    return true;
                }
                hash.Add(nums[i]);
            }
            return false;
        }
    }
}
