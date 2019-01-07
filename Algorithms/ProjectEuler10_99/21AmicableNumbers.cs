using System;
using System.Collections.Generic;

namespace Algorithms.ProjectEuler10_99
{
    public static class _21AmicableNumbers
    {
        //Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
        //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

        //For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

        //Evaluate the sum of all the amicable numbers under 10000.
        public static int Execute()
        {
            var divisorSums = new Dictionary<int, int>();

            for (var i = 2; i < 10000; i++)
            {
                var divisorSum = 1;
                var root = Math.Sqrt(i);
                for (var j = 2; j < root; j++)
                {
                    if (i % j == 0)
                    {
                        divisorSum += j;
                        divisorSum += i / j;
                    }
                }
                // Check if sqrt is whole number
                if (Math.Abs(root - Math.Floor(root)) < double.Epsilon) divisorSum += (int)root;
                divisorSums.Add(i, divisorSum);
            }

            var amicableNumberSum = 0;
            foreach (var divisorSum in divisorSums)
            {
                if (!divisorSums.ContainsKey(divisorSum.Value)) continue;
                if (divisorSum.Key == divisorSum.Value) continue;
                if (divisorSum.Key == divisorSums[divisorSum.Value])
                {
                    amicableNumberSum += divisorSum.Key;
                }
            }

            return amicableNumberSum;
        }
    }
}
