using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Tree
{
    public class PermutateString
    {

        public static void Test()
        {
            //var s = "ABC";
            //var result = new List<string>();
            //Permutate(s.ToCharArray(), 0, result);
            PermutateNums(new int[] { 1, 2, 3 });
        }

        private static IList<string> Permutate(char[] c, int currentIndex, IList<string> res)
        {
            if(currentIndex == c.Length - 1)
            {
                res.Add(new string(c));
                return res;
            }

            for (var i = currentIndex; i < c.Length; i++) //horizontal
            {
                Swap(c, currentIndex, i);
                Permutate(c, currentIndex + 1, res); // create vertical tree child until base case met and then comeback to parent
                Swap(c, currentIndex, i); //backtrack and change the char back to ABC
            }
            
            return res;
        }

        public static void Swap(char[] ch, int i, int j)
        {
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
        }

        private static IList<IList<int>> PermutateNums(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums == null)
            {
                return result;
            }
            if(nums.Length == 1)
            {
                result.Add(nums.ToList());
                return result;
            }
            PermutateTest(nums, 0, result);
            return result;
        }

        private static IList<IList<int>> PermutateTest(int[] nums, int currentIndex, IList<IList<int>> res)
        {
            if(currentIndex == nums.Length - 1)
            {
                res.Add(nums.ToList());
                return res;
            }

            for(var i = currentIndex; i < nums.Length; i++)
            {
                Swap(nums, currentIndex, i);
                PermutateTest(nums, currentIndex + 1, res);
                Swap(nums, currentIndex, i);
            }
            return res;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}