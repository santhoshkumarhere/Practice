using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestContinuousSubsequence
    {
        public static void Test()
        {
            var nums = new int[] { 100, 4, 200, 1, 3, 2 }; // ans = 4
            var nums2 = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }; //ans = 9
            var result = LongestConsecutiveV3(nums);
            var result2 = LongestConsecutiveV3(nums2);
        }

        private static int LongestConsecutive(int[] nums)
        {
            var set = new HashSet<int>(nums);

            var longestSequence = 0;

            foreach (var num in nums)
            {
                if (!set.Contains(num - 1))
                {
                    var next = num + 1;
                    var currentSequenceLength = 1;

                    while (set.Contains(next))
                    {
                        next++;
                        currentSequenceLength++;
                    }
                    longestSequence = Math.Max(longestSequence, currentSequenceLength);
                }
            }
            return longestSequence;
        }

        private static int LongestConsecutiveV3(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            var set = new HashSet<int>(nums);

            var graph = new Dictionary<int, int>();

            var longestSequence = 1;

            foreach(var n in nums)
            {
                if(set.Contains(n - 1))
                {
                    graph[n] = n - 1 ;
                }
            }

            foreach(var key in graph.Keys)
            {
                var currCount = DFS(graph, key);
                longestSequence = Math.Max(currCount, longestSequence);
            }
            return longestSequence;
        }

        private static int DFS(Dictionary<int, int> graph, int key)
        {
            var count = 1;
            if (!graph.ContainsKey(key))
                return count;
                        
            count += DFS(graph, graph[key]);
            
            return count++;
        }

        private static int LongestConsecutiveV2(int[] nums)
        {
            var set = new HashSet<int>(nums);

            var longestSequence = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (!set.Contains(nums[i] - 1)) // it will improve time complexity of this problem
                {
                    var currentSequenceLength = 1;
                    var next = nums[i] + 1;
                    while (set.Contains(next))
                    {
                        next++;
                        currentSequenceLength++;
                    }
                    longestSequence = Math.Max(longestSequence, currentSequenceLength);
                }
            }

            return longestSequence;
        }

        
    }
}
