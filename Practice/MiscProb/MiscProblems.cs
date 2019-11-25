using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;
using Practice.ThreadConcepts;

namespace Practice.MiscProb
{
    class MiscProblems
    {
        public static bool ReverseNumber(int number)
        {
            long reverse = 0;

            if (number < 0)
                return false;

            var quotient = number;

            while (quotient > 0)
            {
                var lastDigit = quotient % 10;
                quotient = quotient / 10;
                reverse = reverse * 10 + lastDigit;
            }
             
            Console.WriteLine($"Reverse : {reverse}");

            if (reverse < Int32.MinValue || reverse > Int32.MaxValue)
            {
                return false;
            }
            else
            {
                return number == reverse;
            }
        }

        public static void ReverseString(string input)
        {
            var length = input.Length;
            var newString = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                newString.Append(input[length - 1 - i]);
            }
            Console.WriteLine(newString);
        }

        public static bool PalindromeString(string input)
        {
            var len = input.Length;
            for (var i = 0; i < len/2; i++)
            {
                if (input[i] != input[len - i - 1])
                {
                   // Console.WriteLine("Not a palindrome");
                    return false;
                }
            }
            // Console.WriteLine("Palindrome");
            return true;
        }

        public int maxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }

        public static string LongestPalindrome(string s)
        {
            var len = s.Length;
            var  min = 0; var max = 0;

            if (len == 1 || s == string.Empty || PalindromeString(s))
            {
                return s;
            }
            for (var startIndex = 0; startIndex < len; startIndex++)
            {
                for (var endingIndex = len - 1; endingIndex > startIndex; endingIndex--)
                {
                    if (s[startIndex] == s[endingIndex])
                    {
                        var sub = s.Substring(startIndex, startIndex == 0 ? endingIndex + 1 : (endingIndex - startIndex  + 1));
                        var result = PalindromeString(sub);
                        if (result)
                        {
                            var stringCount = endingIndex - startIndex + 1;
                            if (stringCount > max )
                            {
                                min = startIndex;
                                max = startIndex == 0 ? endingIndex + 1 : stringCount;
                            }
                        }
                    }
                }
            }
            if(min == 0 && max == 0)
            {
                return s[0].ToString();
            }

            return s.Substring(min, max);
        } //xaabaax   abbc maadaax maamm

        public static string Test(string s)
        {
            var len = s.Length;
            var min = 0; var max = 0;

            if (len == 1 || s == string.Empty || PalindromeString(s))
            {
                return s;
            }
            
            for (var startIndex = 0; startIndex < len; startIndex++)
            {
                for (var endingIndex = len - 1; endingIndex > startIndex; endingIndex--)
                {
                    var sub = s.Substring(startIndex, startIndex == 0 ? endingIndex + 1 : (endingIndex - startIndex + 1));
                    var result = PalindromeString(sub);
                    if (result)
                    {
                        var stringCount = endingIndex - startIndex + 1;
                        if (stringCount > max)
                        {
                            min = startIndex;
                            max = startIndex == 0 ? endingIndex + 1 : stringCount;
                        }
                    }
                }
            }
            if (min == 0 && max == 0)
            {
                return s[0].ToString();
            }
            return s.Substring(min, max);
        }

        private static int Fact(int x)
        {
           var result = 0;
            //while (x > 1)
            //{
            //   result = result * x*(x - 1);
            //    x = x-2;
            //}
            if (x <= 1)
            {
                return 1;
            }
            Console.Write($"{x} * {x-1} "  );
             result =  x * Fact(x-1);
             return result;
        }

        private static int Fib(int x)
        {
            if (x <= 1)
            {
                return x;
            }

            return Fib(x - 1) + Fib(x - 2); 
        }

        public static void Fibo(int x)
        {
            var result = Fib(x);
            Console.WriteLine(result);
        }

        public static void Facto(int x)
        {
            var result = Fact(x);
            Console.WriteLine(result);
        }

        public static string PalString(string input)
        {
            var len = input.Length;

            if (input.Length == 1)
            {
                return input;
            }

            for (var i = 0; i < len / 2; i++)
            {
                if (input[i] != input[len - i - 1])
                {
                    return string.Empty;
                }
            }

            return input;
        }

        public static int ReverseInteger(int input)
        {
            var isNegative = input < 0;
            long convertedInput = isNegative ? ((long)input * -1) : (long)input;
            if (convertedInput < int.MinValue && convertedInput > int.MaxValue)
            {
                return 0;
            }

            var inputString = convertedInput.ToString();
            var length = inputString.Length;
            var newString = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                newString.Append(inputString[length - 1 - i]);
            }

            var result = long.Parse(newString.ToString());

            if (result >= int.MinValue && result <= int.MaxValue)
            {
                if (isNegative)
                {
                    return -1 * (int)result;
                }
                else
                {
                    return (int) result;
                }
            }
            else
            {
                return 0;
            }
        }

        public static void SubArray(int[] arr, int k)
        {
            var max_sum = 0;

            for (var i = 0; i < k; i++)
            {
                max_sum += arr[i];
            }

            var window_sum = max_sum;

            for (var i = k; i < arr.Length; i++)
            {
                window_sum += arr[i] - arr[i - k];
                max_sum = Math.Max(max_sum, window_sum);
            }

            Console.WriteLine($"maximum sub array : {max_sum}");
        }

        public static void Compute()
        {
            var arr = new int[] {25000, 20000, 5000, 5000, 10000, 5000, 30000, 10000, 30000, 5000, 25000};
            var result = 100000;
            var sumOfTran = arr.Sum();
            var len = arr.Length;
            var split = 0;
            var endIndex = 0;

            var current = sumOfTran;
            if (sumOfTran > result)
            {

                //split scenario
                for (var i = 0; i < arr.Length; i++)
                {
                    current = current - arr[len - i - 1];
                    if (current < result)
                    {
                        //split
                        split = result - current;
                        endIndex = len - i - 1;
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                // the entire transaction goes to one Equip-Id
            }

            for (var i = 0; i < endIndex; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine(split);
        }

        public static int Kandanes(int[] arr)
        {
            var max_far = int.MinValue;
            var max_ending_here = 0;
            var startingIndex = 0;
            var start = 0;
            var endingIndex = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                max_ending_here = max_ending_here + arr[i];

                if (max_ending_here > max_far)
                {
                    startingIndex = start;
                    max_far = max_ending_here;
                    endingIndex = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    start = i+1;
                }
            }

            for (var j = startingIndex; j < endingIndex + 1; j++)
            {
                Console.WriteLine($"{arr[j]}, ");
            }

            return max_far;
        }
        
    }
}
