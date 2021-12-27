using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueue
{
    internal class KthClosestPointsToOrigin
    {
        public static void Test()
        {
            var res = KClosest(new int[][] { new int[]{ 3, 3 }, 
                new int[] { 5, -1 }, 
                new int[] { -2, 4 } }, 2);


            var res1 = KClosest(new int[][] { new int[]{ 0, 1 },
                new int[] { 1, 0 } }, 2);
        }

        private static int[][] KClosest(int[][] points, int k)
        {
            var partition =  FindKClosest(points, 0, points.Length - 1, k);
            var result = new int[k][];

            Array.Copy(points, result, k);

            //for(int i = 0; i < k; i++)
            //{
            //    result[i] = points[i];
            //}
            return result;
        }

        private static int FindKClosest(int[][] points, int low, int high, int k)
        {
            var partition = Partition(points, low, high);

            if (partition == k)
                return partition;
            else if (partition > k)   // k = 5, p= 6
                return FindKClosest(points, low, partition - 1, k);
            else
                return FindKClosest(points, partition + 1, high, k);
        }


        private static int Partition(int[][] arr, int low, int high)
        {            
            var pivotValue = GetPivotValue(arr[high]);
            var pivotLoc = low;

            for(var i = low; i <= high; i++)
            {
                if(GetPivotValue(arr[i]) < pivotValue)
                {
                    Swap(arr, i, pivotLoc);
                    pivotLoc++;
                }
            }
            Swap(arr, high, pivotLoc);
            return pivotLoc;
        }

        private static int GetPivotValue(int[] p)
        {
            return p[0] * p[0] + p[1] * p[1];
        }
        private static void Swap(int[][] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];   
            arr[j] = temp;
        }

        private class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);
                if (result == 0)
                    return 1;
                else
                    return 0;
            }
        }

        private static int[][] KClosestPQ(int[][] points, int k)
        {
            var pq = new PriorityQueue<int[], int>();

            foreach(var p in points)
            {
                pq.Enqueue(p, p[0] * p[0] + p[1] * p[1]);

               // if (pq.Count > k)
                 //   pq.Dequeue();
            }

            var res = new int[k][];

           for(int i = 0; i < k; i++)
            {
                var p = pq.Dequeue();
                res[i] = new int[] { p[0], p[1] };
            }
            return res;
        }

    }
}
