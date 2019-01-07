using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.ProjectEuler
{
    public static class _4LargestPalindromeProduct
    {
        //A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

        //Find the largest palindrome made from the product of two 3-digit numbers.
        public static int Execute()
        {
            var largestPalindrome = 0;
            var largestValue = 999;

            for (var i = largestValue; i > 0; i--)
            {
                for (var j = i; j > 0; j--)
                {
                    var value = i * j;
                    if (value <= largestPalindrome) break;

                    var evaluator = value.ToString();

                    var length = evaluator.Length;
                    if (length % 2 == 0)
                    {
                        var middle = length / 2;
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle).ToArray();

                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                    else
                    {
                        var middle = (int)Math.Floor(length / 2.0);
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle + 1).ToArray();
                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                }
            }

            return largestPalindrome;
        }

        /// <summary>
        /// Brute force method. Runs in 0.08 seconds
        /// For 50000, answer is 2147447412. Takes 10 seconds
        /// </summary>
        /// <returns></returns>
        public static int FirstRun()
        {
            var largestValue = 50000;
            var largestPalindrome = 0;
            for (var i = largestValue; i > 0; i--)
            {
                for (var j = largestValue; j > 0; j--)
                {
                    var value = i * j;
                    if (value <= largestPalindrome) continue;

                    var evaluator = value.ToString();

                    var length = evaluator.Length;
                    if (length % 2 == 0)
                    {
                        var middle = length / 2;
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle).ToArray();

                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                    else
                    {
                        var middle = (int)Math.Floor(length / 2.0);
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle + 1).ToArray();
                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                }
            }

            return largestPalindrome;
        }

        /// <summary>
        /// More efficient brute force. For Calculate 1,000,000,000 in 8 seconds
        /// </summary>
        /// <returns></returns>
        public static int SecondRun()
        {
            var largestPalindrome = 0;
            var largestValue = 999999999;

            for (var i = largestValue; i > 0; i--)
            {
                for (var j = i; j > 0; j--)
                {
                    var value = i * j;
                    if (value <= largestPalindrome) break;

                    var evaluator = value.ToString();

                    var length = evaluator.Length;
                    if (length % 2 == 0)
                    {
                        var middle = length / 2;
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle).ToArray();

                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                    else
                    {
                        var middle = (int)Math.Floor(length / 2.0);
                        var firstArray = evaluator.Take(middle).ToArray();
                        var secondArray = evaluator.Skip(middle + 1).ToArray();
                        if (firstArray.SequenceEqual(secondArray.Reverse()))
                            largestPalindrome = value;
                    }
                }
            }

            return largestPalindrome;
        }
    }
}
