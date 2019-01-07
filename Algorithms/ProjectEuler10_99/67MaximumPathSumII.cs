using Algorithms.Properties;
using System;
using System.Linq;

namespace Algorithms.ProjectEuler10_99
{
    public static class _67MaximumPathSumII
    {
        //By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

        //3
        //7 4
        //2 4 6
        //8 5 9 3

        //That is, 3 + 7 + 4 + 9 = 23.

        //Find the maximum total from top to bottom in triangle.txt(right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.

        //NOTE: This is a much more difficult version of Problem 18. It is not possible to try every route to solve this problem, as there are 299 altogether! If you could check one trillion (1012) routes every second it would take over twenty billion years to check them all.There is an efficient algorithm to solve it. ; o)

        // Calculates 7273 in 0.0845 seconds
        public static double Execute()
        {
            var triangleData = Resources._67Triangle;
            var triangle = triangleData.Split(Environment.NewLine).Select(s => s.Split(" ").Select(t => double.Parse(t)).ToArray()).ToArray();

            var triangleValues = new double[triangle.Length][];
            triangleValues[0] = new[] { triangle[0][0] };

            for (var i = 1; i < triangle.Length; i++)
            {
                // Get current row length
                var length = triangle[i].Length;

                // There are two paths for each value
                triangleValues[i] = new double[length];

                // For the two edge roots, take the values
                triangleValues[i][0] = triangleValues[i - 1][0] + triangle[i][0];
                triangleValues[i][length - 1] = triangleValues[i - 1].Last() + triangle[i].Last();

                // Calculate values for all intermediatee routes
                for (var j = 1; j < triangle[i].Length - 1; j++)
                {
                    // Take the larger value of the previous routes, and multiple by the next row. Set that as the value
                    var value1 = triangleValues[i - 1][j - 1];
                    var value2 = triangleValues[i - 1][j];

                    triangleValues[i][j] = value1 > value2 ? value1 + triangle[i][j] : value2 + triangle[i][j];
                }
            }

            return triangleValues.Last().Max();
        }
    }
}
