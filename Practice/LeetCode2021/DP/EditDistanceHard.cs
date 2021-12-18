using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.DP
{
    internal class EditDistanceHard
    {
        public int MinDistance(string word1, string word2)
        {
        //convert word1 to word2 not otherway around
            var maxLength = Math.Max(word1.Length, word2.Length);
            return EditDistance(word1, word2, 0, 0, new int[maxLength + 1, maxLength + 1]);
        }

        private int EditDistance(string word1, string word2, int i1, int i2, int[,] dp)
        {
            if (dp[i1, i2] != 0)
                return dp[i1, i2];
            if (i1 == word1.Length)
            {
                dp[i1, i2] = word2.Length - i2;
                return dp[i1, i2];
            }

            if (i2 == word2.Length)
            {
                dp[i1, i2] = word1.Length - i1;
                return dp[i1, i2];
            }


            if (word1[i1] == word2[i2])
            {
                dp[i1, i2] = EditDistance(word1, word2, i1 + 1, i2 + 1, dp);
                return dp[i1, i2];
            }

            var ins = 1 + EditDistance(word1, word2, i1, i2 + 1, dp); //tble table
            var del = 1 + EditDistance(word1, word2, i1 + 1, i2, dp); //taable table
            var rep = 1 + EditDistance(word1, word2, i1 + 1, i2 + 1, dp); //tagle table

            dp[i1, i2] = Math.Min(ins, Math.Min(del, rep));
            return dp[i1, i2];
        }
       
    }
}
