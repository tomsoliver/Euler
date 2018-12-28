using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ProjectEuler
{
    public static class _1MultiplesOf3And5
    {
        // If we list all the natural numbers below 10 that are multiples of 3 or 5,
        // we get 3, 5, 6 and 9. The sum of these multiples is 23.
        // Find the sum of all the multiples of 3 or 5 below 1000.
        public static int Execute()
        {
            // A function to find the sum of the multiples.
            Func<int, int, int> sumOfMultiplesFunc = (maxValue, multiplier) =>
            {
                var sumOfMinAndMax = multiplier + (int) Math.Floor((double) maxValue / multiplier) * multiplier;
                return sumOfMinAndMax * (int) Math.Floor((double) maxValue / multiplier) / 2;
            };

            // Find for 3
            var sumOf3 = sumOfMultiplesFunc.Invoke(999, 3);
            var sumOf5 = sumOfMultiplesFunc.Invoke(999, 5);

            // Need to remove duplicates, i.e. factors of 3 and 5 = 15
            var sumOf15 = sumOfMultiplesFunc.Invoke(999, 15);

            return sumOf3 + sumOf5 - sumOf15;
        }

        /// <summary>
        /// Executes for all values less than 1000. Can be more
        /// efficient by using known algorithms
        /// </summary>
        public static int FirstRun()
        {
            var multiples = new HashSet<int>();
            const int max = 1000;
            var interval = 3;

            var i = interval;
            while (i < max)
            {
                multiples.Add(i);
                i = i + interval;
            }

            interval = 5;
            i = interval;
            while (i < max)
            {
                multiples.Add(i);
                i = i + interval;
            }

            return multiples.Sum();
        }
    }
}
