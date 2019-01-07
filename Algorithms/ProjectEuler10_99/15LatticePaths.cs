using System;
using System.Linq;

namespace Algorithms.ProjectEuler10_99
{
    public static class _15LatticePaths
    {
        // Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
        // there are exactly 6 routes to the bottom right corner.
        // How many such routes are there through a 20×20 grid?
        public static double Execute()
        {
            const double x = 2;
            const double y = 3;

            var largerDimension = x < y ? y : x;
            var smallerDimension = x < y ? x : y;

            double numerator = 1;
            for (var i = largerDimension + 1; i <= x + y; i++)
            {
                numerator = numerator * i;
            }
            
            return numerator / Factorial(smallerDimension);
        }

        private static double Factorial(double x)
        {
            return x == 1 ? x : x * Factorial(x - 1);
        }
    }
}