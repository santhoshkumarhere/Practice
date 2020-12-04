using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class ToLowerCase
    {
        public static void Test()
        {
            var name = "SANTHOSHKUMAR";
            StringBuilder str = new StringBuilder();

            foreach (var c in name.ToCharArray())
            {
                if (c >= 65 && c <= 90)
                {
                    str.Append((char)(c + 32));
                }
                else
                {
                    str.Append(c);
                }
            }
            Console.WriteLine(str.ToString());
        }
    }
}
