using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class KeysAndRooms
    {
        public static void Test()
        {
            var rooms = new List<IList<int>>();
            rooms.Add(new List<int>() { 1, 3 });
            rooms.Add(new List<int>() { 3, 0, 1 });
            rooms.Add(new List<int>() { 2 });
            rooms.Add(new List<int>() { 0 });
            var res = CanVisitAllRooms(rooms);
            rooms = new List<IList<int>>();
            rooms.Add(new List<int>() { 1 });
            rooms.Add(new List<int>() { 2 });
            rooms.Add(new List<int>() { 3 });
            rooms.Add(new List<int>() { });
            res = CanVisitAllRooms(rooms);
        }

        public static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {            //My Solution 99% faster
            var seen = new bool[rooms.Count];
            seen[0] = true;

            var keys = new Stack<IList<int>>();
            keys.Push(rooms[0]);
            while(keys.Count > 0)
            {
                var currRoomKeys = keys.Pop();
                foreach(var key in currRoomKeys)
                {
                    if(!seen[key])
                    {
                        keys.Push(rooms[key]);
                        seen[key] = true;
                    }
                }
            }

            return !Array.Exists(seen, x => x == false);
        }

        public static bool CanVisitAllRoomsByOneKey(IList<IList<int>> rooms)
        {
            var seen = new bool[rooms.Count];
            seen[0] = true;

            var keys = new Stack<int>();
            keys.Push(0);
            while (keys.Count > 0)
            {
                var currRoomKey = keys.Pop();
                foreach (var key in rooms[currRoomKey])
                {
                    if (!seen[key])
                    {
                        keys.Push(key);
                        seen[key] = true;
                    }
                }
            }

            return !Array.Exists(seen, x => x == false);
        }
    }
}
