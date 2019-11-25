using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class MakingChangeRecursive
    {

        public static void Test()
        {
           //var res =  ChangePossibilitiesTopDown(4, new int[] {1, 2, 3}, 0);
           RunUntilTarget(7, 10);
        }

        public static void RunUntilTarget(int value, int target)
        {
            var remaining = target;
            while (remaining > 0)
            {
                remaining = remaining - value;
            }
        }

        
        public static int ChangePossibilitiesTopDown(
            int amountLeft, int[] denominations, int currentIndex = 0)
        {
            // Base cases:
            // We hit the amount spot on. Yes!
            if (amountLeft == 0)
            {
                return 1;
            }

            // We overshot the amount left (used too many coins) or  // We're out of denominations
            if (amountLeft < 0 || (currentIndex == denominations.Length))
            {
                return 0;
            } 

            // Choose a current coin
            int currentCoin = denominations[currentIndex];

            // See how many possibilities we can get for each number of times to use currentCoin
            int numPossibilities = 0;
            while (amountLeft >= 0)
            {
                numPossibilities = numPossibilities + ChangePossibilitiesTopDown(amountLeft, denominations, currentIndex + 1);
                amountLeft = amountLeft - currentCoin;
            }

            return numPossibilities;
        }
    }
}



// Print out actual part of array
//Console.Write($"checking ways to make {amountLeft} with ");
//Console.WriteLine($"[{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}]");
//Console.WriteLine($"Amount left calculation for [{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}] -> {amountLeft} - {currentCoin}");