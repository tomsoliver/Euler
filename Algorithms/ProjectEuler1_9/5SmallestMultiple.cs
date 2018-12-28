using System;
using System.Collections.Generic;
using System.Numerics;
using Algorithms.Helpers;

namespace Algorithms.ProjectEuler
{
    public static class _5SmallestMultiple
    {
        // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

        // 25 gives 26771144400 and takes 0.01 seconds
        // 100 takes 0.01 seconds
        public static BigInteger Execute()
        {
            const int max = 100;
            var primeFactors = new Dictionary<int, int>();

            for (var i = 1; i <= max; i++)
            {
                var smallestPrime = 1;
                if (i % 2 == 0) smallestPrime = 2;
                else
                {
                    for (var j = 3; j <= i; j = j + 2)
                    {
                        if (i % j != 0) continue;
                        if (!PrimeHelper.IsPrime(j)) continue;
                        smallestPrime = j;
                        break;
                    }
                }

                var power = 0;
                var factor = i;
                while (factor % smallestPrime == 0)
                {
                    if (factor == 1) break;
                    factor = factor / smallestPrime;
                    power++;
                }

                if (primeFactors.ContainsKey(smallestPrime))
                {
                    if (primeFactors[smallestPrime] < power) primeFactors[smallestPrime] = power;
                }
                else
                    primeFactors[smallestPrime] = power;
            }

            BigInteger value = 1;
            foreach (var factor in primeFactors)
            {
                value = value * (BigInteger)Math.Pow(factor.Key, factor.Value);
            }
            return value;
        }

        // 25 gives 26771144400 and takes 5 seconds
        public static long FirstRun()
        {
            const long max = 25;
            var maxMinus1 = max - 1;
            var i = 1; // The multiple

            while (true)
            {
                var result = max * maxMinus1 * i;
                var isValid = true;

                //Check for divisions. Skip 1 because everything is divisible by 1
                for (var j = 2; j <= max; j++)
                {
                    if (result % j == 0) continue;

                    isValid = false;
                    break;
                }

                if (isValid) return result;
                i++;
            }
        }
    }
}
