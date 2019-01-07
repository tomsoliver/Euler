using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algorithms.ProjectEuler
{
    public static class _6SumSquareDifference
    {
        //The sum of the squares of the first ten natural numbers is,

        //1^2 + 2^2 + ... + 102 = 385
        //The square of the sum of the first ten natural numbers is,

        //(1 + 2 + ... + 10)^2 = 55^2 = 3025
        //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

        //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        
        // 10000000 takes 0.00065 seconds
        public static BigInteger Execute()
        {
            long max = 100;

            // Find sum of squares
            BigInteger sumOfSquares = max * (max + 1) * (2 * max + 1) / 6;

            // Find the square of the sum
            BigInteger squareOfSum = max * (1 + max) / 2;
            squareOfSum = squareOfSum * squareOfSum;

            return squareOfSum - sumOfSquares;
        }

        // 10000000 takes 3 seconds
        public static BigInteger FirstRun()
        {
            int max = 10000000;

            // Find sum of squares
            BigInteger sumOfSquares = 0;
            for (var i = 1; i <= max; i++)
            {
                sumOfSquares += i * i;
            }

            // Find the square of the sum
            BigInteger squareOfSum = 0;
            for (var i = 1; i <= max; i++)
                squareOfSum += i;
            squareOfSum = squareOfSum * squareOfSum;

            return squareOfSum - sumOfSquares;
        }
    }
}
