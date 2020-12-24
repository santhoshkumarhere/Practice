using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode
{
    public class HandOfStraights
    {
        public static void Test()
        {
            var r = IsNStraightHand(new int[] { 1, 1, 2, 2, 3, 3 }, 3);
            var r2 = IsNStraightHand(new int[] { 2, 1 }, 2);
            var res = IsNStraightHand(new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3);
            var res2 = IsNStraightHand(new int[] { 1, 2, 3, 4, 5 }, 4);
        }
        private static bool IsNStraightHand(int[] hand, int W)
        {
            var map = new SortedDictionary<int, int>();
            foreach(var card in hand)
            {
                if(!map.ContainsKey(card))
                {
                    map[card] = 1;
                }
                else
                {
                    map[card]++;
                }
            }

            while(map.Count > 0)
            {
                var firstCard = map.Keys.First();

                for(var i = firstCard; i < firstCard + W; i++)
                {
                    if (!map.ContainsKey(i)) return false;

                    map[i]--;

                    if (map[i] == 0)
                        map.Remove(i);
                }
            }

            return true;
        }
    }
}
