using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    public class ThreeSumRealTime
    {
        public static void Test()
        {
            ThreeSum();
        }

        public static List<IList<int>> ThreeSum()
        {

            var arr = new int[] {-1, -2, 1, 2};
            var result = new List<IList<int>>();
            var arrLength = arr.Length;
            Array.Sort(arr);
            if (arrLength < 3)
            {
                return result;
            }
           
            var processed = new Dictionary<string, bool>();
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < arrLength; i++)
            {
                for (var j = i+1; j < arrLength; j++)
                {
                    var remaining =  arr[i] + arr[j];

                    dict.Remove(arr[i]);
                    dict.Remove(arr[j]);
                    for (var k = j + 1; k < arrLength && !processed.ContainsKey(arr[i] + "" + arr[j]); k++)
                    {
                        dict[arr[k]] = arr[k];
                        if (arr[k] == -1* remaining || dict.ContainsKey(-1 * remaining))
                        {
                            result.Add(new List<int>() { arr[i], arr[j], dict[-1 * remaining] });
                            break;
                        }

                        if (arr[k] > -1 * remaining)
                        { 
                            break;
                        }
                    }

                    processed[arr[i] + "" + arr[j]] = true;
                }
            }

            return result;
        }
    }
}
